namespace pracaInzynierska_backend.Models.Dto
{
    public class GetMessagesDTO
    {
        public int Id { get; set; }
        public string SenderLogin { get; set; }
        public string ReceiverLogin { get; set; }
        public string Content { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
