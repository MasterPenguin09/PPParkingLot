using Common.FlowControl;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
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
