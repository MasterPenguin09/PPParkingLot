
using DAL.Context_EFCore_;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCommons;

namespace DataAccessLayer.Repositories_EFCore_
{
    public class ParkingSpotRepository : IParkingSpotRepository
    {
        private SmartParkingContext _context;
        public ParkingSpotRepository(SmartParkingContext context)
        {
            _context = context;
        }

        public async Task<Response> Delete(int idParkingSpot)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
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

        public async Task<Response> Disable(int idPakingSpot)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    ParkingSpotDTO parkingSpot = await context.ParkingSpots.FindAsync(idPakingSpot);
                    parkingSpot.IsActive = false;
                    context.ParkingSpots.Update(parkingSpot);
                    await context.SaveChangesAsync();
                }
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;

            }
        }

        public async Task<DataResponse<ParkingSpotDTO>> GetActives()
        {
            DataResponse<ParkingSpotDTO> response = new DataResponse<ParkingSpotDTO>();

            try
            {
                using (var context = _context)
                {
                    response.Data = await context.ParkingSpots.Where(c => c.IsActive == true).ToListAsync();
                    response.Success = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return response;
            }
        }

        public async Task<DataResponse<ParkingSpotDTO>> GetAll()
        {
            DataResponse<ParkingSpotDTO> response = new DataResponse<ParkingSpotDTO>();

            try
            {
                using (var context = _context)
                {
                    response.Data = await context.ParkingSpots.ToListAsync();

                    if (response.Data != null)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Vagas não encontradas");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }

        public async Task<DataResponse<ParkingSpotDTO>> GetByID(int idPakingSpot)
        {
            DataResponse<ParkingSpotDTO> response = new DataResponse<ParkingSpotDTO>();
            try
            {
                using (var context = _context)
                {
                    response.Data.Add(await context.ParkingSpots.FindAsync(idPakingSpot));
                    if (response.Data != null)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Vaga não encontrada");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }

        public async Task<Response> Insert(ParkingSpotDTO pakingSpot)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    context.ParkingSpots.Add(pakingSpot);
                    await context.SaveChangesAsync();
                }
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }

        public async Task<Response> Update(ParkingSpotDTO pakingSpot)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    //context.Entry(brand).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    // int nLinhasAfetadas = await context.SaveChangesAsync();
                    context.ParkingSpots.Update(pakingSpot);
                    await context.SaveChangesAsync();
                    //if (nLinhasAfetadas == 1)
                }  // {
                response.Success = true;
                return response;
                // }

                // response.Errors.Add("Edição não executada");
                //return response;

            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }
    }
}
