using System.ComponentModel.DataAnnotations;

namespace pracaInzynierska_backend.Models
{
    public class PostLike
    {
        [Key] 
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
