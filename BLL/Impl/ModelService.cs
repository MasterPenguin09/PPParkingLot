﻿using BLL.Log4net;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Validators;

using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCommons;

namespace BusinessLogicalLayer.Impl
{
    public class ModelService : IModelService
    {
        /// <summary>
        /// É uma classe publica que herda de uma interface interna de mesmo nome (+I no começo)
        /// Sua função é trazer os serviços do Model ligadas a logica dos negocios, com auxilio de
        /// uma interface privada que traz as regras do Banco de Dados ligada a Model
        /// </summary>
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(ModelService));

        private IModelRepository _iModelRepository;
        public ModelService(IModelRepository iModelRep)
        {
            this._iModelRepository = iModelRep;
        }

        public async Task<Response> Delete(int idModel)
        {
            Response response = new Response();
            if (idModel < 0)
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
                    return response = await _iModelRepository.Delete(idModel);

                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }
        }

        public async Task<DataResponse<ModelDTO>> GetAll()
        {
            DataResponse<ModelDTO> response = new DataResponse<ModelDTO>();
            try
            {
                return response = await _iModelRepository.GetAll();
            }
            catch (Exception ex)
            {
                _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                response.Errors.Add("DataBase error, contact the system owner");
                return response;
            }
        }

        public async Task<DataResponse<ModelDTO>> GetByID(int modelID)
        {
            DataResponse<ModelDTO> response = new DataResponse<ModelDTO>();
            if (modelID < 0)
            {
                response.Errors.Add("ID modelo inválido");
            }
            if (modelID.Equals(null))
            {
                response.Errors.Add("ID modelo nulo");
            }

            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                try
                {
                    return response = await _iModelRepository.GetByID(modelID);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }
        }

        public async Task<Response> Insert(ModelDTO model)
        {
            Response response = new Response();
            ModelValidator validate = new ModelValidator();
            ValidationResult result = validate.Validate(model);

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
                try
                {
                    return response = await _iModelRepository.Insert(model);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }

        }

        public async Task<Response> Update(ModelDTO model)
        {
            Response response = new Response();
            ModelValidator validate = new ModelValidator();
            ValidationResult result = validate.Validate(model);

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
                try
                {
                    return response = await _iModelRepository.Update(model);
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
