using DataTransferObject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
   public class VehicleDTO
    {
        public VehicleDTO(int iD, string carBoard, EVehicleType type, int modelID, bool isActive)
        {
            ID = iD;
            CarBoard = carBoard;
            Type = type;
            ModelID = modelID;
            IsActive = isActive;
        }
        public VehicleDTO()
        {

        }
        [Key]
        public int ID { get; set; }

        public string CarBoard { get; set; }

        public EVehicleType Type { get; set; }

        public bool IsActive { get; set; }

        public ModelDTO Model { get; set; }
        public int ModelID { get; set; }
    }
}
