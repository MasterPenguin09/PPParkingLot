﻿using AutoMapper;
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
    public class LocationController: BaseController
    {
        private ILocationSevice _service;
        public LocationController(ILocationSevice sevice )
        {
            this._service = sevice;
        }

        public async Task<ActionResult> Index()
        {


            DataResponse<LocationDTO> locations = await _service.GetAll();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LocationDTO, LocationInsertViewModel>();
            });

            IMapper mapper = configuration.CreateMapper();

            List<LocationInsertViewModel> locationsViewModel =
            mapper.Map<List<LocationInsertViewModel>>(locations.Data);
            ViewBag.Locations = locationsViewModel;

            return View();
        }

        public  ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(LocationInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LocationInsertViewModel, LocationDTO>();
            });
            IMapper mapper = configuration.CreateMapper();

            LocationDTO dto = mapper.Map<LocationDTO>(viewModel);


            try
            {
                await _service.Insert(dto);
                return RedirectToAction("Index", "Location");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }



    }
}