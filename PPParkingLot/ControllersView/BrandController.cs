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


        [HttpPost]
        public async Task<ActionResult> Delete(BrandInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandInsertViewModel, BrandDTO>();
            });
            IMapper mapper = configuration.CreateMapper();

            BrandDTO dto = mapper.Map<BrandDTO>(viewModel);

            await _service.Delete(dto.ID);

            //Fazer lógica 

            return View();
        }

    }
}

// Olha o service 
// Pega um método ex: Delete
// Vai no controller 
// Copia um exemplo e troca o nome pra Delete 
// Ver se precisa de httpPost ou get
// Fazer o conversor de view pra DTO 
// Chamar o método (com a interface _service)
// Jogar o objeto dto convertido dentro do método da interface 
// Ex: await _service.Delete(dto);
// Fazer a view bag pra pegar os erros que possam vir do delete 
// Esses erros estão dentro do objeto Response que ele retorna 
// Ai é só pegar eles e jogar dentro da viewBag
// Criar a tela (Empty)
// Copiar os campos do marcelo 
// Fazer o JS e tudo mais 

