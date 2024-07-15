using Microsoft.EntityFrameworkCore;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;
using pracaInzynierska_backend.Services.IRepository;

namespace pracaInzynierska_backend.Services.Repository
{
    public class FriendListRepository : GenericRepository<FriendList>, IFriendListRepository
    {
        public FriendListRepository(DatabaseContext context) : base(context)
        {
          
        }
        public async Task<List<FriendListDTO>> GetFriendListAsync(int userId)
        {
            var users = await _dbSet.Where(friend => friend.OwnerId == userId)
                .Select(friend => new FriendListDTO()
                {
                    UserLogin = friend.Friend.Login,
                    UserId = friend.Friend.UserId,
                    IconPath = Convert.ToBase64String(System.IO.File
                .ReadAllBytes(
                    Path.Combine(Environment.CurrentDirectory, friend.Friend.IconPath)))
                })
                .ToListAsync();

            return users;
        }
    }
}
