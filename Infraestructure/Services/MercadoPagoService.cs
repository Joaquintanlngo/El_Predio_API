using Application.Interfaces;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MercadoPagoService : IMercadoPagoService
    {
        private readonly string _accessToken;

        public MercadoPagoService(IConfiguration configuration)
        {
            _accessToken = configuration["MercadoPago:AccessToken"];
            MercadoPagoConfig.AccessToken = _accessToken;
        }

        public async Task<string> CreatePaymentAsync(decimal price, string title, string successUrl)
        {
            var client = new PreferenceClient();
            var request = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest> {
                    new PreferenceItemRequest {
                        Title = title,
                        Quantity = 1,
                        UnitPrice = price,
                    }

                },
                BackUrls = new PreferenceBackUrlsRequest { Success = successUrl },
                AutoReturn = "approved"
            };

            Preference preference = await client.CreateAsync(request);
            return preference.InitPoint;
        }
    }
}
