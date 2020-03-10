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
    public class ParkingSpotRepository : IParkingSpotRepository
    {
        public Task<Response> Delete(int idPakingSpot)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Disable(int idPakingSpot)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<ParkingSpotDTO>> GetActives()
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<ParkingSpotDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<ParkingSpotDTO>> GetByID(int idPakingSpot)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Insert(ParkingSpotDTO pakingSpot)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(ParkingSpotDTO pakingSpot)
        {
            throw new NotImplementedException();
        }
    }
}
