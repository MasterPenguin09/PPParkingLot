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
        /// <summary>
        /// É uma classe publica que herda de uma interface interna de mesmo nome (+I no começo)
        /// Sua função é trazer os serviços da Brand ligadas a logica dos negocios, com auxilio de
        /// uma interface privada que traz as regras do Banco de Dados ligada a Brand
        /// </summary>

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
                    response.Success = true;
                    return response;
                    //Logger
                }
            }
        }

        public async Task<Response> Disable(int idBrand)
        {
            Response response = new Response();
            if (idBrand < 0)
            {
                response.Errors.Add("ID Inválido!");
            }
            if (response.HasErrors())
            {
                return response;
            }
            else
        {
            return await _iBrandRepository.Disable(idBrand);
        }
        }

        public async Task<DataResponse<BrandDTO>> GetAll()
        {
            return await _iBrandRepository.GetAll();
        }

        public async Task<DataResponse<BrandDTO>> GetByID(int brandID)
        {
            DataResponse<BrandDTO> response = new DataResponse<BrandDTO>();
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

        public async Task<DataResponse<BrandDTO>> GetByName(string brandName)
        {
            DataResponse<BrandDTO> response = new DataResponse<BrandDTO>();
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

        public async Task<Response> Update(BrandDTO brand)
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
