using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HaberSis.Admin.CustomFilter
{
    public class LoginFilter : FilterAttribute, IActionFilter
    {
        //actonmetod çalıştırıldıktan sonra devreye girer
        public void OnActionExecuted(ActionExecutedContext context)
         {
            HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);
            var SessionControl = context.HttpContext.Session["KullaniciEmail"];
            if (SessionControl==null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Acount" }, { "action", "Login" } });
            }
        }

        //action metod tetiklendiği anda devreye girer
        public void OnActionExecuting(ActionExecutingContext context)
         {
           
        }
    }
}