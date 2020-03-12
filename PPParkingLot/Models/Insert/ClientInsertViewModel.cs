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
        [DisplayName("Name")]
        [Required(ErrorMessage = "O nome deve ser informado")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "O nome deve conter 3 e 200 caracteres")]
        public string Name { get; set; }


        [DisplayName("CPF")]
        [Required(ErrorMessage = "O CPF deve ser informado")]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 caracteres")]
        public string CPF { get; set; }


        [DisplayName("Number")]
        [Required(ErrorMessage = "O Telefone deve ser informado")]
        [StringLength(maximumLength: 19, MinimumLength = 6, ErrorMessage = "O telefone deve conter entre 6 á 19 caracteres")]
        public string Number { get; set; }


        [DisplayName("BirthDate")]
        public DateTime BirthDate { get; set; }


        [DisplayName("Password")]
        [Required(ErrorMessage = "A senha deve ser informado")]
        public string Password { get; set; }


        [DisplayName("Email")]
        [Required(ErrorMessage = "O Email deve ser informado")]
        public string Email { get; set; }


        [DisplayName("SystemEntranceDate")]
        public DateTime SystemEntranceDate { get; set; }


        [DisplayName("SystemExiteDate")]
        public DateTime? SystemExitDate { get; set; }

        [DisplayName("AccessLevel")]
        public string AccessLevel { get; set; }
        
    }
}
