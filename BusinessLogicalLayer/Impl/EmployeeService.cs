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

        public async Task<Response> Delete(EmployeeDTO employee)
        {
            Response response = new Response();
            EmployeeValidator validate = new EmployeeValidator();
            ValidationResult result = validate.Validate(employee);

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    response.Errors.Add("Property " + failure.PropertyName + " failed validation. Error was: " + "(" + failure.ErrorMessage + ")");
                }

                return response;
            }
            else
            {
                return await _iEmployeeRepository.Delete(employee);
            }
        }

        public async Task<Response> Disable(EmployeeDTO employee)
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
