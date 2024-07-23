using Microsoft.EntityFrameworkCore;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;
using pracaInzynierska_backend.Services.IRepository;

namespace pracaInzynierska_backend.Services.Repository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<GetPostDto>> GetPostsAsync(string gameName, int page)
        {
            var posts = await _context.Posts
                .Where(x => x.Game.Name == gameName)
                .Skip(page * 10)
                .Take(10)
                .Select( e => new GetPostDto
                {
                    PostId = e.PostId,
                    Title = e.Title,
                    Content = e.Content,
                    IdUserOwner = e.IdUser,
                    User = _context.Users.Where(x => x.UserId == e.IdUser).Select(x => x.Login).First(),
                    IdGame = e.IdGame,
                    Comments = null
                })
                .ToListAsync();
            return posts;

        }

        public async Task<GetPostDto> GetPostWithCommentsAsync(int postId)
        {
            //errorMessage = "";
            //var checkGameId = await _data.Games
            //    .Where(e => e.GameId == gameId)
            //    .FirstOrDefaultAsync();
            //if (checkGameId == null)
            //{
            //    errorMessage = $"No game with {gameId} id";
            //    return new Tuple<List<GetPostDto>, string>(null, errorMessage);
            //}

            var posts = _context.Posts
                .Where(e => e.PostId == postId)
                .Select(e => new GetPostDto
                {
                    PostId = e.PostId,
                    Title = e.Title,
                    Content = e.Content,
                    IdUserOwner = e.IdUser,
                    User = _context.Users.Where(x => x.UserId == e.IdUser).Select(x => x.Login).First(),
                    IdGame = e.IdGame,
                    Date = e.Date,
                    Image = Convert.ToBase64String(System.IO.File
                        .ReadAllBytes(
                        Path.Combine(Environment.CurrentDirectory, e.User.IconPath))),
                    Comments = _context.Comments
                    .Where(x => x.IdPost == e.PostId)
                    .Select(y => new GetCommentDto
                    {
                        CommentId = y.CommentId,
                        Date = y.Date,
                        Content = y.Content,
                        User = _context.Users.Where(x => x.UserId == y.IdUser).Select(x => x.Login).First(),
                        IdUser = y.IdUser,
                        Image = Convert.ToBase64String(System.IO.File
                        .ReadAllBytes(
                        Path.Combine(Environment.CurrentDirectory, y.User.IconPath))),

                    })
                    .ToList()

                })
                .FirstOrDefault();

            return posts;
        }
    }
}
