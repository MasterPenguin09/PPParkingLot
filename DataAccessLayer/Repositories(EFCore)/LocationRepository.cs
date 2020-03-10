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
    public class LocationRepository : ILocationRepository
    {
        public async Task<Response> Create(LocationDTO location)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Delete(LocationDTO location)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Delete(int idLocation)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Disable(LocationDTO location)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Disable(int idLocation)
        {
            throw new NotImplementedException();
        }

        public async Task<Task<DataResponse<LocationDTO>>> Disable(object location)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<LocationDTO>> GetActives()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<LocationDTO>> GetActives(object location)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<LocationDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<LocationDTO>> GetByID(int locationID)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<LocationDTO>> GetByValue(double locationValue)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Insert(LocationDTO location)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Update(LocationDTO location)
        {
            throw new NotImplementedException();
        }
    }
}
