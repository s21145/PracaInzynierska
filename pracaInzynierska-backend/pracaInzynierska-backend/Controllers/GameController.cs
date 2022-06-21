using Microsoft.AspNetCore.Mvc;
using pracaInzynierska_backend.Services;

namespace pracaInzynierska_backend.Controllers
{
    public class GameController : ControllerBase
    {
        IDatabase Database;
        public GameController(IDatabase data)
        {
            Database = data;
        }
        [HttpGet]
        [Route("games")]
        public async Task<IActionResult> GetGamesAsync()
        {
            var games = await Database.GetGamesAsync();
            return Ok(games.Item1);
        }
    }
}
