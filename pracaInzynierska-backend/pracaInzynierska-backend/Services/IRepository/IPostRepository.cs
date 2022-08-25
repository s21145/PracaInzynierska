using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;

namespace pracaInzynierska_backend.Services.IRepository
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        public List<GetPostDto> GetPostsWithComments(int gameId);
    }
}
