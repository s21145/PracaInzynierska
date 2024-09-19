using Microsoft.EntityFrameworkCore;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;
using pracaInzynierska_backend.Services.IRepository;

namespace pracaInzynierska_backend.Services.Repository
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(DatabaseContext context) : base(context)
        {

        }
        public async Task<List<GetMessagesDTO>> GetMessagesAsync(string reciver,string sender,int page)
        {
            var messages = await _context.Message
                .Include(x => x.Sender)
                .Include(x => x.Receiver)
                .Where(x => x.Sender.Login == sender || x.Sender.Login == reciver)
                .Where(x => x.Receiver.Login == reciver || x.Receiver.Login == sender)
                .OrderByDescending(x => x.MessageDate)
                .Skip(page * 10)
                .Take(10)
                .Select( m => new GetMessagesDTO
                {
                    Id = m.Id,
                    MessageDate = m.MessageDate,
                    Content = m.Content,
                    SenderLogin = m.Sender.Login,
                    ReceiverLogin = m.Receiver.Login,
                })
                .ToListAsync();
            messages.Reverse();
            return messages;
        }
    }
}
