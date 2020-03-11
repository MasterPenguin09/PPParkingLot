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
        public Task<Response> Delete(int idParkingSpot)
        {
            Response response = new Response();
            try
            {
                using (SmartParkingContext context = new SmartParkingContext())
                {
                    context.Entry<ParkingSpotDTO>(new ParkingSpotDTO() { ID = idParkingSpot }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
