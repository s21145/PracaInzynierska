using Newtonsoft.Json;

namespace pracaInzynierska_backend.Models.Dto
{
    public class PlayTimeSteamDTO
    {
        public Response? Response { get; set; }
    }
    public class Response
    {
        [JsonProperty("game_count")]
        public long GameCount { get; set; }

        [JsonProperty("games")]
        public Game[] Games { get; set; }
    }

    public class Game
    {
        [JsonProperty("appid")]
        public long Appid { get; set; }

        [JsonProperty("playtime_forever")]
        public long PlaytimeForever { get; set; }
    }
}
