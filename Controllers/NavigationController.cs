using BuildingFutureCitiesApp.Extensions;
using BuildingFutureCitiesApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BuildingFutureCitiesApp.Controllers
{
    public class NavigationController : LoginController
    {
        public ActionResult Index()
        {
            if (IsLoggedIn())
            {
                HttpCookieCollection cookieCollection = Request.Cookies;
                if (cookieCollection.Get("StatusMessage") != null)
                {
                    if (Request.Cookies["StatusMessage"].Value == "Success")
                    {
                        this.AddNotification("Aanpassing is gemaakt", NotificationType.SUCCESS);
                    } else if(Request.Cookies["StatusMessage"].Value == "Failure")
                    {
                        this.AddNotification("Er is iets fout gegaan probeer het later opnieuw.", NotificationType.ERROR);
                    }
                }
                return View();
            }
            return Redirect("https://localhost:44355/Login/Login");
        }

        public ActionResult Livingroom()
        {
            ViewBag.Message = "Woonkamer";
            ViewBag.Title = "Stel de " + ViewBag.Message + " samen";
            if (IsLoggedIn())
            {
                return View();
            }
            return Redirect("https://localhost:44355/Login/Login");
        }

        public ActionResult Kitchen()
        {
            ViewBag.Message = "Keuken";
            ViewBag.Title = "Stel de " + ViewBag.Message + " samen";
            if (IsLoggedIn())
            {
                return View();
            }
            return Redirect("https://localhost:44355/Login/Login");
        }
        public ActionResult Bathroom()
        {
            ViewBag.Message = "Badkamer";
            ViewBag.Title = "Stel de " + ViewBag.Message + " samen";
            if (IsLoggedIn())
            {
                return View();
            }
            return Redirect("https://localhost:44355/Login/Login");
        }

        public ActionResult Bedroom()
        {
            ViewBag.Message = "Slaapkamer";
            ViewBag.Title = "Stel de " + ViewBag.Message + " samen";
            if (IsLoggedIn())
            {
                return View();
            }
            return Redirect("https://localhost:44355/Login/Login");
        }

        public ActionResult AddMaterial()
        {
            ViewBag.Message = "Hier kunt u een materiaal toevoegen aan de database.";
            ViewBag.Title = "Voeg een nieuw materiaal toe.";
            if (IsLoggedIn())
            {
                return View();
            }
            return Redirect("https://localhost:44355/Login/Login");
        }


        public ActionResult Profile()
        {
            if (Request.Cookies["email"] != null &&
                Request.Cookies["firstname"] != null &&
                Request.Cookies["lastname"] != null)
            {
                ViewBag.email = HttpUtility.UrlDecode(Request.Cookies["email"].Value);
                ViewBag.firstname = HttpUtility.UrlDecode(Request.Cookies["firstname"].Value);
                ViewBag.lastname = HttpUtility.UrlDecode(Request.Cookies["lastname"].Value);

                string firstname = ViewBag.firstname;
                ViewBag.firstletter = firstname.Remove(1, firstname.Length - 1);
            }
            else
            {
                Response.Redirect("https://localhost:44355/Login/Login");
            }

            return View();
        }
    }
}