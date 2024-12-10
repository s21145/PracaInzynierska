using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Services.IRepository;

namespace pracaInzynierska_backend.Services.Repository
{
    public class PostLikeRepostiory : GenericRepository<PostLike>, IPostLikes
    {
        public PostLikeRepostiory(DatabaseContext context) : base(context)
        {

        }
    }
}
