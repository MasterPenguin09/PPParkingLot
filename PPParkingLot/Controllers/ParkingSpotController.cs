﻿using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using PPParkingLot.ControllersView;
using PPParkingLot.Models.Insert;
using PPParkingLot.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemCommons;

namespace PPParkingLot.Controllers
{
    public class ParkingSpotController : BaseController
    {
        private readonly IParkingSpotService _service;
        public ParkingSpotController(IParkingSpotService service)
        {
            this._service = service;
        }


        public async Task<ActionResult> Index()
        {
            DataResponse<ParkingSpotDTO> parkingSpot = await _service.GetAll();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ParkingSpotDTO, ParkingSpotQueryViewModel>();
            });

            IMapper mapper = configuration.CreateMapper();


            List<ParkingSpotQueryViewModel> ParkingSpotsViewModel = mapper.Map<List<ParkingSpotQueryViewModel>>(parkingSpot.Data);
        
            ViewBag.ParkingSpots = ParkingSpotsViewModel;
            IEnumerable<PPParkingLot.Models.Query.ParkingSpotQueryViewModel> returning = ParkingSpotsViewModel;
            return View(returning);
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(ParkingSpotInsertViewModel viewModel)
        {
            Response response = new Response();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ParkingSpotInsertViewModel, ParkingSpotDTO>();
            });

            IMapper mapper = configuration.CreateMapper();

            ParkingSpotDTO dto = mapper.Map<ParkingSpotDTO>(viewModel);

            response = await _service.Insert(dto);
            //Se funcionou, redireciona pra página inicial
            if (response.Success)
            {
                return RedirectToAction("Index", "ParkingSpot");
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
        public async Task<ActionResult> Update(ParkingSpotInsertViewModel viewModel)
        {
            Response response = new Response();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ParkingSpotInsertViewModel, ParkingSpotDTO>();
            });

            IMapper mapper = configuration.CreateMapper();

            ParkingSpotDTO dto = mapper.Map<ParkingSpotDTO>(viewModel);

            response = await _service.Update(dto);
            //Se funcionou, redireciona pra página inicial
            if (response.Success)
            {
                return RedirectToAction("Index", "ParkingSpot");
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
        public async Task<ActionResult> Disable(ParkingSpotInsertViewModel viewModel)
        {
            Response response = new Response();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ParkingSpotInsertViewModel, ParkingSpotDTO>();
            });

            IMapper mapper = configuration.CreateMapper();

            ParkingSpotDTO dto = mapper.Map<ParkingSpotDTO>(viewModel);
            response = await _service.Disable(dto.ID);
            //Se funcionou, redireciona pra página inicial
            if (response.Success)
            {
                return RedirectToAction("Index", "ParkingSpot");
            }
            else
            {
                ViewBag.ErrorMessage = response.Errors;
                return this.View();
            }

        }
    }

}
