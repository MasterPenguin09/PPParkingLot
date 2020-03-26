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
       

        public EmployeeInsertViewModel()
        {

        }

        public EmployeeInsertViewModel(string name, string cPF, string number, DateTime birthDate, string email, string accessLevel, double wage, string password, string confirmPassword)
        {
            Name = name;
            CPF = cPF;
            Number = number;
            BirthDate = birthDate;
            Email = email;
            AccessLevel = accessLevel;
            Wage = wage;
            Password = password;
            ConfirmPassword = confirmPassword;
        }


        [Required(ErrorMessage = "O nome deve ser informado")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "The name must be between 3 and 200 characteres")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Invalid name")]
        public string Name { get; set; }


      
        [Required(ErrorMessage = "O CPF deve ser informado")]
        [StringLength(maximumLength: 14, MinimumLength = 14, ErrorMessage = " CPF must be 14 characteres")]
        public string CPF { get; set; }


 
        [Required(ErrorMessage = "Telephone is required")]
        [StringLength(maximumLength: 19, MinimumLength = 6, ErrorMessage = "O telefone deve conter entre 6 á 19 caracteres")]
        public string Number { get; set; }


        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "O Email deve ser informado")]
        [RegularExpression(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [DisplayName("Position")]
        public string AccessLevel { get; set; }

        [DisplayName("Wage")]
        [Required(ErrorMessage = "Wage is required")]
        public double Wage { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Confirm")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
