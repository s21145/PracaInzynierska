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
    [Route("api/[controller]")]
    
    public class LoginController : ControllerBase
    {
        private readonly string defaultPath = "..\\..\\images\\users\\default.png";
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
            var query = await _unitOfWork.User
                .GetAsync(user => user.Login == loginRequest.Login && user.Password == loginRequest.Password);
            var user = query.FirstOrDefault();
                
            if (user == default)
            {
                return StatusCode(404, "Nie znaleziono Uzytkownika");
            }
            user.CurrentRefreshToken = SecurityHelpers.GenerateRefreshToken();
            user.RefreshTokenExp = DateTime.Now.AddDays(1);
            await _unitOfWork.SaveAsync();
            return Ok(new
            {
                accessToken = CreateJwtTokenAsync(user),
                refreshToken = user.CurrentRefreshToken,
                image = Convert.ToBase64String(System.IO.File
                .ReadAllBytes(
                    Path.Combine(Environment.CurrentDirectory,user.IconPath))),
                login = user.Login,
                steamId = user.SteamId,
                age = user.BirthDate,
                description = user.Description

            });
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO register)
        {

            var query = await _unitOfWork.User
                .GetAsync(user => user.Login == register.Login || user.Email == register.Email);
            var userDb = query.FirstOrDefault();
            if(userDb != default)
            {
                return StatusCode(400, "Istnieje juz taki uzytkownik");
            }
            User newUser = new User
            {
                Login = register.Login,
                Password = register.Password,
                Email = register.Email,
                BirthDate = register.Birthday,
                IconPath = defaultPath
            };
            await _unitOfWork.User.InsertAsync(newUser);
            await _unitOfWork.SaveAsync();


            return Ok(newUser);
        }
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(string token)
        {
             var query = await _unitOfWork.User
                .GetAsync(user => user.CurrentRefreshToken == token && user.RefreshTokenExp > DateTime.Now);
            var user = query.FirstOrDefault();
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
        [HttpGet("reload")]
        public async Task<IActionResult> Reload(string refreshToken)
        {
            var query = await _unitOfWork.User
                .GetAsync(user => user.CurrentRefreshToken == refreshToken && user.RefreshTokenExp > DateTime.Now);
            var user = query.FirstOrDefault();
            if(user == default)
            {
                return StatusCode(400, "Niepoprawny Token");
            }

            user.CurrentRefreshToken = SecurityHelpers.GenerateRefreshToken();
            user.RefreshTokenExp = DateTime.Now.AddDays(1);
            await _unitOfWork.SaveAsync();
            return Ok(new
            {
                accessToken = CreateJwtTokenAsync(user),
                refreshToken = user.CurrentRefreshToken,
                image = Convert.ToBase64String(System.IO.File
                .ReadAllBytes(
                    Path.Combine(Environment.CurrentDirectory, user.IconPath))),
                login = user.Login,
                steamId = user.SteamId,
                age = user.BirthDate,
                description = user.Description
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
        private bool ValidateRegister()
        {
            //to do
            return true;
        }
        


    }
}
