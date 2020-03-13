using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class CLientDTO
    {
        public CLientDTO(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
        public CLientDTO()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }

    }
}
