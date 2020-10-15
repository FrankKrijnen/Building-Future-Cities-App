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
    public class NavigationController : Controller
    {
        List<ConfigurationClass> ConfigurationList;

        public ActionResult Index()
        {
            if (IsLoggedIn())
            {
                return View();
            }
            return Redirect("https://localhost:44355/Navigation/Login");
        }

        //public void SetMaterial(string productName, string LiveArea, string ObjectLiveAreaFunction, string ObjectLiveAreaRoom, float Removability, string MaterialOrigins, string MaterialDistance, string Unit_Kg_M2_Amount, string EmbodiedEnergie, string EmbodiedCO2, string LifeSpan)
        //{
        //    Material material = new Material(
        //        1,
        //        productName,
        //        LiveArea,
        //        ObjectLiveAreaFunction,
        //        ObjectLiveAreaRoom,
        //        Removability,
        //        MaterialOrigins,
        //        MaterialDistance,
        //        Unit_Kg_M2_Amount,
        //        EmbodiedEnergie,
        //        EmbodiedCO2,
        //        LifeSpan
        //        );

        //    var json = JsonConvert.SerializeObject(material);
        //    HttpClient client = new HttpClient();
        //    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5000/api/material");
        //    requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");

        //    HttpResponseMessage response = client.SendAsync(requestMessage).GetAwaiter().GetResult();

        //    if (response.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine("Well Done");
        //    }
        //}

        public ActionResult Livingroom()
        {
            ViewBag.Message = "Woonkamer";
            ViewBag.Title = "Stel de " + ViewBag.Message + " samen";
            if (IsLoggedIn())
            {
                return View();
            }
            return Redirect("https://localhost:44355/Navigation/Login");
        }

        public ActionResult Kitchen()
        {
            ViewBag.Message = "Keuken";
            ViewBag.Title = "Stel de " + ViewBag.Message + " samen";
            if (IsLoggedIn())
            {
                return View();
            }
            return Redirect("https://localhost:44355/Navigation/Login");
        }
        public ActionResult Bathroom()
        {
            ViewBag.Message = "Badkamer";
            ViewBag.Title = "Stel de " + ViewBag.Message + " samen";
            if (IsLoggedIn())
            {
                return View();
            }
            return Redirect("https://localhost:44355/Navigation/Login");
        }

        public ActionResult Bedroom()
        {
            ViewBag.Message = "Slaapkamer";
            ViewBag.Title = "Stel de " + ViewBag.Message + " samen";
            if (IsLoggedIn())
            {
                return View();
            }
            return Redirect("https://localhost:44355/Navigation/Login");
        }

        public ActionResult AddMaterial()
        {
            ViewBag.Message = "Hier kunt u een materiaal toevoegen aan de database.";
            ViewBag.Title = "Voeg materiaal toe";
            if (IsLoggedIn())
            {
                return View();
            }
            return Redirect("https://localhost:44355/Navigation/Login");
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
                Response.Redirect("https://localhost:44355/Navigation/Login");
            }

            return View();
        }

        public ActionResult Configuration()
        {
            ViewBag.Title = "Configuratie overzicht";

            ConfigurationList = new List<ConfigurationClass>();
            ConfigurationList.Add(new ConfigurationClass("Woonkamer 1", 0.86, 634, 0.94, 239));
            ConfigurationList.Add(new ConfigurationClass("Keuken 1", 0.86, 634, 0.94, 239));
            ConfigurationList.Add(new ConfigurationClass("Badkamer 1", 0.86, 634, 0.94, 239));
            ConfigurationList.Add(new ConfigurationClass("Slaapkamer 1", 0.86, 634, 0.94, 239));
            ConfigurationList.Add(new ConfigurationClass("Woonkamer 2", 0.86, 634, 0.94, 239));

            ViewBag.ConfigurationList = ConfigurationList;

            if (IsLoggedIn())
            {
                return View();
            }
            return Redirect("https://localhost:44355/Navigation/Login");
        }
        public ActionResult RegisterProfile(Profile profile)
        {
            ViewBag.Title = "Register";
            ViewBag.Message = "Hier kunt u een account registreren";
            if (!ModelState.IsValid)
            {
                ModelState.Clear();
                return View(profile);
            }

            return RedirectToAction("Configuration");
        }

        public ActionResult Login()
        {
            if (Request.Cookies["email"] != null &&
                Request.Cookies["firstname"] != null &&
                Request.Cookies["lastname"] != null)
            {
                return RedirectToAction("Index");
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
                return Redirect("https://localhost:44355/Navigation/Login"); ;
            }

            Response.Cookies["email"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["firstname"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["lastname"].Expires = DateTime.Now.AddDays(-1);
            return Redirect("https://localhost:44355/Navigation/Login");
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
        //public void SetMaterial(string productName, string LiveArea, string ObjectLiveAreaFunction, string ObjectLiveAreaFijn, float Removability, string MaterialOrigins, string MaterialDistance, string Unit_Kg_M2_Amount, string EmbodiedEnergie, string EmbodiedCO2, string LifeSpan)
        //{
        //    Material material = new Material(
        //        1,
        //        productName,
        //        LiveArea,
        //        ObjectLiveAreaFunction,
        //        ObjectLiveAreaFijn,
        //        Removability,
        //        MaterialOrigins,
        //        MaterialDistance,
        //        Unit_Kg_M2_Amount,
        //        EmbodiedEnergie,
        //        EmbodiedCO2,
        //        LifeSpan
        //        );

        //    var json = JsonConvert.SerializeObject(material);
        //    HttpClient client = new HttpClient();
        //    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5000/api/material");
        //    requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");

        //    HttpResponseMessage response = client.SendAsync(requestMessage).GetAwaiter().GetResult();

        //    if (response.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine("Well Done");
        //    }
        //}
    }
}