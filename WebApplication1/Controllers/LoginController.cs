using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController:ControllerBase
    {
        public readonly ILoginRepository loginRepository;
        public LoginController(ILoginRepository _loginRepository) 
        {
            loginRepository = _loginRepository;
        }

        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(BlogerUserDetails blogerUserDetails)
        {
            var response = loginRepository.RegisterUser(blogerUserDetails);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("LoginUser")]
        public IActionResult LoginUser(BlogerUserDetails blogerUserDetails)
        {
            var response = loginRepository.LoginUser(blogerUserDetails);
            return Ok(response);
        }

    }
}
