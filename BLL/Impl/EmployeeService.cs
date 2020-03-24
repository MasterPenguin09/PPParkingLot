using BLL.Log4net;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Security;
using BusinessLogicalLayer.Validators;

using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using DTO.ObjectsDTO.LoginDTO;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCommons;

namespace BusinessLogicalLayer.Impl
{
    public class EmployeeService : Log4Net_AssemblyInfo, IEmployeeService
    {
        /// <summary>
        /// É uma classe publica que herda de uma interface interna de mesmo nome (+I no começo)
        /// Sua função é trazer os serviços do Employee ligadas a logica dos negocios, com auxilio de
        /// uma interface privada que traz as regras do Banco de Dados ligada a Employee
        /// </summary>

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
                try
                {
                    return response = await _iEmployeeRepository.Delete(idEmployee);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    return response;
                }
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
                try
                {
                    return response = await _iEmployeeRepository.Disable(idEmployee);

                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    return response;
                }
            }
        }

        public async Task<DataResponse<EmployeeDTO>> GetActives()
        {
            DataResponse<EmployeeDTO> response = new DataResponse<EmployeeDTO>();
            try
            {
                return response = await _iEmployeeRepository.GetActives();
            }
            catch (Exception ex)
            {
                _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                return response;
            }
        }

        public async Task<DataResponse<EmployeeDTO>> GetAll()
        {
            DataResponse<EmployeeDTO> response = new DataResponse<EmployeeDTO>();
            try
            {
                return response = await _iEmployeeRepository.GetAll();
            }
            catch (Exception ex)
            {
                _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                return response;
            }

        }

        public async Task<DataResponse<EmployeeDTO>> GetByEmail(string emailEmployee)
        {
            DataResponse<EmployeeDTO> response = new DataResponse<EmployeeDTO>();
            if (string.IsNullOrEmpty(emailEmployee))
            {
                response.Errors.Add("Email funcionário inválido");
            }
            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                try
                {
                    return response = await _iEmployeeRepository.GetByEmail(emailEmployee);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    return response;
                }
            }
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
                try
                {
                    return response = await _iEmployeeRepository.GetByID(employeeID);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    return response;
                }
            }
        }

        public async Task<DataResponse<EmployeeDTO>> GetByName(string employeeName)
        {
            DataResponse<EmployeeDTO> response = new DataResponse<EmployeeDTO>();
            if (string.IsNullOrEmpty(employeeName))
            {
                response.Errors.Add("Nome funcionário inválido");
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
                try
                {
                    employee.SystemEntranceDate = DateTime.Now;
                    employee.IsActive = true;

                    return response = await _iEmployeeRepository.Insert(employee);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    return response;
                }
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
                try
                {
                    return response = await _iEmployeeRepository.Update(employee);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    return response;
                }
            }
        }

        public async Task<DataResponse<EmployeeDTO>> Login(string email, string password)
        {
            DataResponse<EmployeeDTO> response = new DataResponse<EmployeeDTO>();

            if (string.IsNullOrEmpty(email))
            {
                response.Errors.Add("Email inválido");
                return response;
            }
            else
            {
                response = await GetByEmail(email);

                if (response.Success)
                {
                    EmployeeDTO emp = response.Data[0];
                    if (HashUtils.HashPassword(password).Equals(emp.Password))
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Senha inválida");
                        response.Success = false;
                        return response;
                    }
                }
                return response;
            }
        }
    }
}
