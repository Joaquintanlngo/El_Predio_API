using Application.Interfaces;
using Application.Models.Request;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Web.Extensions;

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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserById()
        {
            try
            {
                return Ok(await _authService.GetUserById(User.GetUserIntId()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            try
            {
                return Ok(await _authService.CreateUser(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest request)
        {
            try
            {
                await _authService.UpdateUser(User.GetUserIntId(), request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
                await _authService.DeleteUser(User.GetUserIntId());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
