using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Services.IRepository;

namespace pracaInzynierska_backend.Services.Repository
{
    public class FriendListRepository : GenericRepository<FriendList>, IFriendListRepository
    {
        public FriendListRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
