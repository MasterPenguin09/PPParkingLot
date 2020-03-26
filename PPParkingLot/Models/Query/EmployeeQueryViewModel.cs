using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Query
{
    public class EmployeeQueryViewModel
    {
        public EmployeeQueryViewModel(int iD, string name, string cPF, string number, DateTime birthDate, string email, DateTime systemEntranceDate, DateTime? systemExitDate, string accessLevel, bool isActive, double wage)
        {
            ID = iD;
            Name = name;
            CPF = cPF;
            Number = number;
            BirthDate = birthDate;
            Email = email;
            SystemEntranceDate = systemEntranceDate;
            SystemExitDate = systemExitDate;
            AccessLevel = accessLevel;
            IsActive = isActive;
            Wage = wage;
        }
        public EmployeeQueryViewModel()
        {

        }
        public int ID { get; set; }

        public string Name { get; set; }

        public string CPF { get; set; }

        public string Number { get; set; }

        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }

        [DisplayName("System Entrance Date")]
        public DateTime SystemEntranceDate { get; set; }

        [DisplayName("System Exit Date")]
        public DateTime? SystemExitDate { get; set; }

        [DisplayName("Position")]
        public string AccessLevel { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        public double Wage { get; set; }

    }
}
