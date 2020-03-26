using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Insert
{
    public class BrandInsertViewModel
    {
        public BrandInsertViewModel(string name)
        {
            Name = name;
        }
        public BrandInsertViewModel()
        {

        }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(maximumLength: 70, ErrorMessage = "Must be between 2 and 70 characters", MinimumLength = 2)]
        public string Name { get; set; }
    }
}
