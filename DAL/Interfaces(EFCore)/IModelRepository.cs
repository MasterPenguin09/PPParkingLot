
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCommons;

namespace DataAccessLayer.Interfaces_EFCore_
{
    /// <summary>
    ///  Possui uma Interface EF do Repositorio da Model
    ///  Nela tem todas as ações que a ModelDTO pode fazer
    ///  ligadas ao banco de dados
    /// </summary>

    public interface IModelRepository
    {
        /// <summary>
        /// Insere um modelo
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Response</returns>
        Task<Response> Insert(ModelDTO model);

        /// <summary>
        /// Busca todos os modelos
        /// </summary>
        /// <returns>DataResponse</returns>
        Task<DataResponse<ModelDTO>> GetAll();

        /// <summary>
        /// Edita um modelo
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Response</returns>
        Task<Response> Update(ModelDTO model);
 
        
        /// <summary>
        /// Apaga um modelo
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Response</returns>
        Task<Response> Delete(int idModel);

        /// <summary>
        /// Pega um modelo pelo id
        /// </summary>
        /// <param name="modelID"></param>
        /// <returns>DataResponse</returns>
        Task<DataResponse<ModelDTO>> GetByID(int modelID);
    }
}
