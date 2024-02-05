using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class BlogerUserDetails
    {
        [Key]       
        public int UserId { get; set; }

        public string? UserName { get; set; }   
        
        public string Email { get; set; }

        public string? Password { get; set;}

        public string? Name { get; set;}

        public DateTime? CreationDate {  get; set;}

        public DateTime? ModificationDate { get; set;}

    }
}
