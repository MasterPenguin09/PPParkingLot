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
    public class BrandRepository : IBrandRepository
    {
        public async Task<Response> Delete(int idBrand)
        {
            Response response = new Response();
            try
            {
                using (SmartParkingContext context = new SmartParkingContext())
                {
                    context.Entry<BrandDTO>(new BrandDTO() { ID = idBrand }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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

        public async Task<Response> Disable(int idBrand)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<BrandDTO>> GetActives()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<BrandDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<BrandDTO>> GetByID(int brandID)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<BrandDTO>> GetByName(string brandName)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Insert(BrandDTO brand)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Update(BrandDTO brand)
        {
            throw new NotImplementedException();
        }
    }
}
