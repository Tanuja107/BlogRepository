using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class BlogDetails
    {
        [Key]
        public int BlogId { get; set; }
        public string? BlogName { get; set;}
        public string? BlogDescription { get; set;}
        public int? UserId { get; set;}

        public DateTime? CreationDate { get; set; }

        public DateTime? ModificationDate { get; set; }
        public string? UserName { get; internal set; }
    }
}
