using BLL.Interfaces;
using BusinessLogicalLayer.Interfaces;
using DataTransferObject;
using DTO.ObjectsDTO.LoginDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemCommons;

namespace BLL.Impl
{
    class UserService : IUserService
    {
        private IClientService _clientSrvc;
        private IEmployeeService _employeeSrvc;


        public UserService(IClientService clientService, IEmployeeService employeeService)
        {
            this._clientSrvc = clientService;
            this._employeeSrvc = employeeService;
        }

        public async Task<DataResponse<ob>> Validate(UserDTO user)
        {
      
            DataResponse<ClientDTO> clientDataResponse = new DataResponse<ClientDTO>();
            DataResponse<EmployeeDTO> employeeDataResponse = new DataResponse<EmployeeDTO>();

            clientDataResponse = await _clientSrvc.Login(user.Email, user.Password);


            if (clientDataResponse.Success)
            {
                return clientDataResponse;
            }
            else
            {
                employeeDataResponse = await _employeeSrvc.Login(user.Email, user.Password);
            }
            if (employeeDataResponse.Success)
            {

                return employeeDataResponse;

            }
            else
            {

            }
        }
    }
}
