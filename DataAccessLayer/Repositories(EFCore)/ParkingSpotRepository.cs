using Common.FlowControl;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<DataResponse<ParkingSpotDTO>> GetActives()
        {
            List<ParkingSpotDTO> parkingSpots = new List<ParkingSpotDTO>();

            try
            {
                using (SmartParkingContext context = new SmartParkingContext())
                {
                    parkingSpots = await context.ParkingSpots.Where(c => c.IsActive == true).ToListAsync();

                }
                DataResponse<ParkingSpotDTO> dataResponse = new DataResponse<ParkingSpotDTO>();
                dataResponse.Data = parkingSpots;
                dataResponse.Success = true;
                return dataResponse;
            }
            catch (Exception ex)
            {

                File.WriteAllText("log.txt", ex.Message);
                DataResponse<ParkingSpotDTO> response = new DataResponse<ParkingSpotDTO>();
                response.Success = false;
                response.Errors.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return response;
            }
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
