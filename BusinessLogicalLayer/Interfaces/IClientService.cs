using Common.FlowControl;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    internal interface IClientService
    {
        /// <summary>
        /// Insere cliente
        /// </summary>
        /// <param name="client"></param>
        /// <returns>Response</returns>
        Task<Response> Insert(ClientDTO client);

        /// <summary>
        /// Pega todos os clientes
        /// </summary>
        /// <returns>DataResponse</returns>
        Task<DataResponse<ClientDTO>> GetAll();

        /// <summary>
        /// Edita um cliente
        /// </summary>
        /// <param name="client"></param>
        /// <returns>Response</returns>
        Task<Response> Update(ClientDTO client);

        /// <summary>
        /// Pega apenas clientes ativos
        /// </summary>
        /// <returns>DataResponse</returns>
        Task<DataResponse<ClientDTO>> GetActives();

        /// <summary>
        /// Desabilta um cliente
        /// </summary>
        /// <param name="client"></param>
        /// <returns>Response</returns>
        Task<Response> Disable(ClientDTO client);

        /// <summary>
        /// Apaga um cliente
        /// </summary>
        /// <param name="client"></param>
        /// <returns>Response</returns>
        Task<Response> Delete(ClientDTO client);

        /// <summary>
        /// Busca um cliente pelo ID 
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        Task<DataResponse<ClientDTO>> GetByID(int clientID);

        /// <summary>
        /// Busca um cliente pelo nome
        /// </summary>
        /// <param name="clientName"></param>
        /// <returns>DataResponse</returns>
        Task<DataResponse<ClientDTO>> GetByName(string clientName);
    }
}
