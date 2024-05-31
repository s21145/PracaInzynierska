using System.ComponentModel.DataAnnotations;

namespace pracaInzynierska_backend.Models
{
    public class FriendListRequest
    {
        [Key]
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public DateTime FromDate { get; set; }
        public string Status { get; set; }

        public User Sender { get; set; }
        public User Recipient { get; set; }
    }
}
