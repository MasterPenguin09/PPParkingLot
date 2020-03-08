﻿using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces_EFCore_
{
   public interface IClientRepository
    {
        Task Insert(ClientDTO client);
        Task<List<ClientDTO>> GetAll();
        Task Update(ClientDTO client);
        Task<List<ClientDTO>> GetActives();
        Task Disable(ClientDTO client);
        Task Delete(ClientDTO client);
        Task<List<ClientDTO>> GetLocationByID(int ID);
    }
}
