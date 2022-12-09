using System.ComponentModel.DataAnnotations;

namespace pracaInzynierska_backend.Models
{
    public class UserGameStats
    {
        [Key]
        public int Id { get; set; }
        public int IdGame { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; }
        public long Value { get; set; }

        public User User { get; set; }
        public Game Game { get; set; }
    }
}
