﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class DataPaymentRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string SuccessUrl { get; set; }

        public string Date { get; set; }
        public string Time { get; set; }
        public int ClientId { get; set; }
        public int CourtId { get; set; }
    }
}
