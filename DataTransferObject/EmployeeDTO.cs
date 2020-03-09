using DataTransferObject.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class EmployeeDTO : UserPattern
    {
        public EmployeeDTO(double wage)
        {
            Wage = wage;
        }
        public EmployeeDTO()
        {

        }

        public double Wage { get; set; }
    }
}
