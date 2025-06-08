using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class CourtRequest
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
    }
}
