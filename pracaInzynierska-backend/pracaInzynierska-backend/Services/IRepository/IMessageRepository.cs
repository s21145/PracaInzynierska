using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;

namespace pracaInzynierska_backend.Services.IRepository
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Task<List<GetMessagesDTO>> GetMessagesAsync(string reciver, string sender, int page);
    }
}
