
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
    /// Possui uma interface interna que contém todas as ações da ParkingSpotService
    /// </summary>
    public interface IParkingSpotService
    {
        /// <summary>
        /// Insere um modelo
        /// </summary>
        /// <param name="pakingSpot"></param>
        /// <returns>Response</returns>
        Task<Response> Insert(ParkingSpotDTO pakingSpot);

        /// <summary>
        /// Busca todos os modelos
        /// </summary>
        /// <returns>DataResponse</returns>
        Task<DataResponse<ParkingSpotDTO>> GetAll();

        /// <summary>
        /// Edita um modelo
        /// </summary>
        /// <param name="pakingSpot"></param>
        /// <returns>Response</returns>
        Task<Response> Update(ParkingSpotDTO pakingSpot);

        /// <summary>
        /// Pega todos os modelos ativos
        /// </summary>
        /// <returns>DataResponse</returns>
        Task<DataResponse<ParkingSpotDTO>> GetActives();

        /// <summary>
        /// Desabilita um modelo
        /// </summary>
        /// <param name="idPakingSpot"></param>
        /// <returns>Response</returns>
        Task<Response> Disable(int idPakingSpot);

        /// <summary>
        /// Apaga um modelo
        /// </summary>
        /// <param name="idPakingSpot"></param>
        /// <returns>Response</returns>
        Task<Response> Delete(int idPakingSpot);

        /// <summary>
        /// Pega um modelo pelo id
        /// </summary>
        /// <param name="idPakingSpot"></param>
        /// <returns>DataResponse</returns>
        Task<DataResponse<ParkingSpotDTO>> GetByID(int idPakingSpot);
    }
}
