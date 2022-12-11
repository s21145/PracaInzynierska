using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pracaInzynierska_backend.Services.IRepository;

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
            return StatusCode(200);
        }

    }
}
