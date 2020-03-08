using DataTransferObject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
   public class VehicleRepository
    {
        public int ID { get; set; }
       // public int IDCliente { get; set; }
        public string CarBoard { get; set; }
        public EVehicleType Type { get; set; }
        public ModelRepository Model { get; set; }
        public int ModelID { get; set; }

    }
}
