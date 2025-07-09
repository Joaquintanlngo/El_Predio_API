using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMercadoPagoService
    {
        Task<string> CreatePaymentAsync(decimal price, string title, string successUrl);
    }
}
