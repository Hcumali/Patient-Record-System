using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HastaTakipSistemi.DBModels;
using HastaTakipSistemi.MongoOperations;

namespace HastaTakipSistemi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            #region PERMISSION CONTROLS
            HttpCookie cookie_islogged = Request.Cookies["isLoggedIn"];
            if (cookie_islogged == null)
            {
                return View();
            }
            else if (cookie_islogged.Value == "False")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
            #endregion
        }

        [HttpPost]
        public Boolean LoginProcess(string userNameLogin, string passwordLogin)
        {
            Admin admin = new Admin
            {
                userName = userNameLogin,
                password = passwordLogin
            };

            var loginCheck = AdminOperations.IsThereAdmin(admin);

            if (loginCheck)
            {
                HttpCookie myCookie = new HttpCookie("isLoggedIn")
                {
                    Value = "True",
                    Expires = DateTime.Now.AddDays(1)
                };
                Response.Cookies.Add(myCookie);
                // and
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}