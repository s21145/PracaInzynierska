using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Hosting;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;
using pracaInzynierska_backend.Services;
using pracaInzynierska_backend.Services.IRepository;
using System.Security.Claims;
using System.Xml.Linq;

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
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();
            var findGame = await _unitOfWork.Game.GetAsync(x => x.Name == body.GameName);
            if (findGame.Count() == 0 )
                return StatusCode(400, "Nie ma takiej gry");

            var posts = await _unitOfWork.Post.GetPostsAsync(body.GameName,body.Page,user.UserId);
            return Ok(posts);
        }
        [HttpGet]
        [Route("mainPagePosts")]
        public async Task<IActionResult> GetMainPagePostsAsync([FromQuery] int page)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();
            var posts = await _unitOfWork.Post.GetMainPagePostsAsync(page,user.UserId);
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

            return Ok(new GetPostDto()
            {
                PostId = post.PostId,
                Title = post.Title,
                Content = post.Content,
                IdUserOwner = post.IdUser,
                User = user.Login,
                IdGame= post.IdGame,
                Comments = null,
                Date = post.Date

            });
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
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();

            var findGame = await _unitOfWork.Post.GetByIDAsync(id);
            if (findGame is null)
                return StatusCode(400, "Nie ma takiego posta");

            var posts = await _unitOfWork.Post.GetPostWithCommentsAsync(id,user.UserId);
            return StatusCode(200,posts);
        }
        [HttpPost("like")]
        public async Task<IActionResult> AddLikeToPost(LikeDTO request)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();

            var checkLike = (await _unitOfWork.PostLikes.GetAsync(like => like.UserId == request.UserId && like.PostId == request.PostId)).FirstOrDefault();
            if(checkLike != null)
            {
                return StatusCode(400, "Użytkownik polubił już ten post");
            }
            var like = new PostLike()
            {
                UserId = request.UserId,
                PostId = request.PostId,

            };
            await _unitOfWork.PostLikes.InsertAsync(like);
            await _unitOfWork.SaveAsync();
            return StatusCode(200);
        }
        [HttpPost("unlike")]
        public async Task<IActionResult> UnlikePost(LikeDTO request)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();
            var checkLike = (await _unitOfWork.PostLikes.GetAsync(like => like.UserId == request.UserId && like.PostId == request.PostId)).FirstOrDefault();
            if (checkLike == null)
            {
                return StatusCode(400, "Użytkownik nie polubił tego postu");
            }
            await _unitOfWork.PostLikes.DeleteAsync(checkLike.Id);
            await _unitOfWork.SaveAsync();
            return StatusCode(200);
        }
    }
   
}
