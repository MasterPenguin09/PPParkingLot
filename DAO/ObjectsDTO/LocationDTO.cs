﻿using DataTransferObject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{

    public class LocationDTO
    {

        public LocationDTO(int iD, DateTime entryTime, DateTime? exitTime, PayForm payForm, double value, int clientID, int vehicleID, int parkingSpotID, bool isActive)
        {
            ID = iD;
            EntryTime = entryTime;
            ExitTime = exitTime;
            PayForm = payForm;
            Value = value;
            ClientID = clientID;
            VehicleID = vehicleID;
            ParkingSpotID = parkingSpotID;
            IsActive = isActive;
        }

        public LocationDTO()
        {

        }

        [Key]
        public int ID { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public PayForm PayForm { get; set; }
        public double Value { get; set; }

        public ClientDTO Client { get; set; }
        public int ClientID { get; set; }

        public VehicleDTO Vehicle { get; set; }
        public int VehicleID { get; set; }

        public ParkingSpotDTO ParkingSpot { get; set; }
        public int ParkingSpotID { get; set; }

        public bool IsActive { get; set; }

    }
}
