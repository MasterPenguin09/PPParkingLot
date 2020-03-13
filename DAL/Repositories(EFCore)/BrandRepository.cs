
using DAL.Context_EFCore_;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCommons;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories_EFCore_
{
    public class BrandRepository : IBrandRepository
    {
        /// <summary>
        /// Uma Classe publica BrandRepository que herda de uma interface com mesmo nome (+I na frente),
        /// Essa interface possui todas as ações que a BrandDTO pode fazer ligadas ao banco de dados
        /// 
        /// Nessa classe as ações herdadas são preenchidas
        /// </summary>

        private SmartParkingContext _context;
        public BrandRepository(SmartParkingContext context)
        {
            _context = context;
        }

        public async Task<Response> Delete(int idBrand)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
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

        public async Task<DataResponse<BrandDTO>> GetAll()
        {
            DataResponse<BrandDTO> response = new DataResponse<BrandDTO>();

            try
            {
                using (var context = _context)
                {
                    response.Data = await context.Brands.ToListAsync();

                    if (response.Data != null)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Marcas não encontradas");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }

        public async Task<DataResponse<BrandDTO>> GetByID(int brandID)
        {
            DataResponse<BrandDTO> response = new DataResponse<BrandDTO>();
            try
            {
                using (var context = _context)
                {
                    response.Data.Add(await context.Brands.FindAsync(brandID));
                    if (response.Data != null)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Marca não encontrada");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }

        }

        public async Task<DataResponse<BrandDTO>> GetByName(string brandName)
        {
            DataResponse<BrandDTO> response = new DataResponse<BrandDTO>();
            try
            {
                using (var context = _context)
                {
                    response.Data.Add(await context.Brands.Where(c => c.Name == brandName).FirstOrDefaultAsync());
                    if (response.Data != null)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Marca não encontrada");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }

        public async Task<Response> Insert(BrandDTO brand)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    context.Brands.Add(brand);
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

        public async Task<Response> Update(BrandDTO brand)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    //context.Entry(brand).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    // int nLinhasAfetadas = await context.SaveChangesAsync();
                    context.Update(brand);
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
