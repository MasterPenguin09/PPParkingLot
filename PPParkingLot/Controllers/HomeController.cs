using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using DataTransferObject.ComplexTypes;
using DTO.ObjectsDTO.LoginDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PPParkingLot.ControllersView;
using PPParkingLot.Models;
using PPParkingLot.Models.Login;
using SystemCommons;

namespace PPParkingLot.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            this._logger = logger;
            this._userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LoginViewModel, UserDTO>();
            });
            IMapper mapper = configuration.CreateMapper();

            UserDTO dto = mapper.Map<UserDTO>(viewModel);


            try
            {
               UserPattern loggedUser = new UserPattern();

               DataResponse<UserPattern>  user = new DataResponse<UserPattern>();
               user = await _userService.Validate(dto);

                if (user.Success)
                {
                    loggedUser = user.Data.FirstOrDefault();

                   // var cookie = Request.Cookies["NomeDoCookie", ""];

                }

             

              //Response.Cookies.Append("NomeDoCookie", "1,0");
              Response.Cookies.Append("User", "");

              

                //if (cookie[2] == '0')
                //{
                //    //nao eh um admin
                //}
                //else
                //{
                //    //EHUMADMIN
                //}
                //fazer cookies


                return RedirectToAction("Index", "Employees");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View(); //Retornar uma página de recepção de clientes 
        }

    }
}
