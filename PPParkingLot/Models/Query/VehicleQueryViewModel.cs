using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Query
{
    public class VehicleQueryViewModel
    {
        public VehicleQueryViewModel(int iD, string carBoard, string type, int modelID, bool isActive)
        {
            ID = iD;
            CarBoard = carBoard;
            Type = type;
            ModelID = modelID;
            IsActive = isActive;
        }

        public VehicleQueryViewModel()
        {

        }

        public int ID { get; set; }

        [DisplayName("Car Board")]
        public string CarBoard { get; set; }
        public string Type { get; set; }

        [DisplayName("Model ID")]
        public int ModelID { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
    }
}
