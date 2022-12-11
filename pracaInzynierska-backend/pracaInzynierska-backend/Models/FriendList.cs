using System.ComponentModel.DataAnnotations;

namespace pracaInzynierska_backend.Models
{
    public class FriendList
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int FriendId { get; set; }
        public DateTime From { get; set; }

        public User Owner { get; set; }
        public User Friend { get; set; }
    }
}
