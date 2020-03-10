using Common.FlowControl;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories_EFCore_
{
    public class VehicleRepository : IVehicleRepository
    {
        public async Task<Response> Delete(int idVehicle)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Disable(int idVehicle)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<VehicleDTO>> GetActives()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<VehicleDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<VehicleDTO>> GetByID(int vehicleID)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<VehicleDTO>> GetByVehicleBoard(string vehicleBoard)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Insert(VehicleDTO vehicle)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Update(VehicleDTO vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
