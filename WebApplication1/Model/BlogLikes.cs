using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class BlogLikes
    {
        [Key]
        public int BlogLikeId { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
