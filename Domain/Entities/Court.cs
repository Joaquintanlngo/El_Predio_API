using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Court
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }

        public List<Reservation>? Reservations { get; set; }
    }
}
