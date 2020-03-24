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
using Nancy.Json;
using Newtonsoft.Json;
using PPParkingLot.ControllersView;
using PPParkingLot.Models;
using PPParkingLot.Models.Login;
using SystemCommons;

namespace PPParkingLot.Controllers
{
    public class HomeController : BaseController
    {
        //private readonly ILogger<HomeController> _logger;
        //private readonly IUserService _userService;

        //public HomeController(ILogger<HomeController> logger, IUserService userService)
        //{
        //    this._logger = logger;
        //    this._userService = userService;
        //}

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

        //public ActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<ActionResult> Login(LoginViewModel viewModel)
        //{

        //    JavaScriptSerializer jSerializer = new JavaScriptSerializer();
           
        //    //Mapper
        //    var configuration = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<LoginViewModel, UserDTO>();
        //    });
        //    IMapper mapper = configuration.CreateMapper();
        //    //Objeto mapeado
        //    UserDTO dto = mapper.Map<UserDTO>(viewModel);


        //    DataResponse<UserPattern> user = await _userService.Validate(dto);

        //    if (user.Success)
        //    {
        //        UserPattern loggedUser = user.Data.FirstOrDefault();

        //        string json = jSerializer.Serialize(loggedUser);

        //        // var cookie = Request.Cookies["NomeDoCookie", ""];

        //        var cookie = Request.Cookies["MyAccount_SmartParking"];


        //        if (cookie == null)
        //        {
        //            //Response.Cookies.Append("NomeDoCookie", "1,0");
        //            //Response.Cookies.Append("MyAccount_SmartParking_" + data["Name"] + "\n", json);
        //            Response.Cookies.Append("MyAccount_SmartParking", json);
        //        }

        //    }
        //    ViewBag.Erros = user.Errors;
        //    //Retornar uma página de recepção de clientes 
        //    return View("Login", "Home");





        //    //if (cookie[2] == '0')
        //    //{
        //    //return RedirectToAction("Index", "ClientSpace");
        //    //    //nao eh um admin
        //    //}
        //    //else
        //    //{
        //    //return RedirectToAction("Index", "EmployeeSpace");
        //    //    //EHUMADMIN
        //    //}

        //    //fazer cookies



        //}

    }
}
