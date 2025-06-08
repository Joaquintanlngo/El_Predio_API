using Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class ReservationRequest
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public int ClientId { get; set; }
        public int CourtId { get; set; }
    }
}
