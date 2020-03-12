using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Insert
{
    public class ModelInsertViewModel
    {

        [DisplayName("Name")]
        [Required(ErrorMessage = "O nome deve ser informado")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "O nome deve conter 3 e 200 caracteres")]
        public string Name { get; set; }

        [DisplayName("BrandID")]
        [Required(ErrorMessage = "O ID da placa deve ser informado")]
        public int BrandID { get; set; }
    }
}
