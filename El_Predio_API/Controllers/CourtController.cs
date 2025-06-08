using Application.Interfaces;
using Application.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtController : ControllerBase
    {
        private readonly ICourtService _courtService;

        public CourtController(ICourtService courtService)
        {
            _courtService = courtService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _courtService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(int id)
        {
            var court = await _courtService.GetById(id);
            if (court == null) return NotFound();
            return Ok(court);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CourtRequest request)
        {
            return Ok(await _courtService.Create(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(CourtUpdateRequest request)
        {
            return Ok(await _courtService.Update(request));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _courtService.Delete(id));
        }

    }
}
