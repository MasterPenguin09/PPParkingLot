using Common.FlowControl;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories_EFCore_
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<Response> Delete(int idEmployee)
        {
            Response response = new Response();
            try
            {
                using (SmartParkingContext context = new SmartParkingContext())
                {
                    context.Entry<EmployeeDTO>(new EmployeeDTO() { ID = idEmployee }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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

        public async Task<Response> Disable(int idEmployee)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<EmployeeDTO>> GetActives()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            try
            {
                using (SmartParkingContext context = new SmartParkingContext())
                {
                    employees = await context.Employees.Where(c => c.IsActive == true).ToListAsync();

                }
                DataResponse<EmployeeDTO> dataResponse = new DataResponse<EmployeeDTO>();
                dataResponse.Data = employees;
                dataResponse.Success = true;
                return dataResponse;
            }
            catch (Exception ex)
            {

                File.WriteAllText("log.txt", ex.Message);
                DataResponse<EmployeeDTO> response = new DataResponse<EmployeeDTO>();
                response.Success = false;
                response.Errors.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return response;
            }
        }

        public async Task<DataResponse<EmployeeDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<EmployeeDTO>> GetByID(int employeeID)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<EmployeeDTO>> GetByName(string employeeName)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Insert(EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Update(EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }
    }
}
