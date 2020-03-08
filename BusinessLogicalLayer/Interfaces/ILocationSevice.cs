using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    public interface ILocationSevice
    {
        Task Insert(LocationRepository location);
        Task<List<LocationRepository>> GetAll(LocationRepository location);
        Task Update(LocationRepository location);
        Task<List<LocationRepository>> GetActives(LocationRepository location);
        Task Disable(LocationRepository location);
        Task Delete(LocationRepository location);
        Task<List<LocationRepository>> GetLocationByID(int ID); 
        

    }
}
