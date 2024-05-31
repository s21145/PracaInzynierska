using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;

namespace pracaInzynierska_backend.Services.IRepository
{
    public interface IFriendListRequestRepository : IGenericRepository<FriendListRequest>
    {
        Task<Tuple<bool, string>> SetResponseForFriendRequestAsync(int FromUserId, int ToUserId, string newStatus);
        Task<List<FriendsListRequest>> GetFriendsListRequestsAsync(int userId);
    }
}
