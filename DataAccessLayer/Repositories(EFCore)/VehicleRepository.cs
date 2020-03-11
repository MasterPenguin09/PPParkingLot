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
    public class VehicleRepository : IVehicleRepository
    {
        public async Task<Response> Delete(int idVehicle)
        {
            Response response = new Response();
            try
            {
                using (SmartParkingContext context = new SmartParkingContext())
                {
                    context.Entry<VehicleDTO>(new VehicleDTO() { ID = idVehicle }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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

        public async Task<Response> Disable(int idVehicle)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<VehicleDTO>> GetActives()
        {
            List<VehicleDTO> vehicles = new List<VehicleDTO>();

            try
            {
                using (SmartParkingContext context = new SmartParkingContext())
                {
                    vehicles = await context.Vehicles.Where(c => c.IsActive == true).ToListAsync();

                }
                DataResponse<VehicleDTO> dataResponse = new DataResponse<VehicleDTO>();
                dataResponse.Data = vehicles;
                dataResponse.Success = true;
                return dataResponse;
            }
            catch (Exception ex)
            {

                File.WriteAllText("log.txt", ex.Message);
                DataResponse<VehicleDTO> response = new DataResponse<VehicleDTO>();
                response.Success = false;
                response.Errors.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return response;
            }
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
