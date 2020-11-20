using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingFutureCitiesApp.Controllers
{
    public class ImportMaterialController : Controller
    {
        // GET: ImportMaterial
        public ActionResult CSV()
        {
            ViewBag.ImportMessage = "Importeer bevestiging";
            return View();
        }
    }
}