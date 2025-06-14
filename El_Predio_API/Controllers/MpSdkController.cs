using Application.Interfaces;
using Application.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prueba_sdk_mp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MpSdkController : ControllerBase
    {
        private readonly IMercadoPagoPayment _mercadoPagoPayment;

        public MpSdkController(IMercadoPagoPayment mercadoPagoPayment)
        {
            _mercadoPagoPayment = mercadoPagoPayment;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePayment([FromBody] DataPaymentRequest data)
        {
            var url = await _mercadoPagoPayment.CreatePaymentAsync(data.Price, data.Title, data.SuccessUrl);
            Console.WriteLine(url);
            return Ok(new {url = url });
        }


    }
}
