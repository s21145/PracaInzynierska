using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;

namespace pracaInzynierska_backend.Services.IRepository
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        public Task<List<GetPostDto>> GetPostsWithCommentsAsync(int gameId);
    }
}
