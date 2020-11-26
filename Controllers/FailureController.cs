using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingFutureCitiesApp.Controllers
{
    public class FailureController : Controller
    {
        // GET: Failure
        public ActionResult Failure()
        {
            HttpCookie myCookie = new HttpCookie("StatusMessage");
            myCookie.Value = "Failure";
            myCookie.Expires = DateTime.Now.AddSeconds(7);
            Response.Cookies.Add(myCookie);
            return Redirect("https://localhost:44355/Navigation/Index");
        }
    }
}