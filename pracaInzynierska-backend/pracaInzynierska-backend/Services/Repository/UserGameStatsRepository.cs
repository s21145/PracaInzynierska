using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Services.IRepository;

namespace pracaInzynierska_backend.Services.Repository
{
    public class UserGameStatsRepository : GenericRepository<UserGameStats>, IUserGameStatsRepository
    {
        public UserGameStatsRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
