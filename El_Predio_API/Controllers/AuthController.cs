using Application.Interfaces;
using Application.Models.Request;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> Login(LoginRequest user)
        {
            var token = await _authService.Login(user);

            if (token == null)
            {
                return BadRequest();
            }

            return Ok(token);
        }
    }
}
