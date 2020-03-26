using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Insert
{
    public class ParkingSpotInsertViewModel
    {
        public ParkingSpotInsertViewModel(double valuePerHour, string type)
        {
            ValuePerHour = valuePerHour;
            Type = type;
        }
        public ParkingSpotInsertViewModel()
        {

        }

        [DisplayName("Hour Price")]
        [Required(ErrorMessage = "Hour price is required")]
        public double ValuePerHour { get; set; }

     
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }
    }
}
