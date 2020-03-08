﻿using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
   internal interface IBrandService
    {
        Task Insert(BrandDTO brand);
        Task<List<BrandDTO>> GetAll();
        Task Update(BrandDTO brand);
        Task<List<BrandDTO>> GetActives();
        Task Disable(BrandDTO brand);
        Task Delete(BrandDTO brand);
        Task<List<BrandDTO>> GetLocationByID(int ID);
    }
}
