using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class PaymentInfo
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public string ExternalReference { get; set; }
    }
}
