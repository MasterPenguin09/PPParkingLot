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
using PPParkingLot.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemCommons;

namespace PPParkingLot.Controllers
{
    public class ClientController : BaseController
    {
        private readonly IClientService _service;
        public ClientController(IClientService service)
        {
            this._service = service;
        }

        public async Task<ActionResult> Index()
        {
            DataResponse<ClientDTO> client = await _service.GetAll();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientDTO, ClientQueryViewModel>();
            });

            IMapper mapper = configuration.CreateMapper();

            List<ClientQueryViewModel> clientViewModel = mapper.Map<List<ClientQueryViewModel>>(client.Data);

            ViewBag.Clients = clientViewModel;
            IEnumerable<PPParkingLot.Models.Query.ClientQueryViewModel> clientsReturning = clientViewModel;
            return View(clientsReturning);
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(ClientInsertViewModel viewModel)
        {
            Response response = new Response();
            if (ModelState.IsValid)
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ClientInsertViewModel, ClientDTO>();
                });

                IMapper mapper = configuration.CreateMapper();
                ClientDTO dto = mapper.Map<ClientDTO>(viewModel);

                response = await _service.Insert(dto);
                //Se funcionou, redireciona pra página inicial
                if (response.Success)
                {
                    return RedirectToAction("Index", "Client");
                }
                else
                {
                    ViewBag.ErrorMessage = response.Errors;
                    return this.View();
                }
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
        public async Task<ActionResult> Update(int id)
        {
            Response response = new Response();

            if (id == 0)
            {
                return View(new ClientInsertViewModel());
            }
            else
            {
                DataResponse<ClientDTO> clientDTO = await _service.GetByID(id);
                ClientDTO dto = clientDTO.Data.FirstOrDefault();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ClientDTO, ClientInsertViewModel>();
                });

                IMapper mapper = configuration.CreateMapper();
                ClientInsertViewModel insertViewModel = mapper.Map<ClientInsertViewModel>(dto);
                return View(insertViewModel);
            }


            //response = await _service.Update(dto);
            ////Se funcionou, redireciona pra página inicial
            //if (response.Success)
            //{
            //    return RedirectToAction("Index", "Client");
            //}
            //else
            //{
            //    ViewBag.ErrorMessage = response.Errors;
            //    return this.View();
            //}

        }

    
        public async Task<ActionResult> Delete(int cliID = 6)
        {
            Response response = new Response();

            //var configuration = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<ClientInsertViewModel, ClientDTO>();
            //});

            //IMapper mapper = configuration.CreateMapper();

            //ClientDTO dto = mapper.Map<ClientDTO>(viewModel);

            //response = await _service.Disable(dto.ID);
            //Se funcionou, redireciona pra página inicial

            response = await _service.Delete(cliID);
            if (response.Success)
            {
                return RedirectToAction("Index", "Client");
            }
            else
            {
                ViewBag.ErrorMessage = response.Errors;
                return RedirectToAction("Index", "Client");
            }
        }

    }

}
