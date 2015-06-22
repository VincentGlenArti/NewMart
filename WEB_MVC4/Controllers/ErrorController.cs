using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_MVC4.Base;

namespace WEB_MVC4.Controllers
{
    public class ErrorController : BaseController
    {

        public ActionResult Error(int statusCode, Exception exception)
        {
            ViewBag.User = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            Response.StatusCode = 200;
            ViewBag.StatusCode = "Ошибка " + statusCode;
            return View();
        }

        public ActionResult UserBehaviorError(int ErrorMessage = 0)
        {
            if (ErrorMessage < 0 || ErrorMessage >= Parameters.Errors.Count) ErrorMessage = 0;
            ViewBag.User = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            ViewBag.Message = WEB_MVC4.Base.Parameters.Errors.ElementAt(ErrorMessage);
            return View();
        }

    }
}
