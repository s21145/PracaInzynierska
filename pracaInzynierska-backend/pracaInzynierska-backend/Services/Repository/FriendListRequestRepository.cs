using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Services.IRepository;

namespace pracaInzynierska_backend.Services.Repository
{
    public class FriendListRequestRepository : GenericRepository<FriendListRequest>, IFriendListRequestRepository
    {
        public FriendListRequestRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
