using pracaInzynierska_backend.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace pracaInzynierska_backend.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int IdUser { get; set; }
        public int IdPost { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }

        static public GetCommentDto GetCommentDto(Comment comment)
        {
            return new GetCommentDto
            { 
                CommentId = comment.CommentId, 
                Date = comment.Date, 
                Content = comment.Content, 
                IdUser= comment.IdUser,
                User = comment.User.Login,
                Image = Convert.ToBase64String(System.IO.File
                .ReadAllBytes(
                    Path.Combine(Environment.CurrentDirectory, comment.User.IconPath))),
            };
        }
    }
}
