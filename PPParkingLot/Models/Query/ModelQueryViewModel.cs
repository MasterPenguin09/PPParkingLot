using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Query
{
    public class ModelQueryViewModel
    {
        public ModelQueryViewModel(int iD, string name, int brandID)
        {
            ID = iD;
            Name = name;
            BrandID = brandID;
        }
        public ModelQueryViewModel()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }

        [DisplayName("Brand ID")]
        public int BrandID { get; set; }
    }
}
