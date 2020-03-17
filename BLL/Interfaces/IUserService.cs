using DataTransferObject.ComplexTypes;
using DTO.ObjectsDTO.LoginDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemCommons;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<DataResponse<UserPattern>> Validate(UserDTO user);

        Task<DataResponse<UserPattern>> LookForEmployee(UserDTO user);

        Task<DataResponse<UserPattern>> LookForClient(UserDTO user);
    }
}
