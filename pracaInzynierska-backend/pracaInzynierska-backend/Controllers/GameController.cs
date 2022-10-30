using Microsoft.AspNetCore.Mvc;
using pracaInzynierska_backend.Services;
using pracaInzynierska_backend.Services.IRepository;
using pracaInzynierska_backend.Services.Repository;

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
    }
}
