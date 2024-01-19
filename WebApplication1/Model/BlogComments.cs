using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class BlogComments
    {
        [Key]
        public int CommentId { get; set; }
        public string? CommentText { get; set; }
        public int? BlogId { get; set; }
        public int? UserId {  get; set; }
        public DateTime? CreationDate { get; set; }

        public string UserName { get; set; }
    }
}
