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
        private readonly IWebhookService _webhookService;

        public MercadoPagoController(IMercadoPagoService mercadoPagoPayment, IWebhookService webhookService)
        {
            _mercadoPagoPayment = mercadoPagoPayment;
            _webhookService = webhookService;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePayment([FromBody] DataPaymentRequest data)
        {
            try
            {
                var url = await _mercadoPagoPayment.CreatePaymentAsync(data.Price, data.Title, data.SuccessUrl, data.Date, data.Time, data.ClientId, data.CourtId);
                return Ok(new { url = url });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> ReceiveWebhook()
        {
            using var reader = new StreamReader(Request.Body);
            var json = await reader.ReadToEndAsync();

            var queryParams = Request.Query.ToDictionary(k => k.Key, v => v.Value.ToString());
            var headers = Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());


            await _webhookService.HandlePaymentNotificationAsync(json, queryParams, headers);

            return Ok(); // devolvemos 200 para que no reintente
        }
    }
}
