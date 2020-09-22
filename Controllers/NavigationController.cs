using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingFutureCitiesApp.Controllers
{
    public class NavigationController : Controller
    {
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
    }
}