using Microsoft.AspNet.SignalR.Messaging;
using System.ComponentModel.DataAnnotations;

namespace pracaInzynierska_backend.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; } 
        public string Login { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string? Description { get; set; }
        public string? CurrentRefreshToken { get; set; }
        public DateTime? RefreshTokenExp { get; set; }
        public string? SteamId { get; set; }
        public string IconPath { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<UserGameStats> Stats { get; set; }
        public ICollection<UserGameRanking> Ranking { get; set; }
        public ICollection<FriendList> Friends { get; set; }
        public ICollection<FriendList> OnFriendList { get; set; }
        public ICollection<FriendListRequest> RequestsSent { get; set;}
        public ICollection<FriendListRequest> RequestsReceived { get; set; }
        public ICollection<Message> SendMessages { get; set; }
        public ICollection<Message> ReceivedMessages { get; set; }

    }
}
