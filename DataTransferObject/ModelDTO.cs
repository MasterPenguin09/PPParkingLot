﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
     public class ModelDTO 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual BrandDTO BrandDTO { get; set; }

    }
}
