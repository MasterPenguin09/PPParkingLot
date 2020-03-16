using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Login
{
    public class EmployeeLoginViewModel
    {
        public EmployeeLoginViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public EmployeeLoginViewModel()
        {

        }

        public string Email { get; set; }
        public string Password { get; set; }


    }
}
