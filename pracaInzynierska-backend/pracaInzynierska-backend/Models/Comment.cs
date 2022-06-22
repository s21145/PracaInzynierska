using System.ComponentModel.DataAnnotations;

namespace pracaInzynierska_backend.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int IdUser { get; set; }
        public int IdPost { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
