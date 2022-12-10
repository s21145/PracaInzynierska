using Microsoft.EntityFrameworkCore;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Services.IRepository;

namespace pracaInzynierska_backend.Services.Repository
{
    public class UserGameRankingRepository : GenericRepository<UserGameRanking>, IUserGameRankingRepository
    {
        public UserGameRankingRepository(DatabaseContext context) : base(context)
        {

        }

        public async Task<List<UserGameRanking>> GetSimilarUsersAsync(int userScore,int IdGame, int page)
        {
            var findBetter = await _context.UserGameRakings
                .Include(x => x.User)
                .Where(x => x.score > userScore)
                .OrderBy(x => x.score)
                .Take(page * 5)
                .ToListAsync();
            var findWorse = await _context.UserGameRakings
                .Include(x => x.User)
                .Where(x => x.score <= userScore)
                .OrderByDescending(x => x.score)
                .Take(page * 5)
                .ToListAsync();
            findBetter.AddRange(findWorse);



            return findBetter;

        }
    }
}
