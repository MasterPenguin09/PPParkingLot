using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Query
{
    public class VehicleQueryViewModel
    {
        public int ID { get; set; }
        // public int IDCliente { get; set; }
        public string CarBoard { get; set; }
        public string Type { get; set; }
        public int ModelID { get; set; }
        public bool IsActive { get; set; }
    }
}
