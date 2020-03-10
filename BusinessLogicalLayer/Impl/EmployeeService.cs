using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Security;
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
            return await _iEmployeeRepository.GetActives();
        }

        public async Task<DataResponse<EmployeeDTO>> GetAll()
        {
            return await _iEmployeeRepository.GetAll();

        }

        public async Task<DataResponse<EmployeeDTO>> GetByID(int employeeID)
        {
            DataResponse<EmployeeDTO> response = new DataResponse<EmployeeDTO>();
            if (employeeID < 0)
            {
                response.Errors.Add("ID funcionário inválido");
            }
            if (employeeID.Equals(null))
            {
                response.Errors.Add("ID funcionário nulo");
            }

            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iEmployeeRepository.GetByID(employeeID);
            }
        }

        public async Task<DataResponse<EmployeeDTO>> GetByName(string employeeName)
        {
            DataResponse<EmployeeDTO> response = new DataResponse<EmployeeDTO>();
            if (string.IsNullOrEmpty(employeeName))
            {
                response.Errors.Add("Nome funcionátio inválido");
            }

            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iEmployeeRepository.GetByName(employeeName);
            }
        }

        public async Task<Response> Insert(EmployeeDTO employee)
        {
            Response response = new Response();
            EmployeeValidator validate = new EmployeeValidator();
            ValidationResult result = validate.Validate(employee);
            Response password = PasswordValidator.CheckPassword(employee.Password, employee.BirthDate);

            //Verifica se a senha está dentro dos padrões, caso esteja, hasheia e ela 
            if (password.HasErrors())
            {
                response.Errors.Add(password.Errors.ToString());
            }
            else
            {
                employee.Password = HashUtils.HashPassword(employee.Password);
            }

            //result.MergeValidationErrors(response);


            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    response.Errors.Add("Property " + failure.PropertyName + " failed validation. Error was: " + "(" + failure.ErrorMessage + ")");
                }

                return response;
            }

            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iEmployeeRepository.Insert(employee);
            }

        }

        public async Task<Response> Update(EmployeeDTO employee)
        {
            Response response = new Response();
            EmployeeValidator validate = new EmployeeValidator();
            ValidationResult result = validate.Validate(employee);
            Response password = PasswordValidator.CheckPassword(employee.Password, employee.BirthDate);

            //Verifica se a senha está dentro dos padrões, caso esteja, hasheia e ela 
            if (password.HasErrors())
            {
                response.Errors.Add(password.Errors.ToString());
            }
            else
            {
                employee.Password = HashUtils.HashPassword(employee.Password);
            }

            //result.MergeValidationErrors(response);


            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    response.Errors.Add("Property " + failure.PropertyName + " failed validation. Error was: " + "(" + failure.ErrorMessage + ")");
                }

                return response;
            }

            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iEmployeeRepository.Update(employee);
            }
        }
    }
}
