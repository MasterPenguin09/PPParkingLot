using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Insert
{
    public class LocationInsertViewModel
    {

        public DateTime EntryTime { get; set; }


        public DateTime? ExitTime { get; set; }

        public String PayForm { get; set; }

        public int Value { get; set; }


        public int ClientID { get; set; }



        public int VehicleID { get; set; }


        public String ParkingSpot { get; set; }


        public int ParkingSpotID { get; set; }
    }
}
