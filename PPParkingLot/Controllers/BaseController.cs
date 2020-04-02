using DataTransferObject.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nancy.Json;
using Newtonsoft.Json;
using PPParkingLot.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using SystemCommons;

namespace PPParkingLot.ControllersView
{
    public class BaseController : Controller /* IOrderedFilter*/
    {

        public BaseController()
        {

        }
        protected bool IsManager { get; set; }
        protected bool IsEmployee { get; set; }
        protected bool IsClient { get; set; }
        protected string Cookie { get; set; }
        public int Order { get; set; }
        public DataResponse<UserPattern> SectionUser { get; set; }//Pega o usuário que foi encontrado no Enter controller

        //Antes de qualquer execução de ação, este método é rodado 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string actionName = filterContext.ActionDescriptor.DisplayName;
            if (actionName != "PPParkingLot.Controllers.HomeController.Index (PPParkingLot)")
            {
                this.Cookie = this.Request.Cookies["MyAccount_SmartParking"];

                if (string.IsNullOrEmpty(Cookie))
                {
                    filterContext.Result = new RedirectResult(Url.Action("Login", "Enter"));
                }
                else
                {
                    UserPattern userFromCookie = JsonConvert.DeserializeObject<UserPattern>(this.Cookie);

                    if (userFromCookie.AccessLevel.Equals(DataTransferObject.Enums.EAccessLevel.Manager))
                    {
                        this.IsManager = true;
                    }
                    else if (userFromCookie.AccessLevel.Equals(DataTransferObject.Enums.EAccessLevel.Employee))
                    {
                        this.IsEmployee = true;
                    }
                    else if (userFromCookie.AccessLevel.Equals(DataTransferObject.Enums.EAccessLevel.Client))
                    {
                        this.IsClient = true;
                    }
                }
                base.OnActionExecuting(filterContext);
            }
          
            //string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            //  var cookie = this.Request.Cookies["MyAccount_SmartParking"];
         
        }
    }
}

