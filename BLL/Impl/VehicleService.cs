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
                return await _iVehicleRepository.Delete(idVehicle);
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
                return await _iVehicleRepository.Disable(idVehicle);
            }
        }

        public async Task<DataResponse<VehicleDTO>> GetActives()
        {
            return await _iVehicleRepository.GetActives();

        }

        public async Task<DataResponse<VehicleDTO>> GetAll()
        {
            return await _iVehicleRepository.GetAll();
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
                return await _iVehicleRepository.GetByID(vehicleID);
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
                return await _iVehicleRepository.GetByVehicleBoard(vehicleBoard);
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
                return await _iVehicleRepository.Insert(vehicle);
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
                return await _iVehicleRepository.Update(vehicle);
            }
        }
    }
}
