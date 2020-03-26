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
    public class BrandService : IBrandService
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(BrandService));


        private IBrandRepository _iBrandRepository;

        public BrandService(IBrandRepository iBrandRep)
        {
            this._iBrandRepository = iBrandRep;
        }

        public async Task<Response> Delete(int idBrand)
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
                try
                {
                    return response = await _iBrandRepository.Delete(idBrand);

                }
                catch (Exception ex)
                {
                    //_log.Info(response.Errors);
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
            }
        }

        public async Task<DataResponse<BrandDTO>> GetAll()
        {
            DataResponse<BrandDTO> response = new DataResponse<BrandDTO>();
            try
            {
                return response = await _iBrandRepository.GetAll();

            }
            catch (Exception ex)
            {
                _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                response.Errors.Add("DataBase error, contact the system owner");
                return response;
            }

        }

        public async Task<DataResponse<BrandDTO>> GetByID(int brandID)
        {
            DataResponse<BrandDTO> response = new DataResponse<BrandDTO>();
            if (brandID < 0)
            {
                response.Errors.Add("ID marca inválido");
            }
            if (brandID.Equals(null))
            {
                response.Errors.Add("ID marca nulo");
            }

            if (response.HasErrors())
            {
                return response;
            }
            else
            {
                try
                {
                    return response = await _iBrandRepository.GetByID(brandID);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
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
                try
                {
                    return response = await _iBrandRepository.GetByName(brandName);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
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
                try
                { 
                    return response = await _iBrandRepository.Insert(brand);
                }
                catch (Exception ex)
                {
                    _log.Error(ex + "\nStackTrace: " + ex.StackTrace);
                    response.Errors.Add("DataBase error, contact the system owner");
                    return response;
                }
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
                try
                {
                    return response = await _iBrandRepository.Update(brand);
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
