using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class ModelDTO
    {
        public ModelDTO(int iD, string name, BrandDTO brandDTO, int brandID)
        {
            ID = iD;
            Name = name;
            BrandDTO = brandDTO;
            BrandID = brandID;
        }
        public ModelDTO()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }


        public BrandDTO BrandDTO { get; set; }
        public int BrandID { get; set; }

    }
}
