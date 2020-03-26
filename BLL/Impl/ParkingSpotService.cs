using BLL.Log4net;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Validators;

using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCommons;

namespace BusinessLogicalLayer.Impl
{
    public class ParkingSpotService : IParkingSpotService
    {
        /// <summary>
        /// É uma classe publica que herda de uma interface interna de mesmo nome (+I no começo)
        /// Sua função é trazer os serviços do ParkingSpot ligadas a logica dos negocios, com auxilio de
        /// uma interface privada que traz as regras do Banco de Dados ligada a ParingSpot
        /// </summary>
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(ParkingSpotService));

        private IParkingSpotRepository _iParkingSpotRepository;
        public ParkingSpotService(IParkingSpotRepository iParkingRep)
        {
            this._iParkingSpotRepository = iParkingRep;
        }

        public async Task<Response> Delete(int idPakingSpot)
        {
            Response response = new Response();
            if (idPakingSpot < 0)
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
                    return response = await _iParkingSpotRepository.Delete(idPakingSpot);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }
        }

        public async Task<Response> Disable(int idPakingSpot)
        {
            Response response = new Response();
            if (idPakingSpot < 0)
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
                    return response = await _iParkingSpotRepository.Disable(idPakingSpot);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }
        }

        public async Task<DataResponse<ParkingSpotDTO>> GetActives()
        {
            DataResponse<ParkingSpotDTO> response = new DataResponse<ParkingSpotDTO>();
            try
            {
                return response = await _iParkingSpotRepository.GetActives();
            }
            catch (Exception ex)
            {
                _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                response.Errors.Add("DataBase error, contact the system owner");
                return response;
            }
        }

        public async Task<DataResponse<ParkingSpotDTO>> GetAll()
        {
            DataResponse<ParkingSpotDTO> response = new DataResponse<ParkingSpotDTO>();
            try
            {
                return response = await _iParkingSpotRepository.GetAll();
            }
            catch (Exception ex)
            {
                _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                response.Errors.Add("DataBase error, contact the system owner");
                return response;
            }
        }

        public async Task<DataResponse<ParkingSpotDTO>> GetByID(int idPakingSpot)
        {
            DataResponse<ParkingSpotDTO> response = new DataResponse<ParkingSpotDTO>();
            if (idPakingSpot < 0)
            {
                response.Errors.Add("ID vaga inválido");
            }
            if (idPakingSpot.Equals(null))
            {
                response.Errors.Add("ID vaga nulo");
            }

            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                try
                {
                    return await _iParkingSpotRepository.GetByID(idPakingSpot);

                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }
        }

        public async Task<Response> Insert(ParkingSpotDTO pakingSpot)
        {
            Response response = new Response();
            ParkingSpotValidator validate = new ParkingSpotValidator();
            ValidationResult result = validate.Validate(pakingSpot);

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
                    return response = await _iParkingSpotRepository.Insert(pakingSpot);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }
        }

        public async Task<Response> Update(ParkingSpotDTO pakingSpot)
        {
            Response response = new Response();
            ParkingSpotValidator validate = new ParkingSpotValidator();
            ValidationResult result = validate.Validate(pakingSpot);

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
                    return response = await _iParkingSpotRepository.Update(pakingSpot);
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
