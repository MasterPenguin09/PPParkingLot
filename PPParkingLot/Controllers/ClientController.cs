using AutoMapper;
using BusinessLogicalLayer.Impl;
using BusinessLogicalLayer.Interfaces;
using DAL.Context_EFCore_;
using DataTransferObject;
using DTO;
using Microsoft.AspNetCore.Mvc;
using PPParkingLot.ControllersView;
using PPParkingLot.Models.Insert;
using PPParkingLot.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemCommons;

namespace PPParkingLot.Controllers
{
    public class ClientController: BaseController
    {
       private readonly IClientService _service;
        public ClientController(IClientService service)
        {
            this._service = service;
        }


        public async Task<ActionResult> Index()
        {


            DataResponse<ClientDTO> brands = await _service.GetAll();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientDTO, ClientInsertViewModel>();
            });

            IMapper mapper = configuration.CreateMapper();

            List<ClientInsertViewModel> clientsViewModel =
            mapper.Map<List<ClientInsertViewModel>>(brands.Data);
            ViewBag.Clients = clientsViewModel;

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(ClientInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientInsertViewModel, ClientDTO>();
            });
            IMapper mapper = configuration.CreateMapper();

            ClientDTO dto = mapper.Map<ClientDTO>(viewModel);


            try
            {
                await _service.Insert(dto);
                return RedirectToAction("Index", "Clients");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }

    }

}
