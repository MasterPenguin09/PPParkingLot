using Common.FlowControl;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces_EFCore_
{
    public interface ILocationRepository
    {
        /// <summary>
        /// Insere uma locação
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Response</returns>
        Task<Response> Insert(LocationDTO location);

        /// <summary>
        /// Busca todas as locações
        /// </summary>
        /// <returns></returns>
        /// 
        Task<Response> Create(LocationDTO location); //Insert e create fazem a msm coisa
        /// <summary>
        /// Insere uma locação
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Response</returns>
        Task<DataResponse<LocationDTO>> GetAll();

        /// <summary>
        /// Edita uma locação
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        Task<Response> Update(LocationDTO location);

        /// <summary>
        /// Busca apenas locações ativas
        /// </summary>
        /// <returns>DataResponse</returns>
        Task<DataResponse<LocationDTO>> GetActives();

        /// <summary>
        /// Desabilita uma locação
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Response</returns>
        Task<Response> Disable(int idLocation);

        /// <summary>
        /// Apaga uma locação
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        Task<Response> Delete(int idLocation);

        /// <summary>
        /// Busca uma locação por ID
        /// </summary>
        /// <param name="locationID"></param>
        /// <returns>DataResponse</returns>
        Task<DataResponse<LocationDTO>> GetByID(int locationID);

        /// <summary>
        /// Busca uma locação pelo valor
        /// </summary>
        /// <param name="locationValue"></param>
        /// <returns>DataResponse</returns>
        Task<DataResponse<LocationDTO>> GetByValue(double locationValue);
        Task<Task<DataResponse<LocationDTO>>> Disable(object location);
        Task<DataResponse<LocationDTO>> GetActives(object location);
    }
}
