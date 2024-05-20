using pracaInzynierska_backend.Models;

namespace pracaInzynierska_backend.Services.IRepository
{
    public interface IUserGameRankingRepository : IGenericRepository<UserGameRanking>
    {
        public  Task<List<UserGameRanking>> GetSimilarUsersAsync(int userScore,int IdGame,int page,int forUser);
    }
}
