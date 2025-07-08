using Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan Time { get; set; }
        public StatusEnum Status { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ClientId { get; set; }
        public int CourtId { get; set; }
        public Client Client { get; set; }
        public Court Court { get; set; }
    }
}
