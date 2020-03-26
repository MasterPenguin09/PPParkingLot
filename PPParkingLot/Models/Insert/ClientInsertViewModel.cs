using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Insert
{
    public class ClientInsertViewModel
    {
        public ClientInsertViewModel(string name, string cPF, string number, DateTime birthDate, string email, string password, string confirmPassword)
        {
            Name = name;
            CPF = cPF;
            Number = number;
            BirthDate = birthDate;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public ClientInsertViewModel()
        {

        }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "The name must be between 3 and 200 characteres")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Invalid name")]
        public string Name { get; set; }



        [Required(ErrorMessage = "CPF is required")]
        [StringLength(maximumLength: 14, MinimumLength = 14, ErrorMessage = " CPF must be 14 characteres")]
        public string CPF { get; set; }


        [Required(ErrorMessage = "Number is required")]
        [StringLength(maximumLength: 19, MinimumLength = 6, ErrorMessage = "Invalid number")]
        public string Number { get; set; }


        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime BirthDate { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$", ErrorMessage ="Invalid Email")]
        public string Email { get; set; }


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
