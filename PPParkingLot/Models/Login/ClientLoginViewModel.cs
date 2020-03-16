﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Login
{
    public class ClientLoginViewModel
    {
        public ClientLoginViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public ClientLoginViewModel()
        {
                
        }

        public string Email { get; set; }
        public string Password { get; set; }

    }
}
