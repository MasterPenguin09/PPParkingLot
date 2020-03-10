using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Validators;
using Common.FlowControl;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using FluentValidation.Results;
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

        public async Task<Response> Delete(int idEmployee)
        {
            Response response = new Response();
            if (idEmployee < 0)
            {
                response.Errors.Add("ID Inválido!");
            }
            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iEmployeeRepository.Delete(idEmployee);
            }
        }

        public async Task<Response> Disable(int idEmployee)
        {
            Response response = new Response();
            if (idEmployee < 0)
            {
                response.Errors.Add("ID Inválido!");
            }
            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iEmployeeRepository.Disable(idEmployee);
            }
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
