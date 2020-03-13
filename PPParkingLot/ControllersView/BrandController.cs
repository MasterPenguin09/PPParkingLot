using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using PPParkingLot.Models.Insert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemCommons;

namespace PPParkingLot.Controllers
{
    public class BrandController : Controller
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

            List<BrandInsertViewModel> brandsViewModel =
            mapper.Map<List<BrandInsertViewModel>>(brands.Data);
            ViewBag.Brands = brandsViewModel;

            return View();
        }

        public  ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(BrandInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandInsertViewModel, BrandDTO>();
            });
            IMapper mapper = configuration.CreateMapper();

            BrandDTO dto = mapper.Map<BrandDTO>(viewModel);


            try
            {
                await _service.Insert(dto);
                return RedirectToAction("Index", "Brand");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }

    }
}
