using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class GetReservationDto
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan Time { get; set; }
        public int CourtId { get; set; }

        public static GetReservationDto Create(Reservation reservation)
        {
            if (reservation == null)
                throw new Exception("Not reservation");
            return new GetReservationDto
            {
                Id = reservation.Id,
                Date = reservation.Date,
                Time = reservation.Time,
                CourtId = reservation.CourtId,
            };
        }
    }
}
