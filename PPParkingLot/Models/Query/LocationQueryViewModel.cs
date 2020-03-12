using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Query
{
    public class LocationQueryViewModel
    {
        public int ID { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public string PayForm { get; set; }
        public int Value { get; set; }
        public int VehicleID { get; set; }
        public int ParkingSpotID { get; set; }
        public bool IsActive { get; set; }
    }
}
