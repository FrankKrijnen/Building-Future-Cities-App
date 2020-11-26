using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingFutureCitiesApp.Models
{
    public class ConfigurationUpdate
    {
        public int ConfigurationId { get; set; }
        public FormCollection collection { get; set; }
    }
}