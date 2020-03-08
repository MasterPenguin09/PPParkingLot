using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
   internal interface IVehicleService
    {
        Task Insert(VehicleDTO vehicle);
        Task<List<VehicleDTO>> GetAll(VehicleDTO vehicle);
        Task Update(VehicleDTO vehicle);
        Task<List<VehicleDTO>> GetActives(VehicleDTO vehicle);
        Task Disable(VehicleDTO vehicle);
        Task Delete(VehicleDTO vehicle);
        Task<List<VehicleDTO>> GetLocationByID(int ID);
    }
}
