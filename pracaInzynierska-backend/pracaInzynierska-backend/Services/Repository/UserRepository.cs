using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Services.IRepository;

namespace pracaInzynierska_backend.Services.Repository
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
