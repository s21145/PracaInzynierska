using System.ComponentModel.DataAnnotations;

namespace pracaInzynierska_backend.Models
{
    public class UserGameRanking
    {
        [Key]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdGame { get; set; }
        public int score { get; set; }

        public Game Game { get; set; }
        public User User { get; set; }
    }
}
