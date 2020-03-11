
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
    public class ModelRepository : IModelRepository
    {
        public async Task<Response> Delete(int idModel)
        {
            Response response = new Response();
            try
            {
                using (SmartParkingContext context = new SmartParkingContext())
                {
                    context.Entry<ModelDTO>(new ModelDTO() { ID = idModel }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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

        public async Task<Response> Disable(int idModel)
        {
            throw new NotImplementedException();
        }

       
        public async Task<DataResponse<ModelDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<ModelDTO>> GetByID(int modelID)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Insert(ModelDTO model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Update(ModelDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
