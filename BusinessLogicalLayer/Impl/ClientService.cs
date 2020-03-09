using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Validators;
using Common.FlowControl;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Impl
{
   public class ClientService : IClientService
    {
        private  IClientRepository _iClientRepository;
        public ClientService(IClientRepository iClientRep)
        {
            this._iClientRepository = iClientRep;
        }

        public async Task<Response> Delete(ClientDTO client)
        {
            Response response = new Response();
            ClientValidator validate = new ClientValidator();
            ValidationResult result = validate.Validate(client);

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    response.Errors.Add("Property " + failure.PropertyName + " failed validation. Error was: " + "(" + failure.ErrorMessage + ")");
                }

                return response;
            }
            else
            {
                return await _iClientRepository.Delete(client);
            }
        }

        public async Task<Response> Disable(ClientDTO client)
        {
            Response response = new Response();
            ClientValidator validate = new ClientValidator();
            ValidationResult result = validate.Validate(client);

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    response.Errors.Add("Property " + failure.PropertyName + " failed validation. Error was: " + "(" + failure.ErrorMessage + ")");
                }

                return response;
            }
            else
            {
                return await _iClientRepository.Disable(client);
            }
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
