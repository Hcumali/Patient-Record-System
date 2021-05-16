using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HastaTakipSistemi.DBModels;
using HastaTakipSistemi.MongoOperations;

namespace HastaTakipSistemi.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            #region PERMISSION CONTROLS
                HttpCookie cookie_islogged = Request.Cookies["isLoggedIn"];
                if (cookie_islogged == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (cookie_islogged.Value != "True")
                {
                    return RedirectToAction("Index", "Home");
                }
            #endregion

            return View();
        }
        
        public ActionResult HastaKayıt()
        {
            return View();
        }

        public ActionResult HastaListele()
        {
            #region READ DATA FROM Mongo Atlas DB
            var viewParameter = new Models.DashboardModel();
            viewParameter.patients = MongoOperations.PatientOperations.HastaKayitListele();
            #endregion

            return View(viewParameter);
        }

        [HttpPost]

        public Boolean HastaKayitOlustur()
        {
            return true;
        }

        [HttpPost]
        public Boolean KayitOlustur(string tcRegister, string adRegister, string soyadRegister,
            string adresRegister, string telefonRegister, int yasRegister, string taniRegister, string girisTarihiRegister, string cikisTarihiRegister)
        {
            if(cikisTarihiRegister == null)
            {
                cikisTarihiRegister = "";
            }

            Patient hasta = new Patient
            {
                TC = tcRegister,
                Ad = adRegister,
                Soyad = soyadRegister,
                Adres = adresRegister,
                TelNo = telefonRegister,
                Yas = yasRegister,
                Tani = taniRegister,
                Giris = girisTarihiRegister,
                Cikis = cikisTarihiRegister
            };

            Boolean sonuc = PatientOperations.HastaKayitOlustur(hasta);
            return sonuc;
        }

        [HttpPost]
        public Boolean DeleteCookie(string cookieName)
        {
            Response.Cookies[cookieName].Value = "False";
            HttpCookie cookie_islogged = Request.Cookies["isLoggedIn"];
            if (cookie_islogged.Value == "False")
            {
                return true;
            }
            else return false;
        }
    }
}