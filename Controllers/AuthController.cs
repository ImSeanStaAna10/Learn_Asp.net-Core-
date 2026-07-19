using LoginAuthAPI.Contracts;
using LoginAuthAPI.DTO_S;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        // Constructor & Dependency Inecjtion
        public AuthController(IAuthService authService)
        {
            _authService = authService;

        }

        // Register
        [HttpPost("Register")]
        public IActionResult Register(RegisterRequestDTO request)
        {
            var response = _authService.Register(request);

            if (response.Message == "Email Already Exist")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        //Login
        [HttpPost("Login")]
        public IActionResult action(LoginRequestDTO request)
        {
            var response = _authService.Login(request);
            if (response.Message == "Invalid Email or Password")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }





    }
}
