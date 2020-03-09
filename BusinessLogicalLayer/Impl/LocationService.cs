using BusinessLogicalLayer.Interfaces;
using Common.FlowControl;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Impl
{
    public class LocationService :  ILocationSevice
    {
        private ILocationRepository _iLocationRepository;
        public LocationService(ILocationRepository iLocationRep)
        {
            this._iLocationRepository = iLocationRep;
        }


        public  Task<Response> Delete(LocationDTO location)
        {


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
