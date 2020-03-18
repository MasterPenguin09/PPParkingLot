using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.ControllersView
{
    public class BaseController : Controller
    {
        //Antes de qualquer execução de ação, este método é rodado ^_^
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    var cookie = this.Request.Cookies["NomeDoCookie"];

        //    if (cookie == null)
        //    {
        //        filterContext.Result = new RedirectResult(Url.Action("Login", "Home"));
        //    }
        //    base.OnActionExecuting(filterContext);
        //}
    }
}

