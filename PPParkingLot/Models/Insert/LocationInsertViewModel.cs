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
        public LocationInsertViewModel(DateTime entryTime, DateTime? exitTime, string payForm, int value, int vehicleID, int parkingSpotID)
        {
            EntryTime = entryTime;
            ExitTime = exitTime;
            PayForm = payForm;
            Value = value;
            VehicleID = vehicleID;
            ParkingSpotID = parkingSpotID;
        }
        public LocationInsertViewModel()
        {

        }

        [DisplayName("Entry Time")]
        public DateTime EntryTime { get; set; }


        [DisplayName("Exit Time")]
        public DateTime? ExitTime { get; set; }

        [DisplayName("Pay Form")]
        [Required(ErrorMessage = "The payment form must be informed")]
        public String PayForm { get; set; }

        [Required(ErrorMessage = "Value is required")]
        public int Value { get; set; }


        [Required(ErrorMessage = "Vehicle ID must be informed")]
        public int VehicleID { get; set; }


        [DisplayName("Parking Spot ID")]
        [Required(ErrorMessage = "Parking Spot ID must be informed")]
        public int ParkingSpotID { get; set; }
    }
}
