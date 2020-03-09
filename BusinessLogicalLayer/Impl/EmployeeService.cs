using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces_EFCore_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Impl
{
   public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _iEmployeeRepository;
        public EmployeeService(IEmployeeRepository iEmployeeRep)
        {
            this._iEmployeeRepository = iEmployeeRep;
        }
    }
}
