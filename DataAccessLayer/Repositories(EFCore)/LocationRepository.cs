using Common.FlowControl;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using Microsoft.EntityFrameworkCore;
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

            Response response = new Response();
            try
            {
                using (SmartParkingContext context = new SmartParkingContext())
                {
                    context.Entry<LocationDTO>(new LocationDTO() { ID = idLocation }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    int nLinhasAfetadas = await context.SaveChangesAsync();
                    if (nLinhasAfetadas == 1)
                    {
                        response.Success = true;
                        return response;
                    }

                    response.Errors.Add("Exclusão não executada");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;

            }
        }
        public async Task<DataResponse<LocationDTO>> GetActives()
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
