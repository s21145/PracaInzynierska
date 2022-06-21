namespace pracaInzynierska_backend.Models.Dto
{
    public class GetCommentDto
    {
        public int CommentId { get; set; }
        public DateTime Date { get; set; }
        public string Context { get; set; }
        public string User { get; set; }
        public int IdUser { get; set; }
    }
}
