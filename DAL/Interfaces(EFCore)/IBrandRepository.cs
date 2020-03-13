
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCommons;

namespace DataAccessLayer.Interfaces_EFCore_
{/// <summary>
///  Possui uma Interface EF do Repositorio da Brand
///  Nela tem todas as ações que a BrandDTO pode fazer
///  ligadas ao banco de dados
/// </summary>
    public interface IBrandRepository
    {
       

        /// <summary>
        /// Insere uma marca
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>Response</returns>
        Task<Response> Insert(BrandDTO brand);

        /// <summary>
        /// Pega todas as marcas
        /// </summary>
        /// <returns>DataResponse</returns>
        Task<DataResponse<BrandDTO>> GetAll();

        /// <summary>
        /// Edita uma marca
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>Response</returns>
        Task<Response> Update(BrandDTO brand);

 
        /// <summary>
        /// Apaga uma marca do banco
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>Resposne</returns>
        Task<Response> Delete(int idBrand);

        /// <summary>
        /// Busca marca por ID
        /// </summary>
        /// <param name="brandID"></param>
        /// <returns>DataResponse</returns>
        Task<DataResponse<BrandDTO>> GetByID(int brandID);

        /// <summary>
        /// Busca uma marca pelo nome
        /// </summary>
        /// <param name="brandName"></param>
        /// <returns>DataResponse</returns>
        Task<DataResponse<BrandDTO>> GetByName(string brandName);
    }
}
