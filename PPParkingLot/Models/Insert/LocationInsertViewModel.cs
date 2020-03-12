using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Insert
{
    public class LocationInsertViewModel
    {

        [DisplayName("EntryTime")]
        public DateTime EntryTime { get; set; }


        [DisplayName("ExitTime")]
        public DateTime? ExitTime { get; set; }

        [DisplayName("PayForm")]
        [Required(ErrorMessage = "A forma do pagamento deve ser informado")]
        public String PayForm { get; set; }

        [DisplayName("Value")]
        [Required(ErrorMessage = "O valor deve ser informado")]
        public int Value { get; set; }


        [DisplayName("PayForm")]
        [Required(ErrorMessage = "A forma do pagamento deve ser informado")]
        public String Vehicle { get; set; }


        [DisplayName("VehicleID")]
        [Required(ErrorMessage = "O ID do veiculo deve ser informado")]
        public int VehicleID { get; set; }


        [DisplayName("ParkingSpot")]
        [Required(ErrorMessage = "A vaga deve ser informado")]
        public String ParkingSpot { get; set; }


        [DisplayName("ParkingSpotID")]
        [Required(ErrorMessage = "O ID da vaga deve ser informado")]
        public int ParkingSpotID { get; set; }
    }
}
