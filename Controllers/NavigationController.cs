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

namespace BuildingFutureCitiesApp.Controllers
{
    public class NavigationController : Controller
    {
        List<ConfigurationClass> ConfigurationList;

        public ActionResult Index()
        {
            return View();
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

        public ActionResult Livingroom()
        {
            ViewBag.Message = "Woonkamer";
            ViewBag.Title = "Stel de " + ViewBag.Message + " samen";
            return View();
        }

        public ActionResult Kitchen()
        {
            ViewBag.Message = "Keuken";
            ViewBag.Title = "Stel de " + ViewBag.Message + " samen";
            return View();
        }
        public ActionResult Bathroom()
        {
            ViewBag.Message = "Badkamer";
            ViewBag.Title = "Stel de " + ViewBag.Message + " samen";
            return View();
        }

        public ActionResult Bedroom()
        {
            ViewBag.Message = "Slaapkamer";
            ViewBag.Title = "Stel de " + ViewBag.Message + " samen";
            return View();
        }

        public ActionResult AddMaterial()
        {
            ViewBag.Message = "Hier kunt u een materiaal toevoegen aan de database.";
            ViewBag.Title = "Voeg materiaal toe";
            return View();
        }


        public ActionResult Profile()
        {
            ViewBag.Message = "Profiel";
            ViewBag.Title = "Stel de " + ViewBag.Message + " samen";
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

            return View();
        }
      
        public ActionResult RegisterProfile()
        {
            ViewBag.Title = "Register";
            ViewBag.Message = "Hier kunt u een account registreren";
            return View();
        }
    }
}