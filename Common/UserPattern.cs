using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class UserPattern
    {
        public UserPattern(int id, string name, string cPF, string number, DateTime birthDate, string passWord, string email, DateTime systemEntranceDate, DateTime systemExitDate, EAccessLevel accessLevel, bool isActive)
        {
            ID = id;
            Name = name;
            CPF = cPF;
            Number = number;
            BirthDate = birthDate;
            PassWord = passWord;
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
        public string PassWord { get; set; }
        public string Email { get; set; }
        public DateTime SystemEntranceDate { get; set; }
        public DateTime SystemExitDate { get; set; }
        public EAccessLevel AccessLevel { get; set; }
        public bool IsActive { get; set; }
    }
}
