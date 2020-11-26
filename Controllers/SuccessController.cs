using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingFutureCitiesApp.Controllers
{
    public class SuccessController : Controller
    {
        // GET: Success
        public ActionResult Success()
        {
            HttpCookie myCookie = new HttpCookie("StatusMessage");
            myCookie.Value = "Success";
            myCookie.Expires = DateTime.Now.AddSeconds(7);
            Response.Cookies.Add(myCookie);
            return Redirect("https://localhost:44355/Navigation/Index");
        }
    }
}