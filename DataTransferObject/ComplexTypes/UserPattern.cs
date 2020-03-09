using DataTransferObject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.ComplexTypes
{
   public class UserPattern
    {
      
            public UserPattern(int id, string name, string cPF, string number, DateTime birthDate, string password, string email, DateTime systemEntranceDate, DateTime systemExitDate, EAccessLevel accessLevel, bool isActive)
            {
                ID = id;
                Name = name;
                CPF = cPF;
                Number = number;
                BirthDate = birthDate;
                Password = password;
                Email = email;
                SystemEntranceDate = systemEntranceDate;
                SystemExitDate = systemExitDate;
                AccessLevel = accessLevel;
                IsActive = isActive;
            }

            public UserPattern() { }

            public int ID { get; set; }
            public string Name { get; set; }
            public string CPF { get; set; }
            public string Number { get; set; }
            public DateTime BirthDate { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public DateTime SystemEntranceDate { get; set; }
            public DateTime SystemExitDate { get; set; }
            public EAccessLevel AccessLevel { get; set; }
            public bool IsActive { get; set; }
    }
}
