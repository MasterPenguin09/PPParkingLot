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
    public class ParkingSpotController: BaseController
    {
        private readonly IParkingSpotService _service;
        public ParkingSpotController(IParkingSpotService service)
        {
            this._service = service;
        }

        public async Task<ActionResult> Index()
        {
            DataResponse<ParkingSpotDTO> brands = await _service.GetAll();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ParkingSpotDTO, ParkingSpotInsertViewModel>();
            });

            IMapper mapper = configuration.CreateMapper();

            List<ParkingSpotInsertViewModel> ParkingSpotsViewModel =
            mapper.Map<List<ParkingSpotInsertViewModel>>(brands.Data);
            ViewBag.ParkingSpots = ParkingSpotsViewModel;

            return View();
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(ParkingSpotInsertViewModel viewModel)
        {

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ParkingSpotInsertViewModel, ParkingSpotDTO>();
            });

            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o ParkingSpotInsertViewModel em um ParkingSpotDTO
            ParkingSpotDTO dto = mapper.Map<ParkingSpotDTO>(viewModel);
            try
            {
                await _service.Insert(dto);
                //Se funcionou, redireciona pra página inicial
                return RedirectToAction("ParkingSpot", "Index");
            }
            catch (Exception ex)
            {
                //Se caiu aqui, o ParkingSpotService lançou uma exceção genérica, provavelmente por falha de acesso ao banco
                ViewBag.ErrorMessage = ex.Message;
            }
            return this.View();
            
        }

        public ActionResult Update()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Update(ParkingSpotInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ParkingSpotInsertViewModel, ParkingSpotDTO>();
            });

            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o ParkingSpotInsertViewModel em um ParkingSpotDTO
            ParkingSpotDTO dto = mapper.Map<ParkingSpotDTO>(viewModel);
            try
            {
                await _service.Update(dto);
                //Se funcionou, redireciona pra página inicial
                return RedirectToAction("ParkingSpot", "Index");
            }
            catch (Exception ex)
            {
                //Se caiu aqui, o ParkingSpotService lançou uma exceção genérica, provavelmente por falha de acesso ao banco
                ViewBag.ErrorMessage = ex.Message;
            }
            return this.View();
        }
        public ActionResult Disable()
        {
            return this.View();
        }
        public async Task<ActionResult> Disable(ParkingSpotInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ParkingSpotInsertViewModel, ParkingSpotDTO>();
            });

            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o ParkingSpotInsertViewModel em um ParkingSpotDTO
            ParkingSpotDTO dto = mapper.Map<ParkingSpotDTO>(viewModel);
            try
            {
                await _service.Disable(dto.ID);
                //Se funcionou, redireciona pra página inicial
                return RedirectToAction("ParkingSpot", "Index");
            }
            catch (Exception ex)
            {
                //Se caiu aqui, o ParkingSpotService lançou uma exceção genérica, provavelmente por falha de acesso ao banco
                ViewBag.ErrorMessage = ex.Message;
            }
            return this.View();
        }
    }        
    
}
