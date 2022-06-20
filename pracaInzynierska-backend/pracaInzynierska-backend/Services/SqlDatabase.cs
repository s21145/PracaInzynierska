using Microsoft.EntityFrameworkCore;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;

namespace pracaInzynierska_backend.Services
{
    public class SqlDatabase : IDatabase
    {
        DatabaseContext _data;

        public SqlDatabase()
        {
            _data = new DatabaseContext();
        }

        public async Task<Tuple<List<GetPostDto>,string>> GetPostsAsync(int gameId)
        {
            var errorMessage = "";
            var checkGameId = await _data.Games
                .Where(e => e.GameId == gameId)
                .FirstOrDefaultAsync();
            if(checkGameId == null)
            {
                errorMessage = $"No game with {gameId} id";
                return new Tuple<List<GetPostDto>, string>(null, errorMessage);
            }

            var posts = await _data.Posts
                .Where(e => e.IdGame == gameId)
                .Select(  e => new GetPostDto
                {
                    PostId = e.PostId,
                    Title = e.Title,
                    Context = e.Context,
                    IdUserOwner = e.IdUser,
                    IdGame = e.IdGame,
                    Comments =  _data.Comments
                    .Where(x => x.IdPost == e.PostId)
                    .Select(y => new GetCommentDto
                    {
                        CommentId = y.CommentId,
                        Date = y.Date,
                        Context = y.Context,
                        IdUser = y.IdUser

                    })
                    .ToList()

                })
                .ToListAsync();



            return new Tuple<List<GetPostDto>,string>(posts, errorMessage);
        }
    }
}
