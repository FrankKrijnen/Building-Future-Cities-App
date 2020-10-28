using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingFutureCitiesApp.Models;

namespace BuildingFutureCitiesApp.Controllers
{
    public class ConfigurationController : LoginController
    {
        private ConfigurationClass configurationClass;

        List<ConfigurationClass> ConfigurationList;
        public void Constructor()
        {
            configurationClass = new ConfigurationClass();
        }


        public ConfigurationClass BuildConfiguration(List<Material> configuration)
        {
            Constructor();
            configurationClass.Configuration = configuration;
            return configurationClass;
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
            return Redirect("https://localhost:44355/Login/Login");
        }

    }
}