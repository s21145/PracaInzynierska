using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Services.IRepository;

namespace pracaInzynierska_backend.Services.Repository
{
    public class CommentsRepository : GenericRepository<Comment>, ICommentsRepository
    {
        public CommentsRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
