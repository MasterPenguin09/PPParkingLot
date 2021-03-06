﻿
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
    public class ClientRepository : IClientRepository
    {
        /// <summary>
        /// Uma Classe publica ClientRepository que herda de uma interface com mesmo nome (+I na frente),
        /// Essa interface possui todas as ações que a ClientDTO pode fazer ligadas ao banco de dados
        /// 
        /// Nessa classe as ações herdadas são preenchidas
        /// </summary>

        private SmartParkingContext _context;
        public ClientRepository(SmartParkingContext context)
        {
            _context = context;
        }

        public async Task<Response> Delete(int idClient)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    context.Entry<ClientDTO>(new ClientDTO() { ID = idClient }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    int nLinhasAfetadas = await context.SaveChangesAsync();

                    if (nLinhasAfetadas == 1)
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
                throw ex;

            }
        }

        public async Task<Response> Disable(int idClient)
        {
            Response response = new Response();

            try
            {
                using (var context = _context)
                {
                    ClientDTO client = await context.Clients.FindAsync(idClient);
                    client.IsActive = false;
                    context.Clients.Update(client);
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
                throw ex;

            }
        }

        public async Task<DataResponse<ClientDTO>> GetActives()
        {
            DataResponse<ClientDTO> response = new DataResponse<ClientDTO>();

            try
            {
                using (var context = _context)
                {
                    response.Data = await context.Clients.Where(c => c.IsActive == true).ToListAsync();
                    if (response.Data.Count > 0)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Dados inexistentes");
                        return response;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<DataResponse<ClientDTO>> GetAll()
        {
            DataResponse<ClientDTO> response = new DataResponse<ClientDTO>();

            try
            {
                using (var context = _context)
                {
                    response.Data = await context.Clients.ToListAsync();

                    if (response.Data.Count > 0)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Clientes não encontrados");
                        return response;
                    }
                 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DataResponse<ClientDTO>> GetByID(int clientID)
        {
            DataResponse<ClientDTO> response = new DataResponse<ClientDTO>();
            try
            {
                using (var context = _context)
                {
                    response.Data.Add(await context.Clients.FindAsync(clientID));
                    if (response.Data.Count > 0)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Cliente não encontrado");
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DataResponse<ClientDTO>> GetByName(string clientName)
        {
            DataResponse<ClientDTO> response = new DataResponse<ClientDTO>();
            try
            {
                using (var context = _context)
                {
                    response.Data.Add(await context.Clients.Where(c => c.Name == clientName).FirstOrDefaultAsync());
                    if (response.Data.Count > 0)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Cliente não encontrado");
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DataResponse<ClientDTO>> GetByEmail(string emailClient)
        {
            DataResponse<ClientDTO> response = new DataResponse<ClientDTO>();
            try
            {
                using (var context = _context)
                {
                    response.Data.Add(await context.Clients.Where(c => c.Email == emailClient).FirstOrDefaultAsync());
                    if (response.Data.Count > 0)
                    {
                        response.Success = true;
                        return response;
                    }
                    response.Errors.Add("Cliente não encontrado");
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response> Insert(ClientDTO client)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    
                    context.Clients.Add(client);
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
                throw ex;
            }
        }

        public async Task<Response> Update(ClientDTO client)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    //context.Entry(brand).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    // int nLinhasAfetadas = await context.SaveChangesAsync();
                    context.Clients.Update(client);
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
                throw ex;
            }
        }
    }
}
