using Microsoft.EntityFrameworkCore;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;
using pracaInzynierska_backend.Services.IRepository;

namespace pracaInzynierska_backend.Services.Repository
{
    public class FriendListRequestRepository : GenericRepository<FriendListRequest>, IFriendListRequestRepository
    {
        public enum FriendRequestStatus
        {
            Sent,
            Declined,
            Accepted
        }
        public FriendListRequestRepository(DatabaseContext context) : base(context)
        {
           
        }
        public async Task<Tuple<bool, string>> SetResponseForFriendRequestAsync(int FromUserId, int ToUserId,string newStatus)
        {
            if(!Enum.TryParse(newStatus,out FriendRequestStatus statusCheck))
            {
                return new Tuple<bool, string>(false, $"Niepoprawny status - {newStatus}");
            }
            var request = await _dbSet.Where(req => req.FromUserId == FromUserId && req.ToUserId == ToUserId)
                .FirstOrDefaultAsync();
            if (request == null)
            {
                return new Tuple<bool, string>(false, $"Nie ma prośby o dodanie do znajomych od użytkownika o podanym id - {FromUserId}");
            }
            if(request.Status != FriendRequestStatus.Sent.ToString())
            {
                return new Tuple<bool, string>(false, $"Zaproszenie do znajomych ma już status - {request.Status}");
            }
            request.Status = newStatus;
            return new Tuple<bool, string>(true,string.Empty);
        }
        public async Task<List<FriendsListRequest>> GetFriendsListRequestsAsync(int userId)
        {
            var requests = await _dbSet.Where(req => req.ToUserId==userId && req.Status == FriendRequestStatus.Sent.ToString())
                .Select(req => new FriendsListRequest()
                {
                    UserId = req.Sender.UserId,
                    UserLogin = req.Sender.Login,
                    UserIcon = Convert.ToBase64String(System.IO.File
                .ReadAllBytes(
                    Path.Combine(Environment.CurrentDirectory, req.Sender.IconPath))),
                    Status = req.Status
                })
                .ToListAsync();
            return requests;
        }
   
    }
}
