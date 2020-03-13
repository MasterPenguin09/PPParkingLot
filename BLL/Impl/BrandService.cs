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
   public class BrandService : IBrandService
    {
        private IBrandRepository _iBrandRepository;
        public BrandService(IBrandRepository iBrandRep)
        {
            this._iBrandRepository = iBrandRep;
        }

        public async Task<Response> Delete(int idBrand)
        {
            Response response = new Response();
            if (idBrand<0)
            {
                response.Errors.Add("ID Inválido!");
            }
            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                response = await _iBrandRepository.Delete(idBrand);
                if (!response.Success)
                {
                    return response;
                }
                else
                {
                    return response;
                  
                 //Logger
                }
            }
        }

        

        //public async Task<Response> Disable(int idBrand)
        //{
        //    Response response = new Response();
        //    if (idBrand < 0)
        //    {
        //        response.Errors.Add("ID Inválido!");
        //    }
        //    if (response.HasErrors())
        //    {
        //        return response;
        //    }
        //    else
        //{
        //    return await _iBrandRepository.Disable(idBrand);
        //}
        //}

        public async Task<DataResponse<CLientDTO>> GetAll()
        {
            return await _iBrandRepository.GetAll();
        }

        public async Task<DataResponse<CLientDTO>> GetByID(int brandID)
        {
            DataResponse<CLientDTO> response = new DataResponse<CLientDTO>();
            if (brandID < 0)
            {
                response.Errors.Add("ID marca inválido");
            }
            if(brandID.Equals(null))
            {
                response.Errors.Add("ID marca nulo");
            }

            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iBrandRepository.GetByID(brandID);
            }
        }

        public async Task<DataResponse<CLientDTO>> GetByName(string brandName)
        {
            DataResponse<CLientDTO> response = new DataResponse<CLientDTO>();
            if (string.IsNullOrEmpty(brandName))
            {
                response.Errors.Add("Nome marca inválido");
            }
            if (brandName.Equals(null))
            {
                response.Errors.Add("Nome marca nulo");
            }

            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                return await _iBrandRepository.GetByName(brandName);
            }
        }

        public async Task<Response> Insert(CLientDTO brand)
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

        public async Task<Response> Update(CLientDTO brand)
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
                return await _iBrandRepository.Update(brand);
            }
        }
    }
}
