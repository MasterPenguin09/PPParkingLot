
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
    /// <summary>
    /// Uma Classe publica LocationRepository que herda de uma interface com mesmo nome (+I na frente),
    /// Essa interface possui todas as ações que LocationDTO pode fazer ligadas ao banco de dados
    /// 
    /// Nessa classe as ações herdadas são preenchidas
    /// </summary>

    public class LocationRepository : ILocationRepository
    {
        private SmartParkingContext _context;

        public LocationRepository(SmartParkingContext context)
        {
            _context = context;
        }

        public async Task<Response> Delete(int idLocation)
        {

            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    context.Entry<LocationDTO>(new LocationDTO() { ID = idLocation }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    int nAffectedRows = await context.SaveChangesAsync();

                    if (nAffectedRows == 1)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Exclusão não executada");
                        return response;
                    }
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
            DataResponse<LocationDTO> response = new DataResponse<LocationDTO>();
            try
            {
                using (var context = _context)
                {
                    response.Data = await context.Locations.Where(c => c.IsActive == true).ToListAsync();
                    response.Success = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return response;
            }
        }

        public async Task<Response> Disable(int idLocation)
        {
            Response response = new Response();

            try
            {
                using (var context = _context)
                {
                    LocationDTO location = await context.Locations.FindAsync(idLocation);
                    location.IsActive = false;
                    context.Locations.Update(location);
                    int nAffectedRows = await context.SaveChangesAsync();

                    if (nAffectedRows == 1)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Desabilitação não executada");
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;

            }
        }

        public async Task<DataResponse<LocationDTO>> GetAll()
        {
            DataResponse<LocationDTO> response = new DataResponse<LocationDTO>();

            try
            {
                using (var context = _context)
                {
                    response.Data = await context.Locations.ToListAsync();

                    if (response.Data != null)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Locações não encontradas");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }

        public async Task<DataResponse<LocationDTO>> GetByID(int locationID)
        {
            DataResponse<LocationDTO> response = new DataResponse<LocationDTO>();
            try
            {
                using (var context = _context)
                {
                    response.Data.Add(await context.Locations.FindAsync(locationID));
                    if (response.Data != null)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Locação não encontrada");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }

        public async Task<DataResponse<LocationDTO>> GetByValue(double locationValue)
        {
            DataResponse<LocationDTO> response = new DataResponse<LocationDTO>();
            try
            {
                using (var context = _context)
                {
                    response.Data = (await context.Locations.Where(c => c.Value <= locationValue).ToListAsync());
                    if (response.Data != null)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Locações não encontradas");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }

        public async Task<Response> Insert(LocationDTO location)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    context.Locations.Add(location);
                    int nAffectedRows = await context.SaveChangesAsync();

                    if (nAffectedRows > 0)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Inserção não executada");
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }

        public async Task<Response> Update(LocationDTO location)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    //context.Entry(brand).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    // int nLinhasAfetadas = await context.SaveChangesAsync();
                    context.Update(location);
                    int nAffectedRows = await context.SaveChangesAsync();

                    if (nAffectedRows == 1)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Edição não executada");
                        return response;
                    }
                }  
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }
    }
}
