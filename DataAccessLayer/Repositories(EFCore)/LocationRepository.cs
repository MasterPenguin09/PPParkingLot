﻿using Common.FlowControl;
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
        public async Task<Response> Delete(int idLocation)
        {
  
            using (SmartParkingContext context = new SmartParkingContext())
            {

                LocationDTO location = new LocationDTO();

                
            }

        }
        public Task<DataResponse<LocationDTO>> GetActives()
        {

            using (SmartParkingContext context = new SmartParkingContext())
            {
                return await context.Locations.ToListAsync();
            }

        }

        public Task<Response> Disable(int idLocation)
        {
            throw new NotImplementedException();
        }

        public Task<Task<DataResponse<LocationDTO>>> Disable(object location)
        {
            throw new NotImplementedException();
        }

        }

        public Task<DataResponse<LocationDTO>> GetActives(object location)
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
