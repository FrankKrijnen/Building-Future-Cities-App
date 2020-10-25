using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using BuildingFutureCitiesApp.Models;

namespace BuildingFutureCitiesApp.Controllers
{
    public class ConfigurationController : Controller
    {
        private ConfigurationClass configurationClass;
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



    }
}