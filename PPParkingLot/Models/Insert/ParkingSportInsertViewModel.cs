using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Insert
{
    public class ParkingSportInsertViewModel
    {
        [DisplayName("ValuePerHour")]
        [Required(ErrorMessage = "O vaor por hora deve ser informado")]
        public double ValuePerHour { get; set; }

        [DisplayName("Type")]
        [Required(ErrorMessage = "O Tipo deve ser informado")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "O tipo deve conter 3 e 200 caracteres")]
        public string Type { get; set; }
    }
}
