using System.ComponentModel.DataAnnotations;

namespace pracaInzynierska_backend.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int IdGame { get; set; }
        public Game Game { get; set; }
    }
}
