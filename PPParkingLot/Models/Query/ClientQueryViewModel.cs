using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Query
{
    public class ClientQueryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Number { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public DateTime SystemEntranceDate { get; set; }
        public DateTime? SystemExitDate { get; set; }
        public string AccessLevel { get; set; }
        public bool IsActive { get; set; }
    }
}
