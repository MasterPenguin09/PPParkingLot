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
                return await _iParkingSpotRepository.Delete(idPakingSpot);
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
                return await _iParkingSpotRepository.Disable(idPakingSpot);
            }
        }

        public async Task<DataResponse<ParkingSpotDTO>> GetActives()
        {
            return await _iParkingSpotRepository.GetActives();
        }

        public async Task<DataResponse<ParkingSpotDTO>> GetAll()
        {
            return await _iParkingSpotRepository.GetAll();

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
                return await _iParkingSpotRepository.GetByID(idPakingSpot);
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
                return await _iParkingSpotRepository.Insert(pakingSpot);
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
                return await _iParkingSpotRepository.Update(pakingSpot);
            }
        }
    }
}
