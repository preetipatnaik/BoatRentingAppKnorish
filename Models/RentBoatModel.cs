using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentingAppKnorish.Models
{
    public class RentBoatModel
    {
        [Required]
        [DisplayName("Boat Number")]
        public string BoatNumber { get; set; }

        [Required]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
    }
}
