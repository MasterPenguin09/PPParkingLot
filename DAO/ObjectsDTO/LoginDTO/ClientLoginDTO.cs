﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ClientLoginDTO
    {
        public ClientLoginDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public ClientLoginDTO()
        {

        }

        public string Email { get; set; }
        public string Password { get; set; } 
    }
}
