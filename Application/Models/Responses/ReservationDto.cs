using Domain.Constants;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Status { get; set; }
        public int ClientId { get; set; }
        public int CourtId { get; set; }
        public string Court { get; set; }
        public ClientDto Client { get; set; }

        public static ReservationDto Create(Reservation reservation)
        {
            if (reservation == null)
                throw new Exception("Not reservation");
                return new ReservationDto
            {
                Id = reservation.Id,
                Date = reservation.Date,
                Time = reservation.Time,
                Status = reservation.Status.ToString(),
                ClientId = reservation.ClientId,
                CourtId = reservation.CourtId,
                Court = reservation.Court.Name,
                Client = ClientDto.Create(reservation.Client)
            };
        }
    }
}
