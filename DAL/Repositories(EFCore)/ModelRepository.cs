
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
    /// Uma Classe publica ModelRepository que herda de uma interface com mesmo nome (+I na frente),
    /// Essa interface possui todas as ações que a ModelDTO pode fazer ligadas ao banco de dados
    /// 
    /// Nessa classe as ações herdadas são preenchidas
    /// </summary>

    public class ModelRepository : IModelRepository
    {
        private SmartParkingContext _context;
        public ModelRepository(SmartParkingContext context)
        {
            _context = context;
        }
        public async Task<Response> Delete(int idModel)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    context.Entry<ModelDTO>(new ModelDTO() { ID = idModel }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
      
        public async Task<DataResponse<ModelDTO>> GetAll()
        {
            DataResponse<ModelDTO> response = new DataResponse<ModelDTO>();

            try
            {
                using (var context = _context)
                {
                    response.Data = await context.Models.ToListAsync();

                    if (response.Data != null)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Modelos não encontrados");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }

        public async Task<DataResponse<ModelDTO>> GetByID(int modelID)
        {
            DataResponse<ModelDTO> response = new DataResponse<ModelDTO>();
            try
            {
                using (var context = _context)
                {
                    response.Data.Add(await context.Models.FindAsync(modelID));
                    if (response.Data != null)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Modelo não encontrado");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }

        public async Task<Response> Insert(ModelDTO model)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    context.Models.Add(model);
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
    

        public async Task<Response> Update(ModelDTO model)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {                       
                    context.Models.Update(model);
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
