namespace pracaInzynierska_backend.Models.Dto
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int IdUser { get; set; }
        public int IdPost { get; set; }
    }
}
