using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.ObjectsDTO.LoginDTO
{
   public class UserDTO
    {
        public UserDTO(int iD, string email, string password)
        {
            ID = iD;
            Email = email;
            Password = password;
        }
        public UserDTO()
        {
                
        }

        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
