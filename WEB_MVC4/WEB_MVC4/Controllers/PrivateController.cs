using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WEB_MVC4.Base;
using WEB_MVC4.Models;

namespace WEB_MVC4.Controllers
{
    public class PrivateController : BaseController
    {
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.User = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            Response.StatusCode = 401;
            return View(new LoginPageView());
        }

        [HttpPost]
        public ActionResult Login(LoginPageView LoginData, string ReturnUrl = "/", bool Persistent = false)
        {
            if (ModelState.IsValid)
            {
                if (Authentication.ValidateUser(LoginData.Login, LoginData.Password))
                {
                    FormsAuthentication.SetAuthCookie(LoginData.Login, Persistent);
                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("Login", "Логин или пароль некорректен");
                    ModelState.AddModelError("Password", "Логин или пароль некорректен");
                }
            }

            return View(LoginData);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            ViewBag.User = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            Response.StatusCode = 401;
            return View(new RegistrationPageView());
        }

        [HttpPost]
        public ActionResult Registration(RegistrationPageView LoginData, string ReturnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                string Valid = LoginData.Validate();
                if (Valid == null)
                {
                    bool Email = Authentication.EMailExists(LoginData.Email);
                    bool Login = Authentication.UserExists(LoginData.Login);
                    if (!Email && !Login)
                    {
                        if (Authentication.Register(LoginData))
                            FormsAuthentication.SetAuthCookie(LoginData.Login, false);
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        if (Email) ModelState.AddModelError("Email", "Данный адрес уже использован");
                        if (Login) ModelState.AddModelError("Login", "Данный логин уже использован");
                    }
                }
                else ViewBag.Valid = Valid;
            }
            return View(LoginData);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", new { ReturnUrl = "/" });
        }

        public ActionResult Cart()
        {
            ViewBag.User = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            var Name = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            if (Name == null) return RedirectToAction("Login", "Private");
            return View();
        }

    }
}
