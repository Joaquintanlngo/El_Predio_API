using Application.Interfaces;
using Application.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercadoPagoController : ControllerBase
    {
        private readonly IMercadoPagoService _mercadoPagoPayment;

        public MercadoPagoController(IMercadoPagoService mercadoPagoPayment)
        {
            _mercadoPagoPayment = mercadoPagoPayment;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePayment([FromBody] DataPaymentRequest data)
        {
            var url = await _mercadoPagoPayment.CreatePaymentAsync(data.Price, data.Title, data.SuccessUrl);
            Console.WriteLine(url);
            return Ok(new { url = url });
        }
    }
}
