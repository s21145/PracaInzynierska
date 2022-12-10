using System.ComponentModel.DataAnnotations;

namespace pracaInzynierska_backend.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
       
        public string? SteamId { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<UserGameStats> Stats { get; set; }
        public ICollection<UserGameRanking> Ranking { get; set; }
        public ICollection<StatsName> StatsNames { get; set; }

    }
}
