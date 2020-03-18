﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Models.Insert
{
    public class ClientInsertViewModel
    {
        
        public string Name { get; set; }


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
