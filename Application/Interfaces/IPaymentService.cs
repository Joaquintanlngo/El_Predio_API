using Application.Models.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPaymentService
    {
        Task SaveIntentAsync(Payment intent);
        //Task ProcessWebhookAsync(string externalReference, MercadoPagoPaymentDto payment);
    }
}
