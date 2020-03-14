using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.ObjectsDTO.LoginDTO
{
    public class EmployeeLoginDTO
    {
        public EmployeeLoginDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public EmployeeLoginDTO()
        {

        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
