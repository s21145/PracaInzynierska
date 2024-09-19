namespace pracaInzynierska_backend.Models.Dto
{
    public class ReturnSimilarUsersDTO
    {
        public string UserLogin { get; set; }
        public int UserId { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsFriend { get; set; }
    }
}
