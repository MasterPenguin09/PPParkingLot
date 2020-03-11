
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
        public async Task<Response> Delete(int idClient)
        {
            Response response = new Response();
            try
            {
                using (SmartParkingContext context = new SmartParkingContext())
                {
                    context.Entry<ClientDTO>(new ClientDTO() { ID = idClient }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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

        public async Task<Response> Disable(int idClient)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<ClientDTO>> GetActives()
        {
            List<ClientDTO> clients = new List<ClientDTO>();

            try
            {
                using (SmartParkingContext context = new SmartParkingContext())
                {
                    clients = await context.Clients.Where(c => c.IsActive == true).ToListAsync();

                }
                DataResponse<ClientDTO> dataResponse = new DataResponse<ClientDTO>();
                dataResponse.Data = clients;
                dataResponse.Success = true;
                return dataResponse;
            }
            catch (Exception ex)
            {

                
                DataResponse<ClientDTO> response = new DataResponse<ClientDTO>();
                response.Success = false;
                response.Errors.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return response;
            }
        }

        public async Task<DataResponse<ClientDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<ClientDTO>> GetByID(int clientID)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<ClientDTO>> GetByName(string clientName)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Insert(ClientDTO client)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Update(ClientDTO client)
        {
            throw new NotImplementedException();
        }
    }
}
