
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

    //queria entender o motivo pro Gabriel duvidar tento da minha capacidade mental
    public class VehicleController: BaseController
    {
        private readonly IVehicleService _service;
        public VehicleController(IVehicleService service)
        {
            this._service = service;
        }

        public async Task<ActionResult> Index()
        {
            DataResponse<VehicleDTO> vehicle = await _service.GetAll();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VehicleDTO, VehicleInsertViewModel>();
            });

            IMapper mapper = configuration.CreateMapper();

            List<VehicleInsertViewModel> vehicleViewModel = mapper.Map<List<VehicleInsertViewModel>>(vehicle.Data);

            ViewBag.Vehicles = vehicleViewModel;

            return View();
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(VehicleInsertViewModel viewModel)
        {
            Response response = new Response();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VehicleInsertViewModel, VehicleDTO>();
            });

            IMapper mapper = configuration.CreateMapper();
            VehicleDTO dto = mapper.Map<VehicleDTO>(viewModel);

            response = await _service.Insert(dto);
            //Se funcionou, redireciona pra página inicial
            if (response.Success)
            {
                return RedirectToAction("Index", "Vehicle");
            }
            else
            {
                ViewBag.ErrorMessage = response.Errors;
                return this.View();
            }
        }

        public ActionResult Update()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Update(VehicleInsertViewModel viewModel)
        {
            Response response = new Response();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VehicleInsertViewModel, VehicleDTO>();
            });

            IMapper mapper = configuration.CreateMapper();
            VehicleDTO dto = mapper.Map<VehicleDTO>(viewModel);

            response = await _service.Update(dto);
            //Se funcionou, redireciona pra página inicial
            if (response.Success)
            {
                return RedirectToAction("Index", "Vehicle");
            }
            else
            {
                ViewBag.ErrorMessage = response.Errors;
                return this.View();
            }
        }

        public ActionResult Disable()
        {
            return this.View();
        }
        public async Task<ActionResult> Disable(VehicleInsertViewModel viewModel)
        {
            Response response = new Response();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VehicleInsertViewModel, VehicleDTO>();
            });

            IMapper mapper = configuration.CreateMapper();

            VehicleDTO dto = mapper.Map<VehicleDTO>(viewModel);
            response = await _service.Disable(dto.ID);
            //Se funcionou, redireciona pra página inicial
            if (response.Success)
            {
                return RedirectToAction("Index", "Vehicle");
            }
            else
            {
                ViewBag.ErrorMessage = response.Errors;
                return this.View();
            }

        }


    }
}

