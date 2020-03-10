using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Security;
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

        public async Task<Response> Delete(int idClient)
        {
            Response response = new Response();
            if (idClient < 0)
            {
                response.Errors.Add("ID Inválido!");
            }
            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iClientRepository.Delete(idClient);
            }
        }

        public async Task<Response> Disable(int idClient)
        {
            Response response = new Response();
            if (idClient < 0)
            {
                response.Errors.Add("ID Inválido!");
            }
            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iClientRepository.Disable(idClient);
            }
        }

        public async Task<DataResponse<ClientDTO>> GetActives()
        {
            return await _iClientRepository.GetActives();
        }

        public async Task<DataResponse<ClientDTO>> GetAll()
        {
            return await _iClientRepository.GetAll();
        }

        public async Task<DataResponse<ClientDTO>> GetByID(int clientID)
        {
            DataResponse<ClientDTO> response = new DataResponse<ClientDTO>();
            if (clientID < 0)
            {
                response.Errors.Add("ID cliente inválido");
            }
            if (clientID.Equals(null))
            {
                response.Errors.Add("ID cliente nulo");
            }

            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iClientRepository.GetByID(clientID);
            }
        }

        public async Task<DataResponse<ClientDTO>> GetByName(string clientName)
        {
            DataResponse<ClientDTO> response = new DataResponse<ClientDTO>();
            if (string.IsNullOrEmpty(clientName))
            {
                response.Errors.Add("Nome cliente inválido");
            }
            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iClientRepository.GetByName(clientName);
            }
        }

        public async Task<Response> Insert(ClientDTO client)
        {
            Response response = new Response();
            ClientValidator validate = new ClientValidator();
            ValidationResult result = validate.Validate(client);
            Response password = PasswordValidator.CheckPassword(client.Password, client.BirthDate);
           
            //Verifica se a senha está dentro dos padrões, caso esteja, hasheia e ela 
            if (password.HasErrors())
            {
                response.Errors.Add(password.Errors.ToString());
            }
            else
            {
                client.Password = HashUtils.HashPassword(client.Password);
            }

            //result.MergeValidationErrors(response);


            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    response.Errors.Add("Property " + failure.PropertyName + " failed validation. Error was: " + "(" + failure.ErrorMessage + ")");
                }

                return response;
            }

            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iClientRepository.Insert(client);
            }
        }

        public async Task<Response> Update(ClientDTO client)
        {
            Response response = new Response();
            ClientValidator validate = new ClientValidator();
            ValidationResult result = validate.Validate(client);
            Response password = PasswordValidator.CheckPassword(client.Password, client.BirthDate);

            //Verifica se a senha está dentro dos padrões, caso esteja, hasheia e ela 
            if (password.HasErrors())
            {
                response.Errors.Add(password.Errors.ToString());
            }
            else
            {
                client.Password = HashUtils.HashPassword(client.Password);
            }

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    response.Errors.Add("Property " + failure.PropertyName + " failed validation. Error was: " + "(" + failure.ErrorMessage + ")");
                }

                return response;
            }


            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iClientRepository.Update(client);
            }
        }
    }
}
