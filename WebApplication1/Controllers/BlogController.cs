using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using WebApplication1.Models;
using WebApplication1.Repository;
using System.Runtime.InteropServices;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class BlogController: ControllerBase
    {

        private readonly IBlogRepository blogRepository;

        public BlogController(IBlogRepository _blogRepository)
        {
            blogRepository = _blogRepository;
        }


        [HttpPost("AddBlog")]
        public ActionResult AddBlog(BlogDetails blog)
        {
            var result = blogRepository.AddBlog(blog);
            return Ok(result);
        }

        [HttpPost("AddComments")]
        public ActionResult AddComments(BlogComments comments)
        {
            var result = blogRepository.AddComments(comments);
            return Ok(result);
        }

        [HttpGet("GetAllBlog")]
        public ActionResult GetAllBlog()
        {
            var blogs = blogRepository.GetAllBlog();
            return Ok(blogs);
        }

        [HttpPost("GetBlog")]
        public ActionResult GetBlog(int id)
        {
            var blog = blogRepository.GetBlog(id);
            return Ok(blog);
        }

        [HttpGet("GetMyBlogs")]
        public ActionResult GetMyBlogs(int userId)
        {
            var blog = blogRepository.GetMyBlogs(userId);
            return Ok(blog);
        }

        [HttpGet("GetThisBlog")]
        public ActionResult GetThisBlog(int blogId)
        {
            var blog = blogRepository.GetThisBlog(blogId);
            return Ok(blog);
        }

        [HttpGet("GetComments")]
        public ActionResult GetComments(int id)
        {
            var comments = blogRepository.GetComments(id);
            return Ok(comments);
        }

        [HttpGet("GetBlogLikesCommentsCount")]
        public ActionResult GetBlogLikesCommentsCount(int blogId)
        {
            var blogDetails = blogRepository.GetBlogLikesCommentsCount(blogId);
            return Ok(blogDetails);
        }

        [HttpPost("LikeBlog")]
        public ActionResult LikeBlog(BlogLikes blogLikes)
        {
            var response = blogRepository.LikeBlogAsync(blogLikes);
            return Ok(response);
        }

        //[HttpGet("GetBlogCommentCount")]
        //public int GetBlogCommentCount(int blogId)
        //{
        //    int blogDetails = blogRepository.GetBlogCommentCount(blogId);
        //    return blogDetails;
        //}




        //[Route("api/greetings/{name}")]
        [HttpGet("GetGreetings")]
        public string GetGreetings(string name)
        {
            return $"Hello {name}, Welcome to Web API";
        }

    }
}
