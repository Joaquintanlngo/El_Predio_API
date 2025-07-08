using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string ExternalReference { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = "Pending"; // "Pending", "Approved", "Rejected"

        public string Name { get; set; }
        public string Email { get; set; }

        public int CourtId { get; set; }
        public int ClientId { get; set; }

        public DateOnly Date { get; set; }
        public TimeSpan Time { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
