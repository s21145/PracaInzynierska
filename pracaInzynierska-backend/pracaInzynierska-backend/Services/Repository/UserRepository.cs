using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;
using pracaInzynierska_backend.Services.IRepository;
using System.Security.Cryptography.X509Certificates;

namespace pracaInzynierska_backend.Services.Repository
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
           

        }
      

        public async Task<List<User>> GetUsers(string nickname,User userLogged)
        {
            var result = new List<User>(); 
            if(nickname == string.Empty)
            {
                return result;
            }
             result = await _context.Users
                .Where(user => user.Login.Contains(nickname))
                .Where(user => user.Login != userLogged.Login)
                .ToListAsync();
            return result;
        }
        public async Task<List<User>> GetUsersWithFriendsAndRequests(string nickname, User userLogged,int page)
        {
            var result = new List<User>();
            if (nickname == string.Empty)
            {
                return result;
            }
            result = await _context.Users
               .Where(user => user.Login.Contains(nickname))
               .Where(user => user.Login != userLogged.Login)
               .Include(user => user.Friends)
               .Include(user => user.RequestsReceived)
               .Include(user => user.RequestsSent)
                .OrderBy(user => user.Login)
                .Skip(page * 5)
                .Take(5)
               .ToListAsync();
            return result;
        }
    }
}
