using Application.Interfaces;
using Application.Models.Request;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Extensions;

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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetReservationByCourtDayTime(int courtId, string date, string time)
        {
            try
            {
                var reservation = await _reservationService.GetReservationByCourtDayTime(courtId, DateOnly.Parse(date), TimeSpan.Parse(time));
                return Ok(reservation.Id);
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
        public async Task<IActionResult> GetAllReservationForCourtOfDay(int courtId, string date)
        {
            try
            {
                return Ok(await _reservationService.GetAllReservationForCourtOfDay(courtId, date));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetMyReservation(string status)
        {
            try
            {
                return Ok(await _reservationService.GetMyReservation(User.GetUserIntId(), status));
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

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteReservationPending(int courtId, string date, string time)
        {
            try
            {
                await _reservationService.DeleteReservationPending(courtId, DateOnly.Parse(date), TimeSpan.Parse(time));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
