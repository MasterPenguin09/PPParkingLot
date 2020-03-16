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

namespace PPParkingLot.Controllers
{
    public class EmployeeController : BaseController
    {
        IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            this._service = service;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(EmployeeInsertViewModel viewModel)
        {

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeInsertViewModel, EmployeeDTO>();
            });

            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o EmployeeInsertViewModel em um EmployeeDTO
            EmployeeDTO dto = mapper.Map<EmployeeDTO>(viewModel);
            try
            {
                await _service.Insert(dto);
                //Se funcionou, redireciona pra página inicial
                return RedirectToAction("Employee", "Index");
            }
            catch (Exception ex)
            {
                //Se caiu aqui, o EmployeeService lançou uma exceção genérica, provavelmente por falha de acesso ao banco
                ViewBag.ErrorMessage = ex.Message;
            }
            return this.View();
        }

        public ActionResult Update()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Update(EmployeeInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeInsertViewModel, EmployeeDTO>();
            });

            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o EmployeeInsertViewModel em um EmployeeDTO
            EmployeeDTO dto = mapper.Map<EmployeeDTO>(viewModel);
            try
            {
                await _service.Update(dto);
                //Se funcionou, redireciona pra página inicial
                return RedirectToAction("Employee", "Index");
            }
            catch (Exception ex)
            {
                //Se caiu aqui, o EmployeeService lançou uma exceção genérica, provavelmente por falha de acesso ao banco
                ViewBag.ErrorMessage = ex.Message;
            }
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(EmployeeLoginViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeLoginViewModel, EmployeeLoginDTO>();
            });
            IMapper mapper = configuration.CreateMapper();

            EmployeeLoginDTO dto = mapper.Map<EmployeeLoginDTO>(viewModel);


            try
            {
                await _service.Login(dto);

                Response.Cookies.Append("NomeDoCookie", "1,0");
                var cookie = Request.Cookies["NomeDoCookie"];
                if (cookie[2] == '0')
                {
                    //nao eh um admin
                }
                else
                {
                    //EHUMADMIN
                }
                //fazer cookies


                return RedirectToAction("Index", "Employees");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }
    }
}
