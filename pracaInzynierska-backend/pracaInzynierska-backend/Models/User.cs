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
        public string Description { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
