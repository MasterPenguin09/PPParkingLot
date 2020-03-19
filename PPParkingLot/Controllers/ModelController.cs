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
    public class ModelController : BaseController
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

            List<ModelInsertViewModel> modelsViewModel = mapper.Map<List<ModelInsertViewModel>>(models.Data);

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
            Response response = new Response();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ModelInsertViewModel, ModelDTO>();
            });
            IMapper mapper = configuration.CreateMapper();

            ModelDTO dto = mapper.Map<ModelDTO>(viewModel);

            response = await _service.Insert(dto);

            if (response.Success)
            {
                return RedirectToAction("Index", "Model");
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
        public async Task<ActionResult> Delete(ModelInsertViewModel viewModel)
        {
            Response response = new Response();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ModelInsertViewModel, ModelDTO>();
            });

            IMapper mapper = configuration.CreateMapper();

            ModelDTO dto = mapper.Map<ModelDTO>(viewModel);
            response = await _service.Delete(dto.ID);
            //Se funcionou, redireciona pra página inicial
            if (response.Success)
            {
                return RedirectToAction("Index", "Model");
            }
            else
            {
                ViewBag.ErrorMessage = response.Errors;
                return this.View();
            }
        }
    }
}
