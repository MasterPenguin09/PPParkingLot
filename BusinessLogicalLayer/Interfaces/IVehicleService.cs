using Common.FlowControl;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
   internal interface IVehicleService
    {
        /// <summary>
        /// Insere um veículo
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>Response</returns>
        Task<Response> Insert(VehicleDTO vehicle);

        /// <summary>
        /// Busca todos os veículos
        /// </summary>
        /// <returns>DataResponse</returns>
        Task<DataResponse<VehicleDTO>> GetAll();

        /// <summary>
        /// Edita um veículo 
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>Response</returns>
        Task<Response> Update(VehicleDTO vehicle);

        /// <summary>
        /// Busca apenas veículos ativos
        /// </summary>
        /// <returns>DataResponse</returns>
        Task<DataResponse<VehicleDTO>> GetActives();

        /// <summary>
        /// Desabilita um veículo
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>Response</returns>
        Task<Response> Disable(int idVehicle);

        /// <summary>
        /// Apaga um veículo
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>Response</returns>
        Task<Response> Delete(int idVehicle);

        /// <summary>
        /// Busca um veículo pelo ID 
        /// </summary>
        /// <param name="vehicleID"></param>
        /// <returns>DataResponse</returns>
        Task<DataResponse<VehicleDTO>> GetByID(int vehicleID);

        /// <summary>
        /// Busca um veículo pela placa 
        /// </summary>
        /// <param name="vehicleBoard"></param>
        /// <returns>DataResponse</returns>
        Task<DataResponse<VehicleDTO>> GetByVehicleBoard(string vehicleBoard);
    }
}
