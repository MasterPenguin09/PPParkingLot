﻿using AutoMapper;
using BLL.Interfaces;
using DataTransferObject.ComplexTypes;
using DTO.ObjectsDTO.LoginDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using PPParkingLot.ControllersView;
using PPParkingLot.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemCommons;

namespace PPParkingLot.Controllers
{
    public class EnterController : BaseController
    {


        private readonly IUserService _userService;
        public EnterController(IUserService userService)
        {
            this._userService = userService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {

            JavaScriptSerializer jSerializer = new JavaScriptSerializer();

            //Mapper
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LoginViewModel, UserDTO>();
            });
            IMapper mapper = configuration.CreateMapper();
            //Objeto mapeado
            UserDTO dto = mapper.Map<UserDTO>(viewModel);


            DataResponse<UserPattern> user = await _userService.Validate(dto);

            if (user.Success)
            {
                // var cookie = Request.Cookies["NomeDoCookie", ""];

                var cookie = Request.Cookies["MyAccount_SmartParking"];

                if (string.IsNullOrEmpty(cookie))
                {
                    //Response.Cookies.Append("NomeDoCookie", "1,0");
                    //Response.Cookies.Append("MyAccount_SmartParking_" + data["Name"] + "\n", json);
                    UserPattern loggedUser = user.Data.FirstOrDefault();
                    string json = jSerializer.Serialize(loggedUser);

                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.MaxValue;
                    
                    Response.Cookies.Append("MyAccount_SmartParking", json, option);
                }

            }
            ViewBag.Erros = user.Errors;
            //Retornar uma página de recepção de clientes 
            //return View("Login", "Enter");
            return this.View();


            

            //if (cookie[2] == '0')
            //{
            //return RedirectToAction("Index", "ClientSpace");
            //    //nao eh um admin
            //}
            //else
            //{
            //return RedirectToAction("Index", "EmployeeSpace");
            //    //EHUMADMIN
            //}

            //fazer cookies



        }
    }
}
