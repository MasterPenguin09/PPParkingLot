using DataTransferObject.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PPParkingLot.ControllersView
{
    public class BaseController : Controller /* IOrderedFilter*/
    {
        //protected bool IsManager { get; set; }
        //protected bool IsEmployee { get; set; }
        //protected bool IsClient { get; set; }
        //protected string Cookie { get; set; }
        //public int Order { get; set; }

        ////Antes de qualquer execução de ação, este método é rodado ^_^
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //  var cookie = this.Request.Cookies["MyAccount_SmartParking"];
        //    this.Cookie = this.Request.Cookies["MyAccount_SmartParking"];

        //    if (Cookie == null)
        //    {
        //        filterContext.Result = new RedirectResult(Url.Action("Login", "Usuario"));
        //    }
        //    else
        //    {
        //        UserPattern userFromCookie = JsonConvert.DeserializeObject<UserPattern>(this.Cookie);

        //        if (userFromCookie.AccessLevel.Equals(DataTransferObject.Enums.EAccessLevel.Manager))
        //        {
        //            this.IsManager = true;
        //        }
        //        else if (userFromCookie.AccessLevel.Equals(DataTransferObject.Enums.EAccessLevel.Employee))
        //        {
        //            this.IsEmployee = true;
        //        }
        //        else if (userFromCookie.AccessLevel.Equals(DataTransferObject.Enums.EAccessLevel.Client))
        //        {
        //            this.IsClient = true;
        //        }   
        //    }
        //    base.OnActionExecuting(filterContext);
        }
    }

