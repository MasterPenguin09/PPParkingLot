using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Validator;
using BusinessLogicalLayer.Validators;
using DataAccessLayer.Interfaces_EFCore_;
using DataAccessLayer.Repositories_EFCore_;
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
    public class LocationService : ILocationSevice
    {
        /// <summary>
        /// É uma classe publica que herda de uma interface interna de mesmo nome (+I no começo)
        /// Sua função é trazer os serviços do Location ligadas a logica dos negocios, com auxilio de
        /// uma interface privada que traz as regras do Banco de Dados ligada a Location
        /// </summary>

        private ILocationRepository _iLocationRepository;

        public LocationService(ILocationRepository iLocationRep)
        {
            this._iLocationRepository = iLocationRep;
        }






        public async Task<Response> Delete(int location)
        {
            Response response = new Response();
            if (location < 0)
            {
                response.Errors.Add("ID Inválido!");
            }
            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iLocationRepository.Delete(location);
            }
        }

        public async Task<Response> Disable(int location)
        {
            Response response = new Response();
            if (location < 0)
            {
                response.Errors.Add("ID Inválido!");
            }
            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iLocationRepository.Disable(location);
            }
        }

        public async Task<DataResponse<LocationDTO>> GetActives()
        {
            return await _iLocationRepository.GetActives();
        }

        public async Task<DataResponse<LocationDTO>> GetAll()
        {
            return await _iLocationRepository.GetAll();
        }

        public async Task<DataResponse<LocationDTO>> GetByID(int location)
        {
            DataResponse<LocationDTO> response = new DataResponse<LocationDTO>();
            if (location < 0)
            {
                response.Errors.Add("ID cliente inválido");
            }
            if (location.Equals(null))
            {
                response.Errors.Add("ID cliente nulo");
            }

            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iLocationRepository.GetByID(location);
            }
        }

        public Task<DataResponse<LocationDTO>> GetByValue(double locationValue)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Insert(LocationDTO location)
        {
            Response response = new Response();
            LocationValidator validate = new LocationValidator();
            ValidationResult result = validate.Validate(location);
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
                return await _iLocationRepository.Insert(location);
            }
        }

        public async Task<Response> Update(LocationDTO location)
        {
            Response response = new Response();
            LocationValidator validate = new LocationValidator();
            ValidationResult result = validate.Validate(location);

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
                return await _iLocationRepository.Update(location);
            }
        }
        private Response CalculatePrice(int idLocation)
        {
            Response response = new Response();
            Task<DataResponse<LocationDTO>> location = _iLocationRepository.GetByID(idLocation);
            LocationDTO locacao = location.Result.Data.FirstOrDefault();
            locacao.ExitTime = DateTime.Now;
            TimeSpan tempoDeLocacao = locacao.ExitTime.Value.Subtract(locacao.EntryTime);
            double valorLocacao = tempoDeLocacao.Hours * locacao.ParkingSpot.ValuePerHour;
            locacao.Value = valorLocacao;
            if (_iLocationRepository.Update(locacao).Result.Success)
            {
                if (_iLocationRepository.Disable(locacao.ID).Result.Success)
                {
                    response.Success = true;
                    return response;
                }
                response.Errors.Add("Erro de fechamento de vaga!");
            }
            else
            {
                response.Errors.Add("Erro de Update de vaga!");
            }

            return response;
           
          
        }


    }
 }

