using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GymAnubisNetF.Controllers;
using GymAnubisNetF.Models;

namespace GymAnubisNetF.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        private user oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            oUsuario = (user)HttpContext.Current.Session["User"];

            if (oUsuario == null)
            {
                if (filterContext.Controller is AccessController == false)
                {
                    //Si es false te redirecciono al login
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}