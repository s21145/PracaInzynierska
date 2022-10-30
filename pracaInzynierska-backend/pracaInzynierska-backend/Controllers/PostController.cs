using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pracaInzynierska_backend.Services;
using pracaInzynierska_backend.Services.IRepository;

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
            var posts = await _unitOfWork.Post.GetPostsWithCommentsAsync(gameId);
            return Ok(posts);
        }
    }
   
}
