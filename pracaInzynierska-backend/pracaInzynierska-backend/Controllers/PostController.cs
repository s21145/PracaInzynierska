using Microsoft.AspNetCore.Mvc;
using pracaInzynierska_backend.Services;

namespace pracaInzynierska_backend.Controllers
{
    [ApiController]
    public class PostController : ControllerBase
    {
        IDatabase Database;
        public PostController(IDatabase data)
        {
            Database = data;
        }

        [HttpGet]
        [Route("posts")]
        public async Task<IActionResult> GetPostsAsync(int gameId)
        {
            var posts = await Database.GetPostsAsync(gameId);
            if(posts.Item2 != "")
            {
                return StatusCode(404,posts.Item2);
               
            }
            return Ok(posts.Item1);
        }
    }
   
}
