using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Runtime.InteropServices;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class BlogRepository : IBlogRepository
    {
        public readonly BlogDbContext db;
        public BlogRepository(BlogDbContext _db) 
        {
            db= _db;
        }
        public async Task<bool> AddBlog(BlogDetails blogDetails)
        {
            var result = false;
            using(var transaction = await db.Database.BeginTransactionAsync())
            {
                try
                {
                    blogDetails.CreationDate = DateTime.Now;
                    db.BlogDetails.Add(blogDetails);
                    await transaction.CommitAsync();
                    db.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            return result;
        }


        [HttpPost("AddComments")]
        public async Task<bool> AddComments(BlogComments comments)
        {
            var result = false;
            using (var transaction = await db.Database.BeginTransactionAsync())
            {
                try
                {
                    comments.CreationDate = DateTime.Now;
                    db.BlogComments.Add(comments);
                    await transaction.CommitAsync();
                    db.SaveChangesAsync();
                    result = true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            return result;
        }

        public BlogDetails DeleteBlog(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogDetails> GetAllBlog()
        {
            //List<BlogDetails> blogDetails = db.BlogDetails.ToList();

            var blogDetails = (from blcom in db.BlogDetails
                               join usr in db.BlogerUserDetails on blcom.UserId equals usr.UserId
                                select new BlogDetails
                                {
                                    BlogId = blcom.BlogId,
                                    BlogDescription = blcom.BlogDescription,
                                    BlogName = blcom.BlogName,
                                    UserId = blcom.UserId,
                                    CreationDate = blcom.CreationDate,
                                    UserName = usr.UserName
                                }).ToList();
            return blogDetails;
        }

        public BlogDetails GetBlog(int id)
        {
            BlogDetails blogDetails = db.BlogDetails.Where(x=>x.BlogId==id).FirstOrDefault();
            return blogDetails;
        }

        public IEnumerable<BlogComments> GetComments(int id)
        {

            var blogComments =(from blcom in db.BlogComments
                                             join usr in db.BlogerUserDetails on blcom.UserId equals usr.UserId
                                             select new BlogComments
                                             {
                                                 CommentId=blcom.CommentId,
                                                 CommentText=blcom.CommentText,
                                                 UserId=blcom.UserId,
                                                 CreationDate=blcom.CreationDate,
                                                 UserName= usr.UserName
                                             }).ToList();
            return blogComments;
        }

        public IEnumerable<BlogDetails> GetMyBlogs(int userId)
        {
            List<BlogDetails> blogDetails = db.BlogDetails.Where(x=>x.UserId== userId).ToList();
            return blogDetails;
        }

        public BlogDetails UpdateBlog(BlogDetails blogDetails)
        {
            throw new NotImplementedException();
        }
    }
}
