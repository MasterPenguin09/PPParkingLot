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
        //    //    var cookie = this.Request.Cookies["NomeDoCookie"];

        //    //  var cookie = this.Request.Cookies["MyAccount_SmartParking"];
        //    this.Cookie = this.Request.Cookies["MyAccount_SmartParking"];
        //    base.OnActionExecuting(filterContext);
        //}

        //public override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    if (string.IsNullOrEmpty(this.Cookie))
        //    {
        //        filterContext.Result = new RedirectResult(Url.Action("Login", "Enter"));
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
        //    //Codigo  : depois que a action executa 
        //}
    }
}

