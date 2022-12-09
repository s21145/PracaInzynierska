using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;
using pracaInzynierska_backend.Services;
using pracaInzynierska_backend.Services.IRepository;
using System.Security.Claims;

namespace pracaInzynierska_backend.Controllers
{
    [Route("api/Post")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("posts")]
        public async Task<IActionResult> GetPostsAsync(int gameId)
        {
            var findGame = await _unitOfWork.Game.GetByIDAsync(gameId);
            if (findGame is null)
                return StatusCode(400, "Nie ma takiej gry");

            var posts = await _unitOfWork.Post.GetPostsWithCommentsAsync(gameId);
            return Ok(posts);
        }
        [HttpPost("posts")]
        public async Task<IActionResult> CreatePostAsync(CreatePostDTO body)
        {
            var findGame = await _unitOfWork.Game.GetAsync(x => x.Name == body.GameName);
            if (findGame is null)
                return StatusCode(400, "Nie ma takiej gry");

            var game = findGame.FirstOrDefault();

            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();

            var post = new Post()
            {
                Title = body.Title,
                Content = body.Content,
                IdUser = user.UserId,
                IdGame = game.GameId
            };
            await _unitOfWork.Post.InsertAsync(post);

            return StatusCode(200);
        }
    }
   
}
