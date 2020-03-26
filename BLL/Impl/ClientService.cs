
using BLL.Log4net;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Security;
using BusinessLogicalLayer.Validators;
using DAL.Context_EFCore_;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using DTO;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SystemCommons;

namespace BusinessLogicalLayer.Impl
{
    public class ClientService : IClientService
    {
        /// <summary>
        /// É uma classe publica que herda de uma interface interna de mesmo nome (+I no começo)
        /// Sua função é trazer os serviços do Client ligadas a logica dos negocios, com auxilio de
        /// uma interface privada que traz as regras do Banco de Dados ligada ao CLient
        /// </summary>
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(ClientService));


        private IClientRepository _iClientRepository;
        private SmartParkingContext _context;
        public ClientService(IClientRepository iClientRep, SmartParkingContext context)
        {
            this._iClientRepository = iClientRep;
            this._context = context;
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
                try
                {
                    return response = await _iClientRepository.Delete(idClient);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }

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
                try
                {
                    return response = await _iClientRepository.Disable(idClient);

                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }
        }

        public async Task<DataResponse<ClientDTO>> GetActives()
        {
            DataResponse<ClientDTO> response = new DataResponse<ClientDTO>();
            try
            {
                return response = await _iClientRepository.GetActives();
            }
            catch (Exception ex)
            {
                _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                response.Errors.Add("DataBase error, contact the system owner");
                return response;
            }

        }

        public async Task<DataResponse<ClientDTO>> GetAll()
        {
            DataResponse<ClientDTO> response = new DataResponse<ClientDTO>();
            try
            {
                return response = await _iClientRepository.GetAll();

            }
            catch (Exception ex)
            {
                _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                response.Errors.Add("DataBase error, contact the system owner");
                return response;
            }
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
                try
                {
                    return response = await _iClientRepository.GetByID(clientID);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }

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
                try
                {
                    return response = await _iClientRepository.GetByName(clientName);

                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }

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
                    //Caso haja erros no validator, serão adicionados na response.Errors do client
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
                try
                {
                    client.AccessLevel = DataTransferObject.Enums.EAccessLevel.Client;
                    client.SystemEntranceDate = DateTime.Now;
                    client.IsActive = true;

                    return response = await _iClientRepository.Insert(client);

                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }
        }

        public async Task<DataResponse<ClientDTO>> GetByEmail(string emailClient)
        {
            DataResponse<ClientDTO> response = new DataResponse<ClientDTO>();
            if (string.IsNullOrEmpty(emailClient))
            {
                response.Errors.Add("Email cliente inválido");
            }
            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                try
                {
                    return response = await _iClientRepository.GetByEmail(emailClient);

                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }
        }

        public async Task<DataResponse<ClientDTO>> Login(string email, string password)
        {
            DataResponse<ClientDTO> response = new DataResponse<ClientDTO>();

            if (string.IsNullOrEmpty(email))
            {
                response.Errors.Add("Email inválido");
                return response;
            }
            else
            {
                response = await GetByEmail(email);

                if (response.Success)
                {
                    ClientDTO cli = response.Data[0];
                    if (HashUtils.HashPassword(password).Equals(cli.Password))
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Senha inválida");
                        response.Success = false;
                        return response;
                    }
                }
                return response;
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
                try
                {
                    return response = await _iClientRepository.Update(client);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }
        }
    }
}
