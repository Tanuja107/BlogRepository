using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> option) : base(option) { 
        }

        public DbSet<BlogComments> BlogComments { get; set; }
        public DbSet<BlogDetails> BlogDetails { get; set; }
        public DbSet<BlogerUserDetails> BlogerUserDetails { get;set; }
        public DbSet<BlogLikes> BlogLikes { get;set; }

    }
}
