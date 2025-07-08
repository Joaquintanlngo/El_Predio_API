using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        private readonly ApplicationContext _context;

        public PaymentRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Payment> CreateAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment?> GetByExternalReferenceAsync(string externalReference)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.ExternalReference == externalReference);
        }

        public async Task UpdateAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }
    }
}
