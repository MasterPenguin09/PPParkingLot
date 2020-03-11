using DataTransferObject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{

    public class LocationDTO
    {
        public LocationDTO(int iD, DateTime entryTime, DateTime? exitTime, PayForm payForm, int value, VehicleDTO vehicle, int vehicleID, ParkingSpotDTO parkingSpot, int parkingSpotID, bool isActive)
        {
            ID = iD;
            EntryTime = entryTime;
            ExitTime = exitTime;
            PayForm = payForm;
            Value = value;
            Vehicle = vehicle;
            VehicleID = vehicleID;
            ParkingSpot = parkingSpot;
            ParkingSpotID = parkingSpotID;
            IsActive = isActive;

        }
        public LocationDTO()
        {

        }

        public int ID { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public PayForm PayForm { get; set; }
        public int Value { get; set; }

        public VehicleDTO Vehicle { get; set; }
        public int VehicleID { get; set; }

        public ParkingSpotDTO ParkingSpot { get; set; }
        public int ParkingSpotID { get; set; }

        public bool IsActive { get; set; }

    }
}
