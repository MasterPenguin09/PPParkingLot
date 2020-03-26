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
        public ModelInsertViewModel(string name, int brandID)
        {
            Name = name;
            BrandID = brandID;
        }

        public ModelInsertViewModel()
        {

        }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "The name must contain 3 and 200 characters")]
        public string Name { get; set; }

        [DisplayName("Brand ID")]
        [Required(ErrorMessage = "Brand ID must be informed")]
        public int BrandID { get; set; }
    }
}
