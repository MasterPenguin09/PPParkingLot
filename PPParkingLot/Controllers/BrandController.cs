using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using PPParkingLot.ControllersView;
using PPParkingLot.Models.Insert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemCommons;

namespace PPParkingLot.Controllers
{
    public class BrandController : BaseController
    {
        private IBrandService _service;
        public BrandController(IBrandService service)
        {
            this._service = service;
        }

        public async Task<ActionResult> Index()
        {
            DataResponse<BrandDTO> brands = await _service.GetAll();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandDTO, BrandInsertViewModel>();
            });

            IMapper mapper = configuration.CreateMapper();

            List<BrandInsertViewModel> brandsViewModel = mapper.Map<List<BrandInsertViewModel>>(brands.Data);

            ViewBag.Models = brandsViewModel;

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(BrandInsertViewModel viewModel)
        {
            Response response = new Response();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandInsertViewModel, BrandDTO>();
            });
            IMapper mapper = configuration.CreateMapper();

            BrandDTO dto = mapper.Map<BrandDTO>(viewModel);

            response = await _service.Insert(dto);

            if (response.Success)
            {
                return RedirectToAction("Index", "Brand");
            }
            else
            {
                ViewBag.ErrorMessage = response.Errors;
                return this.View();
            }
        }

        public ActionResult Delete()
        {
            return this.View();
        }
        public async Task<ActionResult> Delete(BrandInsertViewModel viewModel)
        {
            Response response = new Response();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandInsertViewModel, BrandDTO>();
            });

            IMapper mapper = configuration.CreateMapper();

            BrandDTO dto = mapper.Map<BrandDTO>(viewModel);
            response = await _service.Delete(dto.ID);
            //Se funcionou, redireciona pra página inicial
            if (response.Success)
            {
                return RedirectToAction("Index", "Brand");
            }
            else
            {
                ViewBag.ErrorMessage = response.Errors;
                return this.View();
            }
        }
    }
}



