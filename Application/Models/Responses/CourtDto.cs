using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class CourtDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public List<ReservationDto>? Reservations { get; set; }

        public static CourtDto Create(Court court)
        {
            return new CourtDto
            {
                Id = court.Id,
                Name = court.Name,
                Duration = court.Duration,
                Price = court.Price,
                Description = court.Description,
                Reservations = court.Reservations?.Select(r => ReservationDto.Create(r)).ToList() ?? new()
            };
        }
    }
}
