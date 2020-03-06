using Common;
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
        public int ID { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public PayForm PayForm { get; set; }
        public int Value { get; set; }

        //
        public VehicleDTO Vehicle { get; set; }
        public int VehicleID { get; set; }




    }
}
