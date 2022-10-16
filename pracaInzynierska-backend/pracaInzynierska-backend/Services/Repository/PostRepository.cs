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
        public async Task<List<GetPostDto>> GetPostsWithCommentsAsync(int gameId)
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

            var posts =   _context.Posts
                .Where(e => e.IdGame == gameId)
                .Select(e => new GetPostDto
                {
                    PostId = e.PostId,
                    Title = e.Title,
                    Content = e.Content,
                    IdUserOwner = e.IdUser,
                    User = _context.Users.Where(x => x.UserId == e.IdUser).Select(x => x.Login).First(),
                    IdGame = e.IdGame,
                    Comments = _context.Comments
                    .Where(x => x.IdPost == e.PostId)
                    .Select(y => new GetCommentDto
                    {
                        CommentId = y.CommentId,
                        Date = y.Date,
                        Content = y.Content,
                        User = _context.Users.Where(x => x.UserId == y.IdUser).Select(x => x.Login).First(),
                        IdUser = y.IdUser

                    })
                    .ToList()

                })
                .ToList();
            return posts;
        }
    }
}
