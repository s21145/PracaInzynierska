namespace pracaInzynierska_backend.Models.Dto
{
    public class GameStatsSteamDTO
    {
        public string SteamId { get; set; }
        public string GameName { get; set; }
        public Stat[] Stats { get; set; }
        public Achievement[] Achievements { get; set; }
    }
    public partial class Achievement
    {

        public string Name { get; set; }

        public long Achieved { get; set; }
    }

    public partial class Stat
    {

        public string Name { get; set; }

        public long Value { get; set; }
    }
}
