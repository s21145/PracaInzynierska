using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pracaInzynierska_backend.Models.Dto;
using pracaInzynierska_backend.Services.IRepository;
using System.Security.Claims;

namespace pracaInzynierska_backend.Controllers
{
    [Route("api/messages")]
    [ApiController]
    [Authorize]
    public class MessageController : Controller
    {
        IUnitOfWork _unitOfWork;
        public MessageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("messages")]
        public async Task<IActionResult> GetMessagesAsync([FromQuery] GetMessagesQueryDTO body)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();

            var checkUserQuery = await _unitOfWork.User.GetAsync(x => x.Login == body.UserLogin);
            var checkUser = checkUserQuery.First();
            if(checkUser is null)
            {
                return StatusCode(400, "Nie ma użytkownika o takim loginie");
            }
            var messages = await _unitOfWork.Messages.GetMessagesAsync(user.Login, checkUser.Login, body.Page);
            return Ok(messages);

        }
    }
}
