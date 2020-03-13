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
    public class ModelController: Controller
    {
        private IModelService _service;

        public ModelController(IModelService service)
        {
            this._service = service;
        }

        public async Task<ActionResult> Index()
        {


            DataResponse<ModelDTO> models = await _service.GetAll();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ModelDTO, ModelInsertViewModel>();
            });

            IMapper mapper = configuration.CreateMapper();

            List<ModelInsertViewModel> modelsViewModel =
                mapper.Map<List<ModelInsertViewModel>>(models.Data);

            ViewBag.Models = modelsViewModel;

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(ModelInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ModelInsertViewModel, ModelDTO>();
            });
            IMapper mapper = configuration.CreateMapper();

            ModelDTO dto = mapper.Map<ModelDTO>(viewModel);


            try
            {
                await _service.Insert(dto);
                return RedirectToAction("Index", "Models");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }
    }
}
