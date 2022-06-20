using System.ComponentModel.DataAnnotations;

namespace pracaInzynierska_backend.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
