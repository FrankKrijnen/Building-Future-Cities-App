using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BuildingFutureCitiesApp.Models;
using Newtonsoft.Json;

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


        public ActionResult Overview()
        {
            ViewBag.Title = "Configuratie overzicht";

            ConfigurationList = new List<ConfigurationClass>();

            int profileId = Convert.ToInt32(Request.Cookies["id"].Value);
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://localhost:5000/api/configuration/GetConfiguration/"+ profileId + "").Result.Content.ReadAsStringAsync().Result;

                List<ConfigurationClass> JsonConfigurationList = JsonConvert.DeserializeObject<List<ConfigurationClass>>(response);
                ConfigurationList = JsonConfigurationList;

            }
            
            

            ViewBag.ConfigurationList = ConfigurationList;

            if (IsLoggedIn())
            {
                return View();
            }
            return Redirect("https://localhost:44355/Login/Login");
        }

    }
}