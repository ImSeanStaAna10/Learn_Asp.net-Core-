using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LoginAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("Profile")]
        [Authorize]
        public IActionResult GetProfile()
        {
            return Ok(new
            {
                Message = "You are Authenticated"
            });
        }


    }
}
