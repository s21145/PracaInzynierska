using pracaInzynierska_backend.Models;

namespace pracaInzynierska_backend.Services.IRepository
{
    public interface IFriendListRequestRepository : IGenericRepository<FriendListRequest>
    {
        Task<Tuple<bool, string>> SetResponseForFriendRequestAsync(int FromUserId, int ToUserId, string newStatus);
    }
}
