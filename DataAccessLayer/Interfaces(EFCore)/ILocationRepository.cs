using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces_EFCore_
{
    public interface ILocationRepository
    {
        Task Insert(LocationDTO location);
        Task<List<LocationDTO>> GetAll();
        Task Update(LocationDTO location);
        Task<List<LocationDTO>> GetActives();
        Task Disable(LocationDTO location);
        Task Delete(LocationDTO location);
        Task<List<LocationDTO>> GetLocationByID(int ID);
    }
}
