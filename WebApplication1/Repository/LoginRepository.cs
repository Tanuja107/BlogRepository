using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class LoginRepository : ILoginRepository
    {
        public readonly BlogDbContext db;
        public LoginRepository(BlogDbContext _db) 
        {
            db = _db;
        }
                
        public async Task<BlogerUserDetails> RegisterUser(BlogerUserDetails blogerUserDetails)
        {
            //var BlogerUserDetails = db.BlogerUserDetails.Where(x => x.Email == blogerUserDetails.Email).FirstOrDefault();

            using (var transaction = await db.Database.BeginTransactionAsync())
            {
                try
                {
                    blogerUserDetails.CreationDate = DateTime.Now;
                    db.BlogerUserDetails.Add(blogerUserDetails);
                    await transaction.CommitAsync();
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

            return blogerUserDetails;
        }

        public BlogerUserDetails LoginUser(BlogerUserDetails blogerUserDetails)
        {
            var BlogerUserDetails = db.BlogerUserDetails.Where(x => x.Email == blogerUserDetails.Email).FirstOrDefault();


            return BlogerUserDetails;
        }


    }
}
