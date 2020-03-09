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
        public Task<Response> Create(LocationDTO location)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Delete(LocationDTO location)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Disable(LocationDTO location)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<LocationDTO>> GetActives()
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<LocationDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<LocationDTO>> GetByID(int locationID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<LocationDTO>> GetByValue(double locationValue)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Insert(LocationDTO location)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(LocationDTO location)
        {
            throw new NotImplementedException();
        }
    }
}
