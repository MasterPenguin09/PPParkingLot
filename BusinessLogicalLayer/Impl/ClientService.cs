using BusinessLogicalLayer.Interfaces;
using Common.FlowControl;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Impl
{
   public class ClientService : IClientService
    {
        private IClientRepository _iClientRepository;
        public ClientService(IClientRepository iClientRep)
        {
            this._iClientRepository = iClientRep;
        }

        public Task<Response> Delete(ClientDTO client)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Disable(ClientDTO client)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<ClientDTO>> GetActives()
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<ClientDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<ClientDTO>> GetByID(int clientID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<ClientDTO>> GetByName(string clientName)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Insert(ClientDTO client)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(ClientDTO client)
        {
            throw new NotImplementedException();
        }
    }
}
