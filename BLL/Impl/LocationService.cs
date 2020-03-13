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
                response.Errors.Add("ID locação inválido");
            }
            if (location.Equals(null))
            {
                response.Errors.Add("ID locação nulo");
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

        /// <summary>
        /// Método que executa o "fechamento de vaga" (quando o cliente sai)
        /// </summary>
        /// <param name="idLocation"></param>
        /// <returns></returns>
        private DataResponse<LocationDTO> CalculatePrice(int idLocation)
        {
            DataResponse<LocationDTO> response = new DataResponse<LocationDTO>();

            //Busca a locação pelo id
            Task<DataResponse<LocationDTO>> temp_location = _iLocationRepository.GetByID(idLocation);

            //Armazena a locação encontrada 
            LocationDTO location = temp_location.Result.Data.FirstOrDefault();

            //Adiciona a data de saída a locação 
            location.ExitTime = DateTime.Now;

            //Subtrai o valor de saída com o valor de entrada 
            TimeSpan tempoDeLocacao = location.ExitTime.Value.Subtract(location.EntryTime);

            //Pega a o valor subtraído em horas e multiplica pelo valor/hora da vaga
            double valorLocacao = tempoDeLocacao.Hours * location.ParkingSpot.ValuePerHour;

            //Adiciona o valor da locação no banco 
            location.Value = valorLocacao;
            if (_iLocationRepository.Update(location).Result.Success)
            {
                //Caso for adicionada com sucesso ela será desabilitada, pois o cliente saiu 
                if (_iLocationRepository.Disable(location.ID).Result.Success)
                {
                    //Se o disable funcionar, adiociona a locação desse escopo e retorna 
                    response.Success = true;
                    response.Data.Add(location);
                    return response;
                }
                //Caso o Disable falhe 
                response.Errors.Add("Erro de fechamento de vaga!");
            }
            //Caso o Update falhe
            else
            {
                response.Errors.Add("Erro de Update de vaga!");
            }
            //Retorna erros caso o Update tenha falhado
            return response;
           
          
        }


    }
 }

