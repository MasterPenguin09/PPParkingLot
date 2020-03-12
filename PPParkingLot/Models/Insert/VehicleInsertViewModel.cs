using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Insert
{
    public class VehicleInsertViewModel
    {

        [DisplayName("CarBoard")]
        [Required(ErrorMessage = "A Placa do Carro deve ser informado")]
        [StringLength(maximumLength: 7, MinimumLength = 7, ErrorMessage = "A Placa do carro deve conter 7 caracteres")]
        public string CarBoard { get; set; }


        [DisplayName("Type")]
        [Required(ErrorMessage = "O Tipo deve ser informado")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "O tipo deve conter 3 e 200 caracteres")]
        public string Type { get; set; }


        [DisplayName("ModelID")]
        [Required(ErrorMessage = "O ID do modelo deve ser informado")]
        public int ModelID { get; set; }
    }
}
