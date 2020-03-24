
using DAL.Context_EFCore_;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCommons;

namespace DataAccessLayer.Repositories_EFCore_
{
    /// <summary>
    /// Uma Classe publica EmployeeRepository que herda de uma interface com mesmo nome (+I na frente),
    /// Essa interface possui todas as ações que a EmployeeDTO pode fazer ligadas ao banco de dados
    /// 
    /// Nessa classe as ações herdadas são preenchidas
    /// </summary>

    public class EmployeeRepository : IEmployeeRepository
    {
        private SmartParkingContext _context;
        public EmployeeRepository(SmartParkingContext context)
        {
            _context = context;
        }
        public async Task<Response> Delete(int idEmployee)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    context.Entry<EmployeeDTO>(new EmployeeDTO() { ID = idEmployee }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    int nAffectedRows = await context.SaveChangesAsync();

                    if (nAffectedRows == 1)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Exclusão não executada");
                        return response;
                    }
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
            Response response = new Response();

            try
            {
                using (var context = _context)
                {
                   EmployeeDTO employee = await context.Employees.FindAsync(idEmployee);
                    employee.IsActive = false;
                    context.Employees.Update(employee);
                    int nAffectedRows = await context.SaveChangesAsync();

                    if (nAffectedRows == 1)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Desabilitação não executada");
                        return response;
                    }
                }
              
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;

            }
        }

        public async Task<DataResponse<EmployeeDTO>> GetActives()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            try
            {
                using (var context = _context)
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

               
                DataResponse<EmployeeDTO> response = new DataResponse<EmployeeDTO>();
                response.Success = false;
                response.Errors.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return response;
            }
        }

        public async Task<DataResponse<EmployeeDTO>> GetAll()
        {
            DataResponse<EmployeeDTO> response = new DataResponse<EmployeeDTO>();

            try
            {
                using (var context = _context)
                {
                    response.Data = await context.Employees.ToListAsync();

                    if (response.Data != null)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Funcionários não encontrados");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }

        public async Task<DataResponse<EmployeeDTO>> GetByID(int employeeID)
        {
            DataResponse<EmployeeDTO> response = new DataResponse<EmployeeDTO>();
            try
            {
                using (var context = _context)
                {
                    response.Data.Add(await context.Employees.FindAsync(employeeID));
                    if (response.Data != null)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Funcionário não encontrado");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }

        public async Task<DataResponse<EmployeeDTO>> GetByName(string employeeName)
        {
            DataResponse<EmployeeDTO> response = new DataResponse<EmployeeDTO>();
            try
            {
                using (var context = _context)
                {
                    response.Data.Add(await context.Employees.Where(c => c.Name == employeeName).FirstOrDefaultAsync());
                    if (response.Data != null)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Funcionário não encontrado");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }

        public async Task<Response> Insert(EmployeeDTO employee)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    context.Employees.Add(employee);
                    int nAffectedRows = await context.SaveChangesAsync();

                    if (nAffectedRows > 0)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Inserção não executada");
                        return response;
                    }
                }
             
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }

        public Task<DataResponse<ClientDTO>> Login(EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Update(EmployeeDTO employee)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
 
                    context.Employees.Update(employee);
                    int nAffectedRows = await context.SaveChangesAsync();

                    if (nAffectedRows == 1)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Edição não executada");
                        return response;
                    }
                } 
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }

       public async Task<DataResponse<EmployeeDTO>> GetByEmail(string emailEmployee)
        {
            DataResponse<EmployeeDTO> response = new DataResponse<EmployeeDTO>();
            try
            {
                using (var context = _context)
                {
                    response.Data.Add(await context.Employees.Where(c => c.Email == emailEmployee).FirstOrDefaultAsync());
                    if (response.Data != null)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Funcionário não encontrado");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }
    }
}
