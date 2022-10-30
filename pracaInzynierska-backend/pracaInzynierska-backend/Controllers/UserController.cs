using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pracaInzynierska_backend.Services.IRepository;
using System.Security.Claims;

namespace pracaInzynierska_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("UserData")]
        public async Task<IActionResult> GetUserData()
        {
            return null;
        }
        [HttpPost("Password")]
        public async Task<IActionResult> ChangePassword(string password)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            // hash ?????
            var query = await _unitOfWork.User.GetAsync(x => x.Login == userName && x.Password == password);
            var checkPassword = query.FirstOrDefault();
            if(checkPassword != default)
            {
                return StatusCode(400, "Haslo jest obecnie w użyciu");
            }
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.FirstOrDefault();
            if(user  == default)
            {
                return StatusCode(500, "Internal error");
            }
            user.Password = password;
             _unitOfWork.User.Update(user);
            await _unitOfWork.SaveAsync();


            return StatusCode(200, "Hasło zostało zmienione");
        }
        [HttpPost("Description")]
        public async Task<IActionResult> ChangeDescription([FromBody] string Description)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync((x) => x.Login == userName);
            var user = userQuery.First();
            user.Description = Description;
            _unitOfWork.User.Update(user);
            await _unitOfWork.SaveAsync();

            return StatusCode(200, "Opis został zmieniony");

        }
    }
}
