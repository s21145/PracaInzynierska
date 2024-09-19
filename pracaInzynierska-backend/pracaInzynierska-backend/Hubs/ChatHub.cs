
using Microsoft.AspNet.SignalR.Messaging;
using Microsoft.AspNetCore.SignalR;
using pracaInzynierska_backend.Models;
using pracaInzynierska_backend.Models.Dto;
using pracaInzynierska_backend.Services.IRepository;
using pracaInzynierska_backend.Services.Repository;
using System.Security.Claims;
using Message = pracaInzynierska_backend.Models.Message;

namespace pracaInzynierska_backend.Hubs
{

    public class ChatHub : Hub
    {
        IUnitOfWork _unitOfWork;
        public ChatHub(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public async Task SendMessage(string message,string chatRoom,int sender,string senderLogin,int receiver)
        {
            var messageDatabase = new Message
            {
                SenderId = sender,
                ReceiverId = receiver,
                Content = message,
                MessageDate = DateTime.Now,
            };
            var messageDTO = new MessageHubDTO
            {
                Message = messageDatabase,
                Sender = senderLogin
            };
            await Clients.Group(chatRoom)
                .SendAsync("SpecificMessage", messageDTO);

         
            await _unitOfWork.Messages.InsertAsync(messageDatabase);
            await _unitOfWork.SaveAsync();
        }
        public async Task JoinChat(UserConnection conn)
        {
            await Clients.All.SendAsync("ReceiveMessage", "admin", "someone join");
        }
        public async Task JoinSpecificChatRoom(UserConnection conn)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conn.ChatRoom);
            //await Clients.Group(conn.ChatRoom).SendAsync("ReceiveMessage", "admin", "someone join");
        }
    }
}
