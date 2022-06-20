namespace pracaInzynierska_backend.Models.Dto
{
    public class GetPostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public int IdUserOwner { get; set; }
        public int IdGame { get; set; }
        public List<GetCommentDto> Comments { get; set; }
    }
}
