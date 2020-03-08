using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces_EFCore_
{
    public interface IVehicleRepository
    {
        Task Insert(VehicleDTO vehicle);
        Task<List<VehicleDTO>> GetAll();
        Task Update(VehicleDTO vehicle);
        Task<List<VehicleDTO>> GetActives();
        Task Disable(VehicleDTO vehicle);
        Task Delete(VehicleDTO vehicle);
        Task<List<VehicleDTO>> GetLocationByID(int ID);
    }
}
