using BuildingFutureCitiesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            ConfigurationList.Add(new ConfigurationClass("Woonkamer", 0.86, 634, 0.94, 239));

            ViewBag.RoomName = ConfigurationList[0].RoomName;
            ViewBag.CurrentConceptSCI = ConfigurationList[0].CurrentConceptSCI;
            ViewBag.CurrentConceptCO2 = ConfigurationList[0].CurrentConceptCO2;
            ViewBag.NewConceptSCI = ConfigurationList[0].NewConceptSCI;
            ViewBag.NewConceptCO2 = ConfigurationList[0].NewConceptCO2;
            return View();
        }
      
    }
}