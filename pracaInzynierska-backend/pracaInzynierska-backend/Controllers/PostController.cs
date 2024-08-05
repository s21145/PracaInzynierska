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
        public async Task<IActionResult> GetPostsAsync([FromQuery] GetPostsDTO body)
        {
            var findGame = await _unitOfWork.Game.GetAsync(x => x.Name == body.GameName);
            if (findGame.Count() == 0 )
                return StatusCode(400, "Nie ma takiej gry");

            var posts = await _unitOfWork.Post.GetPostsAsync(body.GameName,body.Page);
            return Ok(posts);
        }
        [HttpPost("post")]
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
                IdGame = game.GameId,
                Date = DateTime.Now,
            };
            await _unitOfWork.Post.InsertAsync(post);
            await _unitOfWork.SaveAsync();

            return StatusCode(200);
        }
        [HttpPost("comment")]
        public async Task<IActionResult> CreateCommentAsync(CreateCommentDTO body)
        {

            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();

            var comment = new Comment()
            {
                Date =  DateTime.Now,
                Content = body.Content,
                IdUser = user.UserId,
                IdPost = body.IdPost
            };
            await _unitOfWork.Comments.InsertAsync(comment);
            await _unitOfWork.SaveAsync();

            return Ok(Comment.GetCommentDto(comment));
        }
        [HttpGet("post")]
        public async Task<IActionResult> GetPostWithComment(int id)
        {
            var findGame = await _unitOfWork.Post.GetByIDAsync(id);
            if (findGame is null)
                return StatusCode(400, "Nie ma takiego posta");

            var posts = await _unitOfWork.Post.GetPostWithCommentsAsync(id);
            return StatusCode(200,posts);
        }
    }
   
}
