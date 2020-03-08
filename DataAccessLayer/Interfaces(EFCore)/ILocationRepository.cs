using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces_EFCore_
{
   internal interface ILocationRepository
    {
        Task Insert(LocationDTO location);
        Task<List<LocationDTO>> GetAll(LocationDTO location);
        Task Update(LocationDTO location);
        Task<List<LocationDTO>> GetActives(LocationDTO location);
        Task Disable(LocationDTO location);
        Task Delete(LocationDTO location);
        Task<List<LocationDTO>> GetLocationByID(int ID);
    }
}
