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
            var Name = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            if (Name != null) return RedirectToAction("Index", "Home");
            Response.StatusCode = 401;
            return View(new LoginPageView());
        }

        [HttpPost]
        public ActionResult Login(LoginPageView LoginData, bool Persistent = false)
        {
            ViewBag.User = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            var Name = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            if (Name != null) return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {
                if (LoginData.Login.Contains('@'))
                {
                    if (Authentication.ValidateUserEmail(LoginData.Login, LoginData.Password))
                    {
                        FormsAuthentication.SetAuthCookie(Authentication.GetNameByEmail(LoginData.Login), Persistent);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Login", "Логин или пароль некорректен");
                        ModelState.AddModelError("Password", "Логин или пароль некорректен");
                    }
                }
                else
                {
                    if (Authentication.ValidateUser(LoginData.Login, LoginData.Password))
                    {
                        FormsAuthentication.SetAuthCookie(LoginData.Login, Persistent);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Login", "Логин или пароль некорректен");
                        ModelState.AddModelError("Password", "Логин или пароль некорректен");
                    }
                }
            }

            return View(LoginData);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            ViewBag.User = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            var Name = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            if (Name != null) return RedirectToAction("Index", "Home");
            Response.StatusCode = 401;
            return View(new RegistrationPageView());
        }

        [HttpPost]
        public ActionResult Registration(RegistrationPageView LoginData)
        {
            ViewBag.User = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            var Name = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            if (Name != null) return RedirectToAction("Index", "Home");
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
                        {
                            FormsAuthentication.SetAuthCookie(LoginData.Login, false);
                            return RedirectToAction("Index", "Home");
                        }
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
            List<Tuple<Product, int>> Model = new List<Tuple<Product,int>>();
            using(databaseModelContainer DB = new databaseModelContainer())
            {
                var list = DB.UserSet.First(x => x.Login == Name.Login).Cart.ToList();
                foreach(var item in list)
                {
                    Model.Add(new Tuple<Product,int>(item.Product, int.Parse(item.Ammount)));
                }
            }
            return View(Model);
        }

        public ActionResult AddToCart(int ProductID = -1, int Ammount = -1)
        {
            ViewBag.User = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            var Name = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            if (Name == null) return RedirectToAction("Login", "Private");
            if (ProductID == -1) return RedirectToAction("UserBehaviorError", "Home", new { ErrorMessage = 3 });
            Product selectedProduct = DataBase.ProductSet.FirstOrDefault(x => x.ID == ProductID);
            if (selectedProduct == null) return RedirectToAction("UserBehaviorError", "Home", new { ErrorMessage = 3 });
            if (Ammount < 1 || Ammount > 99) return RedirectToAction("UserBehaviorError", "Home", new { ErrorMessage = 3 });
            try
            {
                DataBase.CartSet.Add(new Cart
                {
                    Ammount = Ammount.ToString(),
                    ProductID = selectedProduct.ID,
                    UpdateDate = DateTime.Now.ToShortDateString(),
                    UserUserId = Name.UserId
                });
                DataBase.SaveChanges();
            }
            catch(Exception e)
            {
                return RedirectToAction("Error", "Error", new { statusCode = 404, 
                    exception = new Exception ("Ошибка, попробуйте позже") });
            }
            return RedirectToAction("Cart", "Private");
        }

        public ActionResult RemoveFromCart(int ProductID = -1, int Ammount = -1)
        {
            ViewBag.User = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            var Name = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            if (Name == null) return RedirectToAction("Login", "Private");
            if (Ammount < 1 || Ammount > 99) return RedirectToAction("UserBehaviorError", "Home", new { ErrorMessage = 3 });
            if (ProductID == -1) return RedirectToAction("UserBehaviorError", "Home", new { ErrorMessage = 3 });
            Product selectedProduct = DataBase.ProductSet.FirstOrDefault(x => x.ID == ProductID);
            if (selectedProduct == null) return RedirectToAction("UserBehaviorError", "Home", new { ErrorMessage = 3 });
            WEB_MVC4.Models.Cart RemovableValue = DataBase.CartSet.Where(x => x.UserUserId == Name.UserId &&
                x.ProductID == ProductID && x.Ammount.Equals(Ammount.ToString())).FirstOrDefault();
            if (RemovableValue == null) return RedirectToAction("UserBehaviorError", "Home", new { ErrorMessage = 3 });
            try
            {
                DataBase.CartSet.Remove(RemovableValue);
                DataBase.SaveChanges();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new
                {
                    statusCode = 404,
                    exception = new Exception("Ошибка, попробуйте позже")
                });
            }
            return RedirectToAction("Cart", "Private");
        }

        public ActionResult Buy()
        {
            ViewBag.User = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            var Name = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            if (Name == null) return RedirectToAction("Login", "Private");
            var UserOrder = DataBase.CartSet.Where(x => x.UserUserId == Name.UserId).ToList();
            if (UserOrder.Count == 0) return RedirectToAction("Error", "Error", new
                {
                    statusCode = 404,
                    exception = new Exception("Ваша корзина пуста!")
                });
            string SubmitTimeStr = DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString(), PriceBuff;
            double cost = 0;
            foreach (var i in UserOrder)
            {
                PriceBuff = i.Product.Price;
                cost = cost + double.Parse(PriceBuff, System.Globalization.CultureInfo.InvariantCulture);
            }
            string CostStr = cost.ToString();
            try
            {
                DataBase.OrderSet.Add(new Order
                {
                    UserId = Name.UserId,
                    SubmitTime = SubmitTimeStr,
                    Status = "Submit",
                    LocationID = 1,
                    DoneTime = "None",
                    ArrivalTime = "None",
                    Cost = CostStr
                });
                DataBase.SaveChanges();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new
                {
                    statusCode = 404,
                    exception = new Exception("Ошибка, попробуйте позже")
                });
            }
            var Target = DataBase.OrderSet.OrderBy(x => x.SubmitTime).ToList().Last();
            try
            {
                foreach (var item in UserOrder)
                {
                    DataBase.OrderProductsSet.Add(new OrderProducts {
                        Ammount = item.Ammount,
                        OrderID = Target.ID,
                        ProductID = item.ProductID
                    });
                }
                DataBase.SaveChanges();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new
                {
                    statusCode = 404,
                    exception = new Exception("Ошибка, попробуйте позже")
                });
            }
            try
            {
                foreach (var item in UserOrder)
                {
                    DataBase.CartSet.Remove(item);
                }
                DataBase.SaveChanges();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new
                {
                    statusCode = 404,
                    exception = new Exception("Ошибка, попробуйте позже")
                });
            }
            return RedirectToAction("OrderDetails", "Private", new { ID = Target.ID });
        }

        public ActionResult OrderDetails(long ID = -1)
        {
            ViewBag.User = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            var Name = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            if (Name == null) return RedirectToAction("Login", "Private");
            var UserOrder = DataBase.OrderSet.Where(x => x.UserId == Name.UserId).FirstOrDefault(x => x.ID == ID);
            if (UserOrder == null) return RedirectToAction("Error", "Error", new
            {
                statusCode = 404,
                exception = new Exception("Попытка получить информацию о некорректном заказе")
            });
            return View(UserOrder);
        }

        public ActionResult Orders()
        {
            ViewBag.User = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            var Name = Authentication.GetUserInfo(HttpContext.User.Identity.Name);
            if (Name == null) return RedirectToAction("Login", "Private");
            var UserOrders = DataBase.OrderSet.Where(x => x.UserId == Name.UserId).ToList();
            return View(UserOrders);
        }

    }
}
