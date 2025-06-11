using Application.Interfaces;
using Application.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _reservationService.GetAllReservation());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[action]/Filter-For-Today")]
        public async Task<IActionResult> GetAllReservationDay()
        {
            try
            {
                return Ok(await _reservationService.GetAllReservationForToDay());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/Filter-For-Day")]
        public async Task<IActionResult> GetAllReservation(string date)
        {
            try
            {
                return Ok(await _reservationService.GetAllReservationForDay(DateOnly.Parse(date)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllReservationForCourt(string courtName)
        {
            try
            {
                return Ok(await _reservationService.GetAllReservationForCourt(courtName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/Filter-For-Court-Of-Today")]
        public async Task<IActionResult> GetAllReservationForCourtOfToday(int courtId)
        {
            try
            {
                return Ok(await _reservationService.GetAllReservationForCourtOfToday(courtId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(ReservationRequest request)
        {
            try
            {
                return Ok(await _reservationService.CreateReservation(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int reservationId)
        {
            try
            {
                return Ok(await _reservationService.DeleteReservation(reservationId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
