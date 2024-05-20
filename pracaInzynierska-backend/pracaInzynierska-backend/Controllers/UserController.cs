using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;
using pracaInzynierska_backend.Services.IRepository;
using System.Security.Claims;

namespace pracaInzynierska_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        IUnitOfWork _unitOfWork;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string GetStatsSteam = "https://api.steampowered.com/ISteamUserStats/GetUserStatsForGame/v2/";
        private readonly string key = "D65CABD4B8E9A882FC8D5651E8787645";
        public UserController(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory)
        {
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory;
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
            var CheckPassowrd = await _unitOfWork.User.GetAsync(x => x.Password == request.oldPassword);
            if(CheckPassowrd.Count() == 0)
            {
                return StatusCode(400, "Stare hasło jest niepoprawne");
            }
            var query = await _unitOfWork.User.GetAsync(x => x.Login == userName && x.Password == request.password);
          
            var checkPassword = query.FirstOrDefault();
            if(checkPassword != default)
            {
                return StatusCode(400, "Haslo jest obecnie w użyciu");
            }
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.FirstOrDefault();
            if(user  == default)
            {
                return StatusCode(500, "Internal error");
            }
            user.Password = request.password;
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
            if (importantStats.Count == 0)
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



                var rating = new UserGameRanking()
            {
                IdUser = user.UserId,
                IdGame = game.GameId,
                score = 1000, // do zmiany
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

                var userStats = await _unitOfWork.Stats.GetAsync(x => x.IdGame == body.IdGame);
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
            if (importantStats.Count == 0)
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


            var users = await _unitOfWork.Ranking.GetSimilarUsersAsync(rating, body.Idgame, body.Page);

            var response = new List<ReturnSimilarUsersDTO>();
            users.ForEach(x => response.Add(new ReturnSimilarUsersDTO()
            {
                UserLogin = x.User.Login,
                Description = x.User.Description,
                Birthday = x.User.BirthDate,
                Image = Convert.ToBase64String(System.IO.File
                .ReadAllBytes(
                    Path.Combine(Environment.CurrentDirectory, x.User.IconPath))),
            }));





            return StatusCode(200,response);
        }
    }
}
