using Microsoft.EntityFrameworkCore;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;
using pracaInzynierska_backend.Services.IRepository;

namespace pracaInzynierska_backend.Services.Repository
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(DatabaseContext context) : base(context)
        {
            
        }

        public List<GetGamesDTO> GetUserGamesAsync(int userId)
        {
            var games =  _context.UserGameStats
                .Where(x => x.IdUser == userId)
                .Select(x => x.Game)
                .Distinct()
                .ToList();
            
            var gamesDTO = new List<GetGamesDTO>();
            games.ForEach(x => gamesDTO.Add(new GetGamesDTO()
            {
                Name = x.Name,
                GameId = x.GameId,
                Image = Convert.ToBase64String(System.IO.File
                .ReadAllBytes(
                    Path.Combine(Environment.CurrentDirectory, x.ImagePath))),
            }));

            return gamesDTO;

     
                
        }

        public List<GetGamesDTO> GetUserMissingGamesAsync(int userId)
        {
            var games = _context.UserGameStats
               .Where(x => x.IdUser == userId)
               .Select(x => x.Game)
               .Distinct()
               .ToList();


            var allGames = _context.Games.ToList();
            List<GetGamesDTO> missing = new List<GetGamesDTO>();
            foreach(Game game in allGames)
            {
                if (games.Contains(game))
                    continue;
                missing.Add(new GetGamesDTO()
                {
                    Name = game.Name,
                    GameId = game.GameId,
                    Image = Convert.ToBase64String(System.IO.File
                .ReadAllBytes(
                    Path.Combine(Environment.CurrentDirectory, game.ImagePath))),
                });
            }
           
            return missing;
        }
    }
}
