namespace pracaInzynierska_backend.Models.Dto
{
    public class FriendsListRequest
    {
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserIcon { get; set; }
    }
}
