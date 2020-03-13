using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.ControllersView
{
    public class BaseController
    {
        //Antes de qualquer execução de ação, este método é rodado ^_^
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie cookie = this.Request.Cookies["USERIDENTITY"];

            if (cookie == null)
            {
                filterContext.Result = new RedirectResult(Url.Action("Login", "Usuario"));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
