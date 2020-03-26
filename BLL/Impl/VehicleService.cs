using BLL.Log4net;
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
    public class VehicleService : IVehicleService
    {

        /// <summary>
        /// É uma classe publica que herda de uma interface interna de mesmo nome (+I no começo)
        /// Sua função é trazer os serviços do Vehicle ligadas a logica dos negocios, com auxilio de
        /// uma interface privada que traz as regras do Banco de Dados ligada a Vehicle
        /// </summary>
        /// 

        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(VehicleService));

        private IVehicleRepository _iVehicleRepository;
        public VehicleService(IVehicleRepository iVehicleRep)
        {
            this._iVehicleRepository = iVehicleRep;
        }

        public async Task<Response> Delete(int idVehicle)
        {
            Response response = new Response();
            if (idVehicle < 0)
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
                    return response = await _iVehicleRepository.Delete(idVehicle);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }
        }

        public async Task<Response> Disable(int idVehicle)
        {
            Response response = new Response();
            if (idVehicle < 0)
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
                    return response = await _iVehicleRepository.Disable(idVehicle);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }
        }

        public async Task<DataResponse<VehicleDTO>> GetActives()
        {
            DataResponse<VehicleDTO> response = new DataResponse<VehicleDTO>();
            try
            {
                return response = await _iVehicleRepository.GetActives();
            }
            catch (Exception ex)
            {
                _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                response.Errors.Add("DataBase error, contact the system owner");
                return response;
            }
        }

        public async Task<DataResponse<VehicleDTO>> GetAll()
        {
            DataResponse<VehicleDTO> response = new DataResponse<VehicleDTO>();
            try
            {
                return response = await _iVehicleRepository.GetAll();
            }
            catch (Exception ex)
            {
                _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                response.Errors.Add("DataBase error, contact the system owner");
                return response;
            }
        }

        public async Task<DataResponse<VehicleDTO>> GetByID(int vehicleID)
        {
            DataResponse<VehicleDTO> response = new DataResponse<VehicleDTO>();
            if (vehicleID < 0)
            {
                response.Errors.Add("ID veículo inválido");
            }
            if (vehicleID.Equals(null))
            {
                response.Errors.Add("ID veículo nulo");
            }

            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                try
                {
                    return response = await _iVehicleRepository.GetByID(vehicleID);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }
        }

        public async Task<DataResponse<VehicleDTO>> GetByVehicleBoard(string vehicleBoard)
        {
            DataResponse<VehicleDTO> response = new DataResponse<VehicleDTO>();
            if (string.IsNullOrEmpty(vehicleBoard))
            {
                response.Errors.Add("Placa inválida");
            }

            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                try
                {
                    return response = await _iVehicleRepository.GetByVehicleBoard(vehicleBoard);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }
        }

        public async Task<Response> Insert(VehicleDTO vehicle)
        {
            Response response = new Response();
            VehicleValidator validate = new VehicleValidator();
            ValidationResult result = validate.Validate(vehicle);

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
                    return response = await _iVehicleRepository.Insert(vehicle);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }
        }

        public async Task<Response> Update(VehicleDTO vehicle)
        {
            Response response = new Response();
            VehicleValidator validate = new VehicleValidator();
            ValidationResult result = validate.Validate(vehicle);

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
                    return response = await _iVehicleRepository.Update(vehicle);
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
