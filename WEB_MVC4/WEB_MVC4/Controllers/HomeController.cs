using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using WEB_MVC4.Models;
using WEB_MVC4.Base;

namespace WEB_MVC4.Controllers
{

    public class HomeController : BaseController
    {
        const int PageSize = 10;

        public ActionResult Index(int Page = 1, int Category = 0, string Search = "", bool DiscountOnly = false)
        {
            //WEB_MVC4.Base.Debug.PutSampleDataInYourDB();
            //System.Diagnostics.Debug.WriteLine("Your name is:" + HttpContext.User.Identity.Name + "");
            ViewBag.User = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            IQueryable<Product> ProductRepo = DataBase.ProductSet;
            if (Category != 0)
            {
                if (Category < 0 || DataBase.CategorySet.FirstOrDefault(x => x.CategoryID == Category) == null)
                {
                    return RedirectToAction("UserBehaviorError", "Error",
                        new { ErrorMessage = 2 });
                }
                ProductRepo = ProductRepo.Where(x => x.CategoryID == Category);
            }
            if (DiscountOnly) ProductRepo = ProductRepo.Where(x => x.Discount.Count > 0);
            if (Search.Length != 0) ProductRepo = ProductRepo.Where(x => x.Name.Contains(Search)
                || x.Manufacturer.Name.Contains(Search) || x.Info.Contains(Search) || x.Category.Name.Contains(Search));
            int TotalItems = ProductRepo.Count();
            int TotalPages = (TotalItems / PageSize) + ((TotalItems % PageSize > 0) ? 1 : 0);
            if (TotalPages < 1) TotalPages = 1;
            if (Page < 1 || Page > TotalPages)
            {
                return RedirectToAction("UserBehaviorError", "Error",
                    new { ErrorMessage = 1 });
            }
            ViewBag.Category = Category;
            ViewBag.Title = "NewMart";
            ViewBag.Page = Page;
            ViewBag.TotalPages = TotalPages;
            ViewBag.DiscountOnly = DiscountOnly;
            ViewBag.Search = Search;
            ViewBag.Products = ProductRepo.OrderBy(x => x.ID).Skip((Page - 1) * PageSize).Take(PageSize).ToList<Product>();
            var cat = DataBase.CategorySet.OrderBy(x => x.ID).ToList<Category>();
            cat.ElementAt(0).Name = "Сбросить категорию";
            ViewBag.CategorySelect = cat;
            return View();
        }

        public ActionResult PreviousPage(int Page, int Category, string Search, bool DiscountOnly)
        {
            return RedirectToAction("Index", "Home",
                new { Page = Page - 1, Category = Category, Search = Search, DiscountOnly = DiscountOnly });
        }

        public ActionResult NextPage(int Page, int Category, string Search, bool DiscountOnly)
        {
            return RedirectToAction("Index", "Home",
                new { Page = Page + 1, Category = Category, Search = Search, DiscountOnly = DiscountOnly });
        }

        public ActionResult ApplyDiscount(int Page, int Category, string Search, bool DiscountOnly)
        {
            return RedirectToAction("Index", "Home",
                new { Page = 1, Category = Category, Search = Search, DiscountOnly = !DiscountOnly });
        }

        [HttpPost]
        public ActionResult ApplySearch(int Page, int Category, string Search, bool DiscountOnly)
        {
            return RedirectToAction("Index", "Home",
                new { Page = 1, Category = Category, Search = Search, DiscountOnly = DiscountOnly });
        }
    }
}
