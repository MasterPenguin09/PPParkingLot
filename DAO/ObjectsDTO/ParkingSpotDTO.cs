using DataTransferObject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class ParkingSpotDTO
    {
        public ParkingSpotDTO(int iD, double valuePerHour, EParkSpotType type, bool isActive)
        {
            ID = iD;
            ValuePerHour = valuePerHour;
            Type = type;
            IsActive = isActive;
        }

        public ParkingSpotDTO()
        {
             
        }
        [Key]
        public int ID { get; set; }

        public double ValuePerHour { get; set; }

        public EParkSpotType Type { get; set; }

        public bool IsActive { get; set; }
    }
}
