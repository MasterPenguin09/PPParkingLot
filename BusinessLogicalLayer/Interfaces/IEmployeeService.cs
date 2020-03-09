using Common.FlowControl;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
   internal interface IEmployeeService
    {
        /// <summary>
        /// Insere um funcionário
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Response</returns>
        Task<Response> Insert(EmployeeDTO employee);

        /// <summary>
        /// Pega todos os funcionarios
        /// </summary>
        /// <returns>DataResponse</returns>
        Task<DataResponse<EmployeeDTO>> GetAll();

        /// <summary>
        /// Edita funcionário
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Response</returns>
        Task<Response> Update(EmployeeDTO employee);

        /// <summary>
        /// Pega apenas funcionários ativos
        /// </summary>
        /// <returns>DataResponse</returns>
        Task<DataResponse<EmployeeDTO>> GetActives();

        /// <summary>
        /// Desabilita um funcionário
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Response</returns>
        Task<Response> Disable(int idEmployee);

        /// <summary>
        /// Apaga um funcionário
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Response</returns>
        Task<Response> Delete(int idEmployee);

        /// <summary>
        /// Busca funcionário pelo id
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        Task<DataResponse<EmployeeDTO>> GetByID(int employeeID);

        /// <summary>
        /// Busca um funcionário pelo nome
        /// </summary>
        /// <param name="employeeName"></param>
        /// <returns>DataResponse</returns>
        Task<DataResponse<EmployeeDTO>> GetByName(string employeeName);
    }
}
