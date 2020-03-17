using AutoMapper;
using BLL.Interfaces;
using BusinessLogicalLayer.Interfaces;
using DataTransferObject;
using DataTransferObject.ComplexTypes;
using DTO.ObjectsDTO.LoginDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemCommons;

namespace BLL.Impl
{
   public class UserService : IUserService
    {
        private IClientService _clientSrvc;
        private IEmployeeService _employeeSrvc;


        public UserService(IClientService clientService, IEmployeeService employeeService)
        {
            this._clientSrvc = clientService;
            this._employeeSrvc = employeeService;
        }

        public async Task<DataResponse<UserPattern>> Validate(UserDTO user)
        {
            DataResponse<UserPattern> loggedUserIsClient, loggedUserIsEmployee, dataResponse = new DataResponse<UserPattern>();

             loggedUserIsClient = await LookForClient(user);

            
            if (loggedUserIsClient.Success)
            {
                return loggedUserIsClient;
            }
            else
            {
                loggedUserIsEmployee = await LookForEmployee(user);

                if (loggedUserIsEmployee.Success)
                {
                    return loggedUserIsEmployee;
                }
                dataResponse.Errors.Add("Usuário não encontrado");
                return dataResponse;
            }
        }

        public async Task<DataResponse<UserPattern>> LookForEmployee(UserDTO user)
        {
            DataResponse<UserPattern> loggedUser = new DataResponse<UserPattern>();

            DataResponse<EmployeeDTO> employeeDataResponse = new DataResponse<EmployeeDTO>();
            employeeDataResponse = await _employeeSrvc.Login(user.Email, user.Password);

            if (employeeDataResponse.Success)
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EmployeeDTO, UserPattern>();
                });

                IMapper mapper = configuration.CreateMapper();
                loggedUser.Data.Add(mapper.Map<UserPattern>(employeeDataResponse.Data[0]));

                loggedUser.Success = true;
                return loggedUser;
            }
            return loggedUser;
        }

        public async Task<DataResponse<UserPattern>> LookForClient(UserDTO user)
        {
            DataResponse<UserPattern> loggedUser = new DataResponse<UserPattern>();


            DataResponse<ClientDTO> clientDataResponse = new DataResponse<ClientDTO>();
            clientDataResponse = await _clientSrvc.Login(user.Email, user.Password);

            if (clientDataResponse.Success)
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ClientDTO, UserPattern>();
                });

                IMapper mapper = configuration.CreateMapper();
                loggedUser.Data.Add(mapper.Map<UserPattern>(clientDataResponse.Data[0]));

                loggedUser.Success = true;
                return loggedUser;
            }
            return loggedUser;
        }
    }
}



