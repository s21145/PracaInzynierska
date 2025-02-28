﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using pracaInzynierska_backend.Helpers;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;
using pracaInzynierska_backend.Services.IRepository;
using System.Security.Claims;
using static pracaInzynierska_backend.Services.Repository.FriendListRequestRepository;

namespace pracaInzynierska_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        IUnitOfWork _unitOfWork;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string GetStatsSteam = "https://api.steampowered.com/ISteamUserStats/GetUserStatsForGame/v2/";
        private readonly string GetPlayTime = "http://api.steampowered.com/IPlayerService/GetOwnedGames/v1/";
        private string key;
        public UserController(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory,IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            key = _configuration["steamKey"];
        }
        [HttpGet("userData")]
        public async Task<IActionResult> GetUserDataAsync()
        {
            return null;
        }
        [HttpPost("password")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordDTO request)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            // hash ?????
            var user = (await _unitOfWork.User.GetAsync(u => u.Login == userName)).FirstOrDefault();
            var CheckPassword = PasswordHashHelper.VerifyPassword(request.oldPassword, user.Password);
            if (!CheckPassword)
            {
                return StatusCode(400, "Stare hasło jest niepoprawne");
            }
            if (user == default)
            {
                return StatusCode(500, "Internal error");
            }
            user.Password = PasswordHashHelper.HashPassword(request.password);
            _unitOfWork.User.Update(user);
            await _unitOfWork.SaveAsync();


            return StatusCode(200, "Hasło zostało zmienione");
        }

        [HttpPost("description")]
        public async Task<IActionResult> ChangeDescriptionAsync([FromBody] string Description)
        {
            if (Description == String.Empty)
                return StatusCode(400, "Opis nie może być pusty");
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync((x) => x.Login == userName);
            var user = userQuery.First();
            user.Description = Description;
            _unitOfWork.User.Update(user);
            await _unitOfWork.SaveAsync();

            return StatusCode(200, "Opis został zmieniony");

        }
        [HttpPost("email")]
        public async Task<IActionResult> ChangeEmailAsync([FromBody]string email)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            //validation for email?
            var checkEmail = await _unitOfWork.User.GetAsync((x) => x.Email == email);
            if(checkEmail.Count() != 0)
            {
                return StatusCode(400, "Podany email jest już używany");
            }
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();
            user.Email = email;
            _unitOfWork.User.Update(user);
            await _unitOfWork.SaveAsync();

            return StatusCode(200, "Email został zmieniony");
        }
        [HttpPost("steamId")]
        public async Task<IActionResult> AddSteamIdAsync([FromBody]string steamId)
        {   
            //sprawdzicz czy steamId jest juz w systemie
            var unique = await _unitOfWork.User.GetAsync(x => x.SteamId == steamId);
            var UniqueSteamId = unique.FirstOrDefault();
            if (UniqueSteamId != default)
                return StatusCode(400, "SteamId jest już przypisane do innego konta");
               
         
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();
            if(user.SteamId != null)
            {
                return StatusCode(400, "Konto ma już przypisane steamId");
            }
            user.SteamId = steamId;
            _unitOfWork.User.Update(user);
            await _unitOfWork.SaveAsync();

            return StatusCode(200, "SteamId zostało przypisane do konta");

        }
        [HttpPost("addGame")]
        public async Task<IActionResult> AddSteamGameAsync([FromBody]int gameId)
        {
           
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();
            if (user.SteamId is null)
                return StatusCode(400, "Użytkownik nie posiada przypisanego konta steam");
           

            var game = await _unitOfWork.Game.GetByIDAsync(gameId);
            if (game is null)
                return StatusCode(400, "Gra o takim ID nie istnieję");

            var findRanking = await _unitOfWork.Ranking.GetAsync(x => x.IdGame == gameId && x.IdUser == user.UserId);
            if(findRanking.Count() != 0  )
            {
                return StatusCode(400, "Uzytkownik ma już dodana podaną gre");
            }
                

            var httpClient = _httpClientFactory.CreateClient();

            if(game.SteamId is null)
                return StatusCode(500, "Gra nie ma przypisanego steamId");

            var query = new Dictionary<string, string>()
            {
                ["key"] = key,
                ["steamid"]=user.SteamId,
                ["appid"]=game.SteamId
            };

            var uri = QueryHelpers.AddQueryString(GetStatsSteam, query);
            var httpResponse = await httpClient.GetAsync(uri);
            if (!httpResponse.IsSuccessStatusCode)
                return StatusCode(500, "Błąd przy pobieraniu danych ze steam");
            var test = await httpResponse.Content.ReadAsStringAsync();
            var dtoPlayerstats = JsonConvert.DeserializeObject<GameStatsSteamDTO>(await httpResponse.Content.ReadAsStringAsync());
            var dto = dtoPlayerstats.Playerstats;
            var findImportantStats = await _unitOfWork.StatsName.GetAsync(x => x.IdGame == game.GameId);
            var importantStats = findImportantStats.ToList();
            if (importantStats.Count() == 0)
                return StatusCode(500, "Brak nazw statystyk");

            List<GetStatForGameDTO> statsToAdd = new List<GetStatForGameDTO>();
            foreach (var stat in dto.Stats)
            {
                var important = importantStats.Find(x => x.Name == stat.Name);
                if (important is null)
                    continue;

                var tmp = new UserGameStats()
                {

                    IdGame = game.GameId,
                    IdUser = user.UserId,
                    Name = important.PublicName,
                    Value = stat.Value
                };

                statsToAdd.Add(new GetStatForGameDTO
                {
                    GameName = game.Name,
                    UserLogin = user.Login,
                    Name = important.PublicName,
                    Value = stat.Value
                });
                await _unitOfWork.Stats.InsertAsync(tmp);


            }
            //pobranie playtime
            var queryForPlayTime = new Dictionary<string, string>()
            {
                ["key"] = key,
                ["steamid"] = user.SteamId,
                ["include_appinfo"] = "false",
                ["include_played_free_games"] = "true",
                ["ppids_filter"] = game.SteamId
            };
            var uriForPlayTime = QueryHelpers.AddQueryString(GetPlayTime, queryForPlayTime);
            var responeForPlayTime = await httpClient.GetAsync(uriForPlayTime);
            var playTimeResponse = await responeForPlayTime.Content.ReadAsStringAsync();
            var dtoPlayTime = JsonConvert.DeserializeObject<PlayTimeSteamDTO>(await responeForPlayTime.Content.ReadAsStringAsync());
            var playTimeDTO = dtoPlayTime.Response.Games
                .Where(stats => (stats.Appid).ToString()==game.SteamId)
                .Select(stat => Math.Round((decimal)(stat.PlaytimeForever/60),1))
                .First();

            var statPlayTime = new UserGameStats()
            {
                IdGame = game.GameId,
                IdUser = user.UserId,
                Name = "Play Time",
                Value = (long)playTimeDTO
            };
            statsToAdd.Add(new GetStatForGameDTO
            {
                GameName = game.Name,
                UserLogin = user.Login,
                Name = "Play Time",
                Value = (long)playTimeDTO
            });
            await _unitOfWork.Stats.InsertAsync(statPlayTime);
            //
            var userRating = 0;
           foreach (var stat in statsToAdd)
            {
                userRating += (int)stat.Value;
            }

            var rating = new UserGameRanking()
            {
                IdUser = user.UserId,
                IdGame = game.GameId,
                score = userRating
            };
            await _unitOfWork.Ranking.InsertAsync(rating);

            await _unitOfWork.SaveAsync();

            var response = new ReturnStatsDTO()
            {
                UserName = userName,
                GameName = game.Name,
                Stats = new List<StatForSteamGames>(),
                GameImage = Convert.ToBase64String(System.IO.File
               .ReadAllBytes(
                   Path.Combine(Environment.CurrentDirectory, game.ImagePath)))
            };
            //dodac tabele z tlumaczeniem i zwracac przetlumaczone nazwy statystyk
            statsToAdd.ForEach(x => response.Stats.Add(new StatForSteamGames()
            {
                Name = x.Name,
                Value = x.Value
            }));

            return StatusCode(200,response);
        }
        [HttpGet("Stats")]
        public async Task<IActionResult> GetStatsAsync([FromQuery]GetStatsDTO body)
        {
            var game = await _unitOfWork.Game.GetByIDAsync(body.IdGame);
            if (game is null)
                return StatusCode(400, "Nie ma takiej gry");
            if(body.UserName is null)
            {
                var userName = User.FindFirstValue(ClaimTypes.Name);
                var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
                var user = userQuery.First();

                var userStats = await _unitOfWork.Stats.GetAsync(x => x.IdGame == body.IdGame && user.UserId == x.IdUser);
                var stats = userStats.ToList();

                var response = new ReturnStatsDTO()
                {
                    UserName = userName,
                    GameName = game.Name,
                    Stats = new List<StatForSteamGames>(),
                    GameImage = Convert.ToBase64String(System.IO.File
                .ReadAllBytes(
                    Path.Combine(Environment.CurrentDirectory, game.ImagePath)))
                };
                //dodac tabele z tlumaczeniem i zwracac przetlumaczone nazwy statystyk
                stats.ForEach(x => response.Stats.Add(new StatForSteamGames()
                {
                    Name = x.Name,
                    Value = x.Value
                }));

                return StatusCode(200,response);
            }
            else
            {
                var findUser = await _unitOfWork.User.GetAsync(x => x.Login == body.UserName);
                var user = findUser.FirstOrDefault();
                if (user is null)
                    return StatusCode(400, "Nie ma takiego użytkownika");
                var findUserStats = await _unitOfWork.Stats.GetAsync(x => x.IdGame == body.IdGame && x.User.Login == body.UserName);
                var userStats = findUserStats.ToList();

                var response = new ReturnStatsDTO()
                {
                    UserName = body.UserName,
                    GameName = game.Name,
                    Stats = new List<StatForSteamGames>(),
                    GameImage = Convert.ToBase64String(System.IO.File
                .ReadAllBytes(
                    Path.Combine(Environment.CurrentDirectory, game.ImagePath)))
                };
                //dodac tabele z tlumaczeniem i zwracac przetlumaczone nazwy statystyk
                userStats.ForEach(x => response.Stats.Add(new StatForSteamGames()
                {
                    Name = x.Name,
                    Value = x.Value
                }));


                return StatusCode(200, response);

            }
        }
        [HttpPost("refreshStats")]
        public async Task<IActionResult> RefreshStatsAsync([FromBody] int gameId)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name); // kopia addGame Wrzucić to jakoś do funkcji
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();
            if (user.SteamId is null)
                return StatusCode(400, "Użytkownik nie posiada przypisanego konta steam");

            var game = await _unitOfWork.Game.GetByIDAsync(gameId);
            if (game is null)
                return StatusCode(400, "Gra o takim ID nie istnieję");
            var httpClient = _httpClientFactory.CreateClient();


            var query = new Dictionary<string, string>()
            {
                ["key"] = key,
                ["steamid"] = user.SteamId,
                ["appid"] = game.SteamId
            };
            var uri = QueryHelpers.AddQueryString(GetStatsSteam, query);
            var httpResponse = await httpClient.GetAsync(uri);
            if (!httpResponse.IsSuccessStatusCode)
                return StatusCode(500, "Błąd przy pobieraniu danych ze steam");

            var dtoPlayerstats = JsonConvert.DeserializeObject<GameStatsSteamDTO>(await httpResponse.Content.ReadAsStringAsync());
            var dto = dtoPlayerstats.Playerstats;
            var findImportantStats = await _unitOfWork.StatsName.GetAsync(x => x.IdGame == game.GameId);
            var importantStats = findImportantStats.Select(x => x.Name).ToList();
            if (importantStats.Count() == 0)
                return StatusCode(500, "Brak nazw statystyk");
            List<UserGameStats> statsToAdd = new List<UserGameStats>();
            var findOldStats = await _unitOfWork.Stats.GetAsync(x => game.GameId == x.IdGame && x.IdUser == user.UserId);
            List<UserGameStats> oldStats = findOldStats.ToList();
            foreach (var stat in dto.Stats)
            {
                if (!importantStats.Contains(stat.Name))
                    continue;
                var tmp = new UserGameStats()
                {

                    IdGame = game.GameId,
                    IdUser = user.UserId,
                    Name = stat.Name,
                    Value = stat.Value
                };
                var old = oldStats.Find(x => x.Name == tmp.Name);
                if(old is null)
                    await _unitOfWork.Stats.InsertAsync(tmp);
                if (old.Value != tmp.Value)
                {
                    old.Value = tmp.Value;
                    _unitOfWork.Stats.Update(old);
                }
                statsToAdd.Add(tmp);
            }
            //update rating
            var userRating = 0;
            foreach (var stat in statsToAdd)
            {
                userRating += (int)stat.Value;
            }


            var oldRating = (await _unitOfWork.Ranking.GetAsync(rating => rating.IdUser == user.UserId &&  rating.IdGame == gameId)).FirstOrDefault();
            if(oldRating is null)
            {
                var rating = new UserGameRanking()
                {
                    IdUser = user.UserId,
                    IdGame = game.GameId,
                    score = userRating
                };
                await _unitOfWork.Ranking.InsertAsync(rating);
            }
            else
            {
                oldRating.score = userRating;
                 _unitOfWork.Ranking.Update(oldRating);
            }
            

            await _unitOfWork.SaveAsync();


            return StatusCode(200,statsToAdd);
        }
        [HttpGet("users")]
        public async Task<IActionResult> GetSimilarUsers([FromQuery]GetSimilarUsersDTO body)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name); 
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();

            var game = await _unitOfWork.Game.GetAsync(x => x.GameId == body.Idgame);
            if (game.Count() == 0)
                return StatusCode(400, "Gra o takim ID nie istnieję");

            var findRating = await _unitOfWork.Ranking
                .GetAsync(x => x.IdUser == user.UserId && x.IdGame == body.Idgame);

            int rating = 0;
            if (!(findRating is null || findRating.Count() == 0))
                rating = findRating.FirstOrDefault().score;


            var users = await _unitOfWork.Ranking.GetSimilarUsersAsync(rating, body.Idgame, body.Page,user.UserId);

            var response = new List<ReturnSimilarUsersDTO>();
            users.ForEach(x => response.Add(new ReturnSimilarUsersDTO()
            {
                UserId = x.User.UserId,
                UserLogin = x.User.Login,
                Description = x.User.Description,
                Birthday = x.User.BirthDate,
                Image = Convert.ToBase64String(System.IO.File
                .ReadAllBytes(
                    Path.Combine(Environment.CurrentDirectory, x.User.IconPath))),
                IsFriend = x.User.Friends.Any(friend => friend.FriendId == user.UserId) ||
                 x.User.RequestsSent.Any(req => req.ToUserId == user.UserId  ) ||
                 x.User.RequestsReceived.Any(req => req.FromUserId == user.UserId)
            }));





            return StatusCode(200,response);
        }
        [HttpPost("removeFriend")]
        public async Task<IActionResult> RemoveFriend([FromQuery] int userId)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();
            if (user is null)
            {
                return StatusCode(400);
            }

            var userToRemoveQuery = await _unitOfWork.User.GetAsync(x => x.UserId == userId);
            var userToRemove = userToRemoveQuery.FirstOrDefault();
            if (userToRemove == null)
            {
                return StatusCode(400, "Nie istnieje użytkownik o takim ID");
            }
            var checkIfUserIsFriend = await _unitOfWork.FriendLists.GetAsync(friend => friend.OwnerId == user.UserId && friend.FriendId == userToRemove.UserId);
            if(checkIfUserIsFriend is null)
            {
                return StatusCode(403, "Nie ma takiego użytkownika na liście znajomych");
            }
            await _unitOfWork.FriendLists.DeleteAsync(checkIfUserIsFriend.First().Id);
            var removeFromFriendList = await _unitOfWork.FriendLists.GetAsync(friend => friend.OwnerId == userToRemove.UserId && friend.FriendId == user.UserId);
            if (checkIfUserIsFriend is null)
            {
                return StatusCode(403, "Nie ma takiego użytkownika na liście znajomych");
            }
            await _unitOfWork.FriendLists.DeleteAsync(removeFromFriendList.First().Id);
            var requestRemove = await _unitOfWork.FriendListRequests.GetAsync(friendRequest => ((friendRequest.FromUserId == user.UserId && friendRequest.ToUserId == userToRemove.UserId)
            || (friendRequest.FromUserId == userToRemove.UserId && friendRequest.ToUserId == user.UserId)) && friendRequest.Status == "Accepted");
            await _unitOfWork.FriendListRequests.DeleteAsync(requestRemove.First().Id);
            await _unitOfWork.SaveAsync();
            return StatusCode(200);
        }
        [HttpPost("sentFriendRequest")]
        public async Task<IActionResult> SentFriendRequest([FromQuery] int userId)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();

            var userToAddQuery = await _unitOfWork.User.GetAsync(x => x.UserId == userId);
            var userToAdd = userToAddQuery.FirstOrDefault();
            if(userToAdd == null)
            {
                return StatusCode(400, "Nie istnieje użytkownik o takim ID");
            }
            var checkIfUserCanAdd = await _unitOfWork.FriendListRequests.GetAsync(request => request.FromUserId == user.UserId
            && request.ToUserId == userToAdd.UserId
            && request.Status == FriendRequestStatus.Sent.ToString());
            if(checkIfUserCanAdd.Any())
            {
                return StatusCode(403, "Użytkownik wysłał już zaproszenie do znajomych");
            }

            var friendListRequest = new FriendListRequest()
            {
                FromUserId = user.UserId,
                ToUserId = userId,
                FromDate = DateTime.Now,
                Status = "Sent"
            };
            await _unitOfWork.FriendListRequests.InsertAsync(friendListRequest);
            await _unitOfWork.SaveAsync();
            return StatusCode(200);
        }
        [HttpPost("responseFriendRequest")]
        public async Task<IActionResult> ReponseFriendRequestAsync([FromQuery] int fromUserId, [FromQuery] string status)
        {
            var user = await GetUserAsync();
            if(user == null)
            {
                return StatusCode(400, $"Błąd podczas pobierania danych o użytkowniku");
            }
            var fromUser = await _unitOfWork.User.GetByIDAsync(fromUserId);
            if(fromUser == null)
            {
                return StatusCode(400, $"Nie istnieje użytkownik o  podanym id ");
            }
            var changeStatus = await _unitOfWork.FriendListRequests.SetResponseForFriendRequestAsync(fromUserId,user.UserId, status);
            if (!changeStatus.Item1)
            {
                return StatusCode(400, $"Błąd podczas zmiany statusu - {changeStatus.Item2} ");
            }
            if(status == "Declined")
            {
                await _unitOfWork.SaveAsync();
                return StatusCode(200);
            }
            var FriendList = new FriendList()
            {
                OwnerId = user.UserId,
                FriendId = fromUserId,
                From = DateTime.Now
            };
            await _unitOfWork.FriendLists.InsertAsync(FriendList);
            var FriendList2 = new FriendList()
            {
                OwnerId = fromUserId,
                FriendId = user.UserId,
                From = DateTime.Now
            };
            await _unitOfWork.FriendLists.InsertAsync(FriendList2);
            await _unitOfWork.SaveAsync();


            return StatusCode(200);
        }

        [HttpGet("friendsList")]
        public async Task<IActionResult> GetFriendListAsync()
        {
            var user = await GetUserAsync();
            if (user == null)
            {
                return StatusCode(400, $"Błąd podczas pobierania danych o użytkowniku");
            }
            var users = await _unitOfWork.FriendLists.GetFriendListAsync(user.UserId);

            return StatusCode(200,users);
        }
        [HttpGet("FriendsListRequests")]
        public async Task<IActionResult> GetFriendsListRequestsAsync()
        {
            var user = await GetUserAsync();
            if (user == null)
            {
                return StatusCode(400, $"Błąd podczas pobierania danych o użytkowniku");
            }
            var requests = await _unitOfWork.FriendListRequests.GetFriendsListRequestsAsync(user.UserId);

            return StatusCode(200, requests);
        }
        [HttpGet("searchForFindPlayers")]
        public async Task<IActionResult> GetUsersForFindPlayers([FromQuery] GetUserByNameDTO body)
        {
            var user = await GetUserAsync();
            if (user == null)
            {
                return StatusCode(400, $"Błąd podczas pobierania danych o użytkowniku");
            }
            var searchUsers = await _unitOfWork.User.GetUsersWithFriendsAndRequests(body.Username,user,body.Page);
            var response = new List<ReturnSimilarUsersDTO>();
            searchUsers.ForEach(x => response.Add(new ReturnSimilarUsersDTO()
            {
                UserId = x.UserId,
                UserLogin = x.Login,
                Description = x.Description,
                Birthday = x.BirthDate,
                Image = Convert.ToBase64String(System.IO.File
                .ReadAllBytes(
                    Path.Combine(Environment.CurrentDirectory, x.IconPath))),
                IsFriend = x.Friends.Any(friend => friend.FriendId == user.UserId) ||
                 x.RequestsSent.Any(req => req.ToUserId == user.UserId) ||
                 x.RequestsReceived.Any(req => req.FromUserId == user.UserId) 
                ,
            }));





            return StatusCode(200, response);
        }
       

        private async  Task<User> GetUserAsync()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();

            return user;
        }
    }
}
