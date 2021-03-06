﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentingAppKnorish.Models
{
    public class Boat
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Boat Name")]
        public string BoatName { get; set; }
        [Required]
        [DisplayName("Hourly Rate")]
        public int HourlyRate { get; set; }

        public string BoatNumber { get; set; }
        public string CustomerName { get; set; }
     
    }
}
