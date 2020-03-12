
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCommons;

namespace BusinessLogicalLayer.Interfaces
{
    /// <summary>
    /// Possui uma interface interna que contém todas as ações da ModelService
    /// </summary>

    internal interface IModelService
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
        /// Desabilita um modelo
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Response</returns>
        Task<Response> Disable(int idModel);

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
