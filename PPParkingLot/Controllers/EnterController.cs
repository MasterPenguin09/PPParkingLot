using AutoMapper;
using BLL.Interfaces;
using DataTransferObject.ComplexTypes;
using DTO.ObjectsDTO.LoginDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy;
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
    public class EnterController : Controller
    {
        private readonly IUserService _userService;
        public EnterController(IUserService userService)
        {
            this._userService = userService;
        }

        public ActionResult Login()
        {
            return this.View();
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

            LoginViewModel login = new LoginViewModel();
            DataResponse<UserPattern> user = await _userService.Validate(dto);
            BaseController baseController = new BaseController();
            baseController.SectionUser = user;

            if (user.Success)
            {
                var cookie = Request.Cookies["MyAccount_SmartParking"];

                if (string.IsNullOrEmpty(cookie))
                {
                    UserPattern loggedUser = user.Data.FirstOrDefault();
                    login.ID = loggedUser.ID;
                    login.Name = loggedUser.Name;
                    login.Email = loggedUser.Email;
                    login.Level = loggedUser.AccessLevel;

                    string json = jSerializer.Serialize(login);

                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.MaxValue;

                    Response.Cookies.Append("MyAccount_SmartParking", json, option);
                }

            }
            //ViewBag.Erros = user.Errors;
            return this.View();
        }
    }
}
