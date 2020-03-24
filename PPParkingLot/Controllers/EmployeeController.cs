using AutoMapper;
using BusinessLogicalLayer.Impl;
using BusinessLogicalLayer.Interfaces;
using DataTransferObject;
using DTO.ObjectsDTO.LoginDTO;
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
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            this._service = service;
        }

        public async Task<ActionResult> Index()
        {
            DataResponse<EmployeeDTO> employee = await _service.GetAll();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDTO, EmployeeInsertViewModel>();
            });

            IMapper mapper = configuration.CreateMapper();

            List<EmployeeInsertViewModel> empViewModel = mapper.Map<List<EmployeeInsertViewModel>>(employee.Data);

            ViewBag.Employees = empViewModel;

            return View();
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(EmployeeInsertViewModel viewModel)
        {
            //EmployeeDTO adm = new EmployeeDTO();
            //adm.BirthDate = new DateTime(1990, 1, 1, 4, 0, 15);
            //adm.CPF = "586.414.440-17";
            //adm.Email = "gabrie_a_voltolini@estudante.sc.senai.br";
            //adm.AccessLevel = DataTransferObject.Enums.EAccessLevel.Manager;
            //adm.Password = "repolho";
            //adm.Wage = 33231;

            //var response = await _service.Insert(adm);

            //if (!response.Success)
            //{
            //    Console.WriteLine(response.Errors.ToString());
            //}

            Response response = new Response();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeInsertViewModel, EmployeeDTO>();
            });

            IMapper mapper = configuration.CreateMapper();
            EmployeeDTO dto = mapper.Map<EmployeeDTO>(viewModel);

            response = await _service.Insert(dto);
            //Se funcionou, redireciona pra página inicial
            if (response.Success)
            {
                return RedirectToAction("Index", "Employee");
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
        public async Task<ActionResult> Update(EmployeeInsertViewModel viewModel)
        {
            Response response = new Response();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeInsertViewModel, EmployeeDTO>();
            });

            IMapper mapper = configuration.CreateMapper();
            EmployeeDTO dto = mapper.Map<EmployeeDTO>(viewModel);

            response = await _service.Update(dto);
            //Se funcionou, redireciona pra página inicial
            if (response.Success)
            {
                return RedirectToAction("Index", "Employee");
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
        public async Task<ActionResult> Disable(EmployeeInsertViewModel viewModel)
        {
            Response response = new Response();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeInsertViewModel, EmployeeDTO>();
            });

            IMapper mapper = configuration.CreateMapper();

            EmployeeDTO dto = mapper.Map<EmployeeDTO>(viewModel);
            response = await _service.Disable(dto.ID);
            //Se funcionou, redireciona pra página inicial
            if (response.Success)
            {
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ViewBag.ErrorMessage = response.Errors;
                return this.View();
            }

        }

    }
}
