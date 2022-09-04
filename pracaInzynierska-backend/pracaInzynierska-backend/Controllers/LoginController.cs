using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using pracaInzynierska_backend.Helpers;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;
using pracaInzynierska_backend.Services.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pracaInzynierska_backend.Controllers
{
    public class LoginController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration; 
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginRequest)
        {
            var user = _unitOfWork.User
                .Get(user => user.Login == loginRequest.Login && user.Password == loginRequest.Password)
                .FirstOrDefault();
            if (user == default)
            {
                return StatusCode(404, "Nie znaleziono Uzytkownika");
            }
            user.CurrentRefreshToken = SecurityHelpers.GenerateRefreshToken();
            user.RefreshTokenExp = DateTime.Now.AddDays(1);
            _unitOfWork.Save();
            return Ok(new
            {
                accessToken = CreateJwtTokenAsync(user),
                refreshToken = user.CurrentRefreshToken
            });
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] LoginDTO login)
        {

            var userDb = _unitOfWork.User
                .Get(user => user.Login == login.Login)
                .FirstOrDefault();
            if(userDb != default)
            {
                return StatusCode(400, "Istnieje juz taki uzytkownik");
            }
            User newUser = new User
            {
                Login = login.Login,
                Password = login.Password
            };
            _unitOfWork.User.Insert(newUser);
            _unitOfWork.Save();


            return Ok(newUser);
        }
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(string token)
        {
            var user = _unitOfWork.User
                .Get(user => user.CurrentRefreshToken == token && user.RefreshTokenExp > DateTime.Now)
                .FirstOrDefault();
            // seperately condtion for expired token?
            if(user == default)
            {
                return StatusCode(400, "Niepoprawny Token");
            }


            return Ok(new
            {
                accessToken = CreateJwtTokenAsync(user)
            });

        }
        private string CreateJwtTokenAsync(User user)
        {
            Claim[] userclaim = new[]
            {
                new Claim(ClaimTypes.Name,user.Login)


            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost:7194",
                audience: "https://localhost:7194",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );



            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
