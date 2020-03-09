using BusinessLogicalLayer.Interfaces;
using Common.FlowControl;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
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

        public Task<Response> Delete(EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Disable(EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<EmployeeDTO>> GetActives()
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<EmployeeDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<EmployeeDTO>> GetByID(int employeeID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<EmployeeDTO>> GetByName(string employeeName)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Insert(EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }
    }
}
