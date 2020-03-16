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
        Task<DataResponse<object>> Validate(UserDTO user);
    }
}
