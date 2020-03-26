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
        public VehicleInsertViewModel(string carBoard, string type, int modelID)
        {
            CarBoard = carBoard;
            Type = type;
            ModelID = modelID;
        }
        public VehicleInsertViewModel()
        {

        }

        [DisplayName("Car Board")]
        [Required(ErrorMessage = "Car Board is required")]
        [StringLength(maximumLength: 7, MinimumLength = 7, ErrorMessage = "A Placa do carro deve conter 7 caracteres")]
        public string CarBoard { get; set; }


        [Required(ErrorMessage = "Type is required")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "O tipo deve conter 3 e 200 caracteres")]
        public string Type { get; set; }


        [DisplayName("Model ID")]
        [Required(ErrorMessage = "Model ID is required")]
        public int ModelID { get; set; }
    }
}
