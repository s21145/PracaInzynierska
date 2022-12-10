using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Services.IRepository;

namespace pracaInzynierska_backend.Services.Repository
{
    public class StatsNameRepository : GenericRepository<StatsName>, IStatsNameRepository
    {
        public StatsNameRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
