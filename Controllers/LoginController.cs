using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFutureCitiesApp.Models;

namespace BuildingFutureCitiesApp.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult RegisterProfile(Profile profile)
        {
            ViewBag.Title = "Register";
            ViewBag.Message = "Hier kunt u een account registreren";
            if (!ModelState.IsValid)
            {
                ModelState.Clear();
                return View(profile);
            }

            return RedirectToAction("Configuration", "Configuration");
        }

        public ActionResult Login()
        {
            if (Request.Cookies["email"] != null &&
                Request.Cookies["firstname"] != null &&
                Request.Cookies["lastname"] != null)
            {
                return RedirectToAction("Index", "Navigation");
            }
            if (Request.Cookies["account_not_found"] != null)
            {
                if (Request.Cookies["account_not_found"].Value == "true")
                {
                    ViewBag.errorlogin = "Ingevulde velden incorrect!";
                    Response.Cookies["account_not_found"].Expires = DateTime.Now.AddDays(-1);
                    return View();
                }

            }

            return View();

        }

        public ActionResult Logout()
        {
            if (!IsLoggedIn())
            {
                return Redirect("https://localhost:44355/Login/Login"); ;
            }

            Response.Cookies["email"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["firstname"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["lastname"].Expires = DateTime.Now.AddDays(-1);
            return Redirect("https://localhost:44355/Login/Login");
        }

        //returns null if logged in
        public bool IsLoggedIn()
        {
            if (Request.Cookies["email"] == null)
            {
                return false;
            }
            return true;

        }
    }
}