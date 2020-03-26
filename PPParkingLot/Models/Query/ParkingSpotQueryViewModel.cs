using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Query
{
    public class ParkingSpotQueryViewModel
    {
        public ParkingSpotQueryViewModel(int iD, double valuePerHour, string type, bool isActive)
        {
            ID = iD;
            ValuePerHour = valuePerHour;
            Type = type;
            IsActive = isActive;
        }
        public ParkingSpotQueryViewModel()
        {

        }

        public int ID { get; set; }

        [DisplayName("Hour Price")]
        public double ValuePerHour { get; set; }
        public string Type { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}
