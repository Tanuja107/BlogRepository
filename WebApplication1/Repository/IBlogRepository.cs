﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IBlogRepository
    {
        Task<bool> AddBlog(BlogDetails blogDetails);
        BlogDetails UpdateBlog(BlogDetails blogDetails);
        BlogDetails DeleteBlog(int id);
        BlogDetails GetBlog(int id);
        IEnumerable<BlogDetails> GetAllBlog();
        IEnumerable<BlogDetails> GetMyBlogs(int userId);
        IEnumerable<BlogDetails> GetThisBlog(int blogId);
        Task<bool> AddComments(BlogComments comments);
        IEnumerable<BlogComments> GetComments(int id);
        LineCommCount GetBlogLikesCommentsCount(int blogId);
        Task<bool> LikeBlogAsync(BlogLikes blogDetails);
        int GetBlogCommentCount(int blogId);
    }
}
