using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;

namespace pracaInzynierska_backend.Services
{
    public interface IDatabase
    {
        public Task<Tuple<List<GetPostDto>,string>> GetPostsAsync(int gameId);
    }
}
