using BusinessLogicalLayer.Interfaces;
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
   public class BrandService : IBrandService
    {
        private IBrandRepository _iBrandRepository;
        public BrandService(IBrandRepository iBrandRep)
        {
            this._iBrandRepository = iBrandRep;
        }

        public async Task<Response> Delete(BrandDTO brand)
        {
            Response response = new Response();
            BrandValidator validate = new BrandValidator();
            ValidationResult result = validate.Validate(brand);

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
                return await _iBrandRepository.Delete(brand);
            }
        }

        public async Task<Response> Disable(BrandDTO brand)
        {
            Response response = new Response();
            BrandValidator validate = new BrandValidator();
            ValidationResult result = validate.Validate(brand);

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
                return await _iBrandRepository.Disable(brand);
            }
        }

        public async Task<DataResponse<BrandDTO>> GetActives()
        {
                return await _iBrandRepository.GetActives();
        }

        public async Task<DataResponse<BrandDTO>> GetAll()
        {
            return await _iBrandRepository.GetAll();
        }

        public Task<DataResponse<BrandDTO>> GetByID(int brandID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<BrandDTO>> GetByName(string brandName)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Insert(BrandDTO brand)
        {
            Response response = new Response();
            BrandValidator validate = new BrandValidator();
            ValidationResult result = validate.Validate(brand);

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
                return await _iBrandRepository.Insert(brand);
            }
        }

        public Task<Response> Update(BrandDTO brand)
        {
            throw new NotImplementedException();
        }
    }
}
