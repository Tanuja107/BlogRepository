using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class BlogerUserDetails
    {
        [Key]       
        public int UserId { get; set; }

        public string? UserName { get; set; }
               
        //[StringLength(15)]
        //[Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set;}

        public DateTime? CreationDate {  get; set;}

        public DateTime? ModificationDate { get; set;}

    }
}
