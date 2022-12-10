using Microsoft.AspNetCore.Mvc;
using pracaInzynierska_backend.Services;
using pracaInzynierska_backend.Services.IRepository;
using pracaInzynierska_backend.Services.Repository;
using System.Security.Claims;

namespace pracaInzynierska_backend.Controllers
{
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
       
        IUnitOfWork _unitOfWork;
        public GameController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("games")]
        public async Task<IActionResult> GetGamesAsync()
        {

            var games = await _unitOfWork.Game.GetAsync();
            return Ok(games);
        }
        [HttpGet]
        [Route("myGames")]
        public async Task<IActionResult> GetUserGames()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();

            var games = _unitOfWork.Game.GetUserGamesAsync(user.UserId);

            return StatusCode(200,games);
        }
        [HttpGet]
        [Route("missing")]
        public async Task<IActionResult> GetUserMissing()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();

            var games = _unitOfWork.Game.GetUserMissingGamesAsync(user.UserId);

            return StatusCode(200, games);
        }
    }
}
