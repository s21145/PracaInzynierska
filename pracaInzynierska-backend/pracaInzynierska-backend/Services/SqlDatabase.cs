using Microsoft.EntityFrameworkCore;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;

namespace pracaInzynierska_backend.Services
{
    public class SqlDatabase : IDatabase
    {
        DatabaseContext _data;
        string errorMessage;

        public SqlDatabase()
        {
            _data = new DatabaseContext();
        }

        public async Task<Tuple<List<Game>, string>> GetGamesAsync()
        {
            errorMessage = "";
            var result = await _data.Games
                .ToListAsync();

            return new Tuple<List<Game>, string>(result, errorMessage);




        }

        public async Task<Tuple<List<GetPostDto>,string>> GetPostsAsync(int gameId)
        {
            errorMessage = "";
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
                .Select(e => new GetPostDto
                {
                    PostId = e.PostId,
                    Title = e.Title,
                    Content = e.Content,
                    IdUserOwner = e.IdUser,
                    User = _data.Users.Where(x => x.UserId == e.IdUser).Select(x => x.Login).First(),
                    IdGame = e.IdGame,
                    Comments = _data.Comments
                    .Where(x => x.IdPost == e.PostId)
                    .Select(y => new GetCommentDto
                    {
                        CommentId = y.CommentId,
                        Date = y.Date,
                        Content = y.Content,
                        User = _data.Users.Where(x => x.UserId == y.IdUser).Select(x => x.Login).First(),
                        IdUser = y.IdUser

                    })
                    .ToList()

                })
                .ToListAsync();



            return new Tuple<List<GetPostDto>,string>(posts, errorMessage);
        }
    }
}
