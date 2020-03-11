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
        public string Number { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime SystemEntranceDate { get; set; }
        public DateTime? SystemExitDate { get; set; }
        public string AccessLevel { get; set; }
        
    }
}
