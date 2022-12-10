using System.ComponentModel.DataAnnotations;

namespace pracaInzynierska_backend.Models
{
    public class StatsName
    {
        [Key]
        public int Id { get; set; }
        public int IdGame { get; set; }
        public string Name { get; set; }
        public Game Game { get; set; }
    }
}
