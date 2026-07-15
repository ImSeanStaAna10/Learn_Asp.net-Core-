using HowToCreateWebAPI.Contracts;
using HowToCreateWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HowToCreateWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {

        private readonly IUserRepositorycs _userRepositorycs;
        public UserController(IUserRepositorycs userRepositorycs ) : base(userRepositorycs)
        {
            _userRepositorycs = userRepositorycs;
        }

        [AllowAnonymous] //public endpoint
        [HttpPost("Login")]
        public IActionResult UserLogin([FromBody]User user)
        {
            var result = _userRepositorycs.Login(user.Email, user.Password);
            if(result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
