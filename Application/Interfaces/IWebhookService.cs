using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWebhookService
    {
        Task HandlePaymentNotificationAsync(string json, Dictionary<string, string> queryParams, Dictionary<string, string> headers);
    }
}
