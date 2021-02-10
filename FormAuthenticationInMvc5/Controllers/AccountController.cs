using FormAuthenticationInMvc5.Models;
using FormAuthenticationInMvc5.Models.Data;
using FormAuthenticationInMvc5.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormAuthenticationInMvc5.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        AppDbContext db = new AppDbContext();

        // GET: Account
        public ActionResult Index()
        {
            LoginViewModel login = new LoginViewModel();
            ViewBag.login = login;

            RegisterViewModel register = new RegisterViewModel();
            ViewBag.register = register;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, string submitValue)
        {

            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return Redirect("~/Admin");
                }
                else
                {
                    return Redirect("~/Home");
                }
            }
            //  return Redirect(FormsAuthentication.DefaultUrl);
            // return Redirect("~/Home");

            if (submitValue == "ورود")
            {
                if (ModelState.IsValid)
                {
                   string pass = FormsAuthentication.HashPasswordForStoringInConfigFile(login.Password, "MD5");
                    if (db.Users.Any(u => u.UserMail == login.UserMail && u.Password == login.Password))
                    {
                        FormsAuthentication.SetAuthCookie(login.UserMail, login.RememberMe);
                        return Redirect(FormsAuthentication.DefaultUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("LoginCustomError", "ایمیل یا کلمه عبور اشتباه می باشد");
                    }
                }
            }
            else
            {
                ModelState.Clear();
            }
            return View("Index",login);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register, string submitValue)
        {
            if (submitValue == "ثبت نام")
            {
                if(!db.Users.Any(u=>u.UserMail == register.UserMail))
                {
                    if (ModelState.IsValid)
                    {
                        User user = new User()
                        {
                            UserMail = register.UserMail,
                            Password = FormsAuthentication.HashPasswordForStoringInConfigFile(register.Password, "MD5"),
                            RoleId = 2
                    };
                        db.Users.Add(user);
                        db.SaveChanges();

                        return Redirect(FormsAuthentication.DefaultUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "خطایی رخ داده است لطفا فیلدها را بررسی نمائید.");
                }
            }
            else
            {
                ModelState.Clear();
            }

            return View("Index", register);
        }


        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return Redirect("~/Home");
        }
    }
}