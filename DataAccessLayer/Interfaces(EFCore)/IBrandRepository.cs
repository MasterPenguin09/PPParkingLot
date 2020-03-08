﻿using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces_EFCore_
{
    internal interface IBrandRepository
    {
        
        Task Insert(BrandDTO brand);
        Task<List<BrandDTO>> GetAll(BrandDTO brand);
        Task Update(BrandDTO brand);
        Task<List<BrandDTO>> GetActives(BrandDTO brand);
        Task Disable(BrandDTO brand);
        Task Delete(BrandDTO brand);
        Task<List<BrandDTO>> GetLocationByID(int ID);
    }
}
