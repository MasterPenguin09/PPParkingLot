using Common.FlowControl;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories_EFCore_
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<Response> Delete(int idEmployee)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Disable(int idEmployee)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<EmployeeDTO>> GetActives()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<EmployeeDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<EmployeeDTO>> GetByID(int employeeID)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<EmployeeDTO>> GetByName(string employeeName)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Insert(EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Update(EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }
    }
}
