using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pracaInzynierska_backend.Models.Dto;
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
        [HttpGet("userData")]
        public async Task<IActionResult> GetUserData()
        {
            return null;
        }
        [HttpPost("password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO request)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            // hash ?????
            var CheckPassowrd = await _unitOfWork.User.GetAsync(x => x.Password == request.oldPassword);
            if(CheckPassowrd.Count() == 0)
            {
                return StatusCode(400, "Stare hasło jest niepoprawne");
            }
            var query = await _unitOfWork.User.GetAsync(x => x.Login == userName && x.Password == request.password);
          
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
            user.Password = request.password;
             _unitOfWork.User.Update(user);
            await _unitOfWork.SaveAsync();


            return StatusCode(200, "Hasło zostało zmienione");
        }
        [HttpPost("description")]
        public async Task<IActionResult> ChangeDescription([FromBody] string Description)
        {
            if (Description == String.Empty)
                return StatusCode(400, "Opis nie może być pusty");
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync((x) => x.Login == userName);
            var user = userQuery.First();
            user.Description = Description;
            _unitOfWork.User.Update(user);
            await _unitOfWork.SaveAsync();

            return StatusCode(200, "Opis został zmieniony");

        }
        [HttpPost("email")]
        public async Task<IActionResult> ChangeEmail([FromBody]string email)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            //validation for email?
            var checkEmail = await _unitOfWork.User.GetAsync((x) => x.Email == email);
            if(checkEmail.Count() != 0)
            {
                return StatusCode(400, "Podany email jest już używany");
            }
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();
            user.Email = email;
            _unitOfWork.User.Update(user);
            await _unitOfWork.SaveAsync();

            return StatusCode(200, "Email został zmieniony");
        }
        [HttpPost("steamId")]
        public async Task<IActionResult> AddSteamId([FromBody]string steamId)
        {
            //sprawdzicz czy steamId jest juz w systemie
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userQuery = await _unitOfWork.User.GetAsync(x => x.Login == userName);
            var user = userQuery.First();
            if(user.SteamId != null)
            {
                return StatusCode(400, "Konto ma już przypisane steamId");
            }
            user.SteamId = steamId;
            _unitOfWork.User.Update(user);
            await _unitOfWork.SaveAsync();

            return StatusCode(200, "SteamId zostało przypisane do konta");

        }
    }
}
