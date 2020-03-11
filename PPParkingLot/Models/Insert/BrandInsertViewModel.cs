using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Insert
{
    public class BrandInsertViewModel
    {
        [Required(ErrorMessage = "O nome deve ser informado.")]
        [StringLength(maximumLength: 70, ErrorMessage = "O nome deve ter entre 2 e 70 caracteres", MinimumLength = 2)]
        public string Name { get; set; }
    }
}
