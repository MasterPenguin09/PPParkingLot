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
        public virtual BrandDTO Brand { get; set; }
        public virtual ModelDTO Model { get; set; }

    }
}
