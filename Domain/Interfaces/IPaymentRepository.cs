using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPaymentRepository : IBaseRepository<Payment>
    {
        Task<Payment> CreateAsync(Payment payment);
        Task<Payment?> GetByExternalReferenceAsync(string externalReference);
        Task UpdateAsync(Payment payment);
    }
}
