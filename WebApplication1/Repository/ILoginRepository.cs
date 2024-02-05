using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface ILoginRepository
    {
        Task<BlogerUserDetails> RegisterUser(BlogerUserDetails blogerUserDetails);
        BlogerUserDetails LoginUser(BlogerUserDetails blogerUserDetails);
    }
}
