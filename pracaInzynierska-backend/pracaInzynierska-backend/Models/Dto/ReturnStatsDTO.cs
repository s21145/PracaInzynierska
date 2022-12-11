namespace pracaInzynierska_backend.Models.Dto
{
    public class ReturnStatsDTO
    {
        public string GameName { get; set; }
        public string GameImage { get; set; }
        public string UserName { get; set; }
        public List<StatForSteamGames> Stats { get; set; }
    }
    public partial class StatForSteamGames
    {
        public string Name { get; set; }
        public long Value { get; set; }
    }
}
