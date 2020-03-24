using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class ModelDTO
    {
        public ModelDTO(int iD, string name, int brandID)
        {
            ID = iD;
            Name = name;
            BrandID = brandID;
        }
        public ModelDTO()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }


        //public BrandDTO Brand { get; set; }
        public int BrandID { get; set; }

    }
}
