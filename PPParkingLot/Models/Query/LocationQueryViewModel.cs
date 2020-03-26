using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Query
{
    public class LocationQueryViewModel
    {
        public LocationQueryViewModel(int iD, DateTime entryTime, DateTime? exitTime, string payForm, int value, int vehicleID, int parkingSpotID, bool isActive)
        {
            ID = iD;
            EntryTime = entryTime;
            ExitTime = exitTime;
            PayForm = payForm;
            Value = value;
            VehicleID = vehicleID;
            ParkingSpotID = parkingSpotID;
            IsActive = isActive;
        }

        public LocationQueryViewModel()
        {

        }

        public int ID { get; set; }

        [DisplayName("Entry Time")]
        public DateTime EntryTime { get; set; }

        [DisplayName("Exit Time")]
        public DateTime? ExitTime { get; set; }

        [DisplayName("Pay Form")]
        public string PayForm { get; set; }
        public int Value { get; set; }

        [DisplayName("Vehicle ID")]
        public int VehicleID { get; set; }

        [DisplayName("Parking Spot ID")]
        public int ParkingSpotID { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}
