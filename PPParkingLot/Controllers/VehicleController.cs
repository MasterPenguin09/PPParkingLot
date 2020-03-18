
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
    public class VehicleController: BaseController
    {
        private readonly IVehicleService _service;
        public VehicleController(IVehicleService service)
        {
            this._service = service;
        }
        public async Task<ActionResult> Index()
        {
            DataResponse<VehicleDTO> brands = await _service.GetAll();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VehicleDTO, VehicleInsertViewModel>();
            });

            IMapper mapper = configuration.CreateMapper();

            List<VehicleInsertViewModel> VehiclesViewModel =
            mapper.Map<List<VehicleInsertViewModel>>(brands.Data);
            ViewBag.Vehicles = VehiclesViewModel;

            return View();
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(VehicleInsertViewModel viewModel)
        {

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VehicleInsertViewModel, VehicleDTO>();
            });

            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o VehicleInsertViewModel em um VehicleDTO
            VehicleDTO dto = mapper.Map<VehicleDTO>(viewModel);
            try
            {
                await _service.Insert(dto);
                //Se funcionou, redireciona pra página inicial
                return RedirectToAction("Vehicle", "Index");
            }
            catch (Exception ex)
            {
                //Se caiu aqui, o VehicleService lançou uma exceção genérica, provavelmente por falha de acesso ao banco
                ViewBag.ErrorMessage = ex.Message;
            }
            return this.View();
        }

        public ActionResult Update()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Update(VehicleInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VehicleInsertViewModel, VehicleDTO>();
            });

            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o VehicleInsertViewModel em um VehicleDTO
            VehicleDTO dto = mapper.Map<VehicleDTO>(viewModel);
            try
            {
                await _service.Update(dto);
                //Se funcionou, redireciona pra página inicial
                return RedirectToAction("Vehicle", "Index");
            }
            catch (Exception ex)
            {
                //Se caiu aqui, o VehicleService lançou uma exceção genérica, provavelmente por falha de acesso ao banco
                ViewBag.ErrorMessage = ex.Message;
            }
            return this.View();
        }
        public ActionResult Disable()
        {
            return this.View();
        }
        public async Task<ActionResult> Disable(VehicleInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VehicleInsertViewModel, VehicleDTO>();
            });

            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o VehicleInsertViewModel em um VehicleDTO
            VehicleDTO dto = mapper.Map<VehicleDTO>(viewModel);
            try
            {
                await _service.Disable(dto.ID);
                //Se funcionou, redireciona pra página inicial
                return RedirectToAction("Vehicle", "Index");
            }
            catch (Exception ex)
            {
                //Se caiu aqui, o VehicleService lançou uma exceção genérica, provavelmente por falha de acesso ao banco
                ViewBag.ErrorMessage = ex.Message;
            }
            return this.View();
        }

               

    }
}

