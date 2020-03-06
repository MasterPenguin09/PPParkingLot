using DataTransferObject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
   public class VehicleDTO
    {
        public int ID { get; set; }
       // public int IDCliente { get; set; }
        public string CarBoard { get; set; }
        public EVehicleType Type { get; set; }
        public ModelDTO Model { get; set; }
        public int ModelID { get; set; }

    }
}
