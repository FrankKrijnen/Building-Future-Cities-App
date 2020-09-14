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
            ViewBag.Message = "Livingroom";
            ViewBag.Title = "Set up the " + ViewBag.Message;
            return View();
        }

        public ActionResult Kitchen()
        {
            ViewBag.Message = "Kitchen";
            ViewBag.Title = "Set up the " + ViewBag.Message;
            return View();
        }
        public ActionResult Bathroom()
        {
            ViewBag.Message = "Bathroom";
            ViewBag.Title = "Set up the " + ViewBag.Message;
            return View();
        }

        public ActionResult Bedroom()
        {
            ViewBag.Message = "Bedroom";
            ViewBag.Title = "Set up the " + ViewBag.Message;
            return View();
        }
    }
}