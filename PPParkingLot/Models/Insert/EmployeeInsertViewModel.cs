using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Insert
{
    public class EmployeeInsertViewModel
    {
        public EmployeeInsertViewModel(string name, string cPF, string number, DateTime birthDate, string password, string email, DateTime systemEntranceDate, DateTime? systemExitDate, string accessLevel, double wage)
        {
            Name = name;
            CPF = cPF;
            Number = number;
            BirthDate = birthDate;
            Password = password;
            Email = email;
            SystemEntranceDate = systemEntranceDate;
            SystemExitDate = systemExitDate;
            AccessLevel = accessLevel;
            Wage = wage;
        }

        public EmployeeInsertViewModel()
        {

        }

        [Required(ErrorMessage = "O nome deve ser informado")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "O nome deve conter 3 e 200 caracteres")]
        public string Name { get; set; }


      
        [Required(ErrorMessage = "O CPF deve ser informado")]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 caracteres")]
        public string CPF { get; set; }


 
        [Required(ErrorMessage = "O Telefone deve ser informado")]
        [StringLength(maximumLength: 19, MinimumLength = 6, ErrorMessage = "O telefone deve conter entre 6 á 19 caracteres")]
        public string Number { get; set; }


        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }


   
        [Required(ErrorMessage = "A senha deve ser informado")]
        public string Password { get; set; }



        [Required(ErrorMessage = "O Email deve ser informado")]
        public string Email { get; set; }


        [DisplayName("System Entrance Date")]
        public DateTime SystemEntranceDate { get; set; }


        [DisplayName("System Exit Date")]
        public DateTime? SystemExitDate { get; set; }

        [DisplayName("Position")]
        public string AccessLevel { get; set; }

        [DisplayName("Wage")]
        [Required(ErrorMessage = "O Salario deve ser informado")]
        public double Wage { get; set; }
    }
}
