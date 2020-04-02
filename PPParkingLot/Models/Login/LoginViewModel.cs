using DataTransferObject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Login
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {

        }

        public LoginViewModel(int iD, string name, string email, EAccessLevel level)
        {
            ID = iD;
            Name = name;
            Email = email;
            Level = level;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public EAccessLevel Level { get; set; }

    }
}
