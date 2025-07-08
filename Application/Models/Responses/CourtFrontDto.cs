using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class CourtFrontDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<ReservationDto>? Reservations { get; set; }

        public static CourtFrontDto Create(Court court)
        {
            return new CourtFrontDto
            {
                Id = court.Id,
                Name = court.Name,
                Duration = court.Duration,
                Price = court.Price,
                Description = court.Description,
                Category = court.Category,
                Reservations = court.Reservations?.Select(r => ReservationDto.Create(r)).ToList() ?? new()
            };
        }
    }
}
