using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Query
{
    public class BrandQueryViewModel
    {
        public BrandQueryViewModel(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
        public BrandQueryViewModel()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }

    }
}
