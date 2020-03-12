using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Query
{
    public class ParkingSpotQueryViewModel
    {

        public int ID { get; set; }
        public double ValuePerHour { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
    }
}
