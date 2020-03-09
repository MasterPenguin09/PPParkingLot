using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Validator;
using BusinessLogicalLayer.Validators;
using Common.FlowControl;
using DataAccessLayer.Interfaces_EFCore_;
using DataAccessLayer.Repositories_EFCore_;
using DataTransferObject;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Impl
{
    public class LocationService : ILocationService
    {
        private ILocationRepository _iLocationRepository;

        public LocationService()
        {
        }

        public LocationService(ILocationRepository iLocationRep)
        {
            this._iLocationRepository = iLocationRep;
        }


        public async Task<Response> Create(LocationDTO location)
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
                return await _iLocationRepository.Create(location);
            }

        }

        public async Task<Response> Delete(LocationDTO location)
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
                return await _iLocationRepository.Delete(location);
            }
        }



        public async Task<Response> Disable(LocationDTO location)
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

        public async Task<DataResponse<LocationDTO>> GetByID(int locationID)
        {
            return await _iLocationRepository.GetByID();
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
        

        public interface ILocationService
        {
        }
    }
 }

