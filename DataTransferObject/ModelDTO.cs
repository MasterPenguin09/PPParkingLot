﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    class ModelDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }


        public BrandDTO BrandDTO { get; set; }
        public int BrandID { get; set; }

    }
}