using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class BrandDTO
    {
        public BrandDTO(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
        public BrandDTO()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }

    }
}
