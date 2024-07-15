using pracaInzynierska_backend.Models;

namespace pracaInzynierska_backend.Services.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetUsers(string nickname,User userLogged);
    }
}
