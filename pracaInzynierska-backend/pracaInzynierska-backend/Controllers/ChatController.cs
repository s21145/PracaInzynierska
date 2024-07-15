using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Services.IRepository;
using System.Security.Claims;

namespace pracaInzynierska_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        public ChatController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("friends")]
        public async Task<IActionResult> GetUserFriendListAsync()
        {
            // nie wiem narazie co zwracać
            return StatusCode(200);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddUserToFriendListAsync(string userLogin)
        {

            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();

            var findUser = await _unitOfWork.User.GetAsync(x => x.Login == userLogin);
            if (findUser.Count() == 0)
                return StatusCode(400, "Nie ma użytkownika o takiej nazwie");
            var friend = findUser.FirstOrDefault();
            var findFriend = await _unitOfWork.FriendLists
                .GetAsync(x => x.OwnerId == user.UserId && x.FriendId == friend.UserId);
            if (findFriend.Count() != 0)
                return StatusCode(400, "Użytkownik jest już na liście znajomych");

            var newFriend = new FriendList()
            {
                From = DateTime.Now,
                OwnerId = user.UserId,
                FriendId = friend.UserId
            };
            var reverseFriend = new FriendList()
            {
                From = DateTime.Now,
                OwnerId = friend.UserId,
                FriendId = user.UserId
            };
            await _unitOfWork.FriendLists.InsertAsync(newFriend);
            await _unitOfWork.FriendLists.InsertAsync(reverseFriend);
            await _unitOfWork.SaveAsync();

            return StatusCode(200);
        }

    }
}
