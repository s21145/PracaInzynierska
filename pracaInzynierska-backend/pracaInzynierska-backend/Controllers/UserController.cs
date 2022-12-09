﻿using Microsoft.AspNetCore.Authorization;
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
        private readonly string key = "28A4A65572FB7696356B3B5B5D1D3801";
        public UserController(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory)
        {
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet("userData")]
        public async Task<IActionResult> GetUserData()
        {
            return null;
        }
        [HttpPost("password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO request)
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
        public async Task<IActionResult> ChangeDescription([FromBody] string Description)
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
        public async Task<IActionResult> ChangeEmail([FromBody]string email)
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
        public async Task<IActionResult> AddSteamId([FromBody]string steamId)
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
        public async Task<IActionResult> AddSteamGame([FromBody]string gameId)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
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
                ["steamid"]=user.SteamId,
                ["appid"]=game.SteamId
            };
            var uri = QueryHelpers.AddQueryString(GetStatsSteam, query);
            var httpResponse = await httpClient.GetAsync(uri);
            if (!httpResponse.IsSuccessStatusCode)
                return StatusCode(500, "Błąd przy pobieraniu danych ze steam");

            var dto = JsonConvert.DeserializeObject<GameStatsSteamDTO>(await httpResponse.Content.ReadAsStringAsync());

            var findImportantStats = await _unitOfWork.StatsName.GetAsync(x => x.IdGame == game.GameId);
            var importantStats = findImportantStats.Select(x => x.Name).ToList();
            if (importantStats.Count == 0)
                return StatusCode(500, "Brak nazw statystyk");

            List<UserGameStats> statsToAdd = new List<UserGameStats>();
            foreach(var stat in dto.Stats)
            {
                if (importantStats.Contains(stat.Name))
                {
                    var tmp = new UserGameStats()
                    {

                        IdGame = game.GameId,
                        IdUser = user.UserId,
                        Name = stat.Name,
                        Value = stat.Value
                    };
                    
                    statsToAdd.Add(tmp);
                    await  _unitOfWork.Stats.InsertAsync(tmp);
                }
            }
            await _unitOfWork.SaveAsync();
            var rating = new UserGameRanking()
            {
                IdUser = user.UserId,
                IdGame = game.GameId,
                score = 1000, // do zmiany
            };
            await _unitOfWork.Ranking.InsertAsync(rating);

            return StatusCode(200,statsToAdd);
        }
        [HttpGet("Stats")]
        public async Task<IActionResult> GetStats(GetStatsDTO body)
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
                return StatusCode(200,stats);
            }
            else
            {
                var findUser = await _unitOfWork.User.GetAsync(x => x.Login == body.UserName);
                var user = findUser.FirstOrDefault();
                if (user is null)
                    return StatusCode(400, "Nie ma takiego użytkownika");
                var findUserStats = await _unitOfWork.Stats.GetAsync(x => x.IdGame == body.IdGame && x.User.Login == body.UserName);
                var userStats = findUserStats.ToList();
                return StatusCode(200, userStats);

            }
        }
        [HttpPost("refreshStats")]
        public async Task<IActionResult> RefreshStats([FromBody] string gameId)
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

            var dto = JsonConvert.DeserializeObject<GameStatsSteamDTO>(await httpResponse.Content.ReadAsStringAsync());

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
    }
}
