using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BuildingFutureCitiesAPI.Models;
using BuildingFutureCitiesAPI.DataModels;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using System.Web.WebPages;

namespace BuildingFutureCitiesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        // POST api/<ConfigurationController>
        [HttpPost("SetConfiguration")]
        public void SetConfiguration()
        {
            Console.WriteLine("set config aangeroepen.");
            Response.Redirect("https://localhost:44355/");
        }
    }
}