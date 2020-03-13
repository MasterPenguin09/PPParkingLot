using BusinessLogicalLayer.Interfaces;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using PPParkingLot.Models.Insert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Controllers
{
    public class BrandViewController : Controller
    {
        private IBrandService _service;
        public BrandViewController(IBrandService service)
        {
            this._service = service;
        }

        public async Task<ActionResult> Index()
        {


           List<BrandDTO> brands = await _service.GetAll().Result.Data;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandDTO, BrandInsertViewModel>();
            });
            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o ClienteInsertViewModel em um ClienteDTO
            List<BrandInsertViewModel> brandsViewModel =
                mapper.Map<List<BrandInsertViewModel>>(brands);

            ViewBag.Categorias = brandsViewModel;

            return View();
        }

        public async Task<ActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Cadaster(BrandInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandInsertViewModel, BrandDTO>();
            });
            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o ClienteInsertViewModel em um ClienteDTO
            BrandDTO dto = mapper.Map<BrandDTO>(viewModel);

          
            try
            {
                await _service.Insert(dto);
                return RedirectToAction("Index", "Produto");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }

    }
}
