using Domain.Constants;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class MyReservationsDto
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal PaidAmount { get; set; }
        public int ClientId { get; set; }
        public int CourtId { get; set; }
        public string Court { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }

        public static MyReservationsDto Create(Reservation reservation)
        {
            if (reservation == null)
                throw new Exception("Not reservation");
            return new MyReservationsDto
            {
                Id = reservation.Id,
                Date = reservation.Date,
                Time = reservation.Time,
                Status = reservation.Status.ToString(),
                TotalPrice = reservation.TotalPrice,
                PaidAmount = reservation.PaidAmount,
                ClientId = reservation.ClientId,
                CourtId = reservation.CourtId,
                Court = reservation.Court.Name,
                ClientName = reservation.Client.FullName,
                ClientPhone = reservation.Client.PhoneNumber
            };
        }
    }
}
