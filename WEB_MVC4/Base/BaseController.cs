using System;
using System.Web.Mvc;
using WEB_MVC4.Models;
using System.Collections.Generic;
using WEB_MVC4.Security;

namespace WEB_MVC4.Base
{
    public static class Parameters
    {
        public static List<String> Errors = new List<string>()
        {
            "Behavior Error",
            "Попытка обратиться к несуществующей странице каталога",
            "Попытка обратиться к несуществующей категории",
            "Попытка обращения несуществующему товару товару",
            "Попытка удаления несуществующей записи корзины"
        };
    }

    public class BaseController : Controller
    {
        protected databaseModelContainer DataBase = new databaseModelContainer();
        protected Authentication Authentication = new Authentication();
    }
}
