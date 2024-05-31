using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;

namespace pracaInzynierska_backend.Services.IRepository
{
    public interface IFriendListRepository : IGenericRepository<FriendList>
    {
        Task<List<FriendListDTO>> GetFriendListAsync(int userId);
    }
}
