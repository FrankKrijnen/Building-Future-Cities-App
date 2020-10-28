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
        private ConfigurationDataModel configurationDataModel;
        public void Constructor()
        {
            configurationDataModel = new ConfigurationDataModel();
        }

        // POST api/<ConfigurationController>
        [HttpPost("SetConfiguration")]
        public void SetConfiguration([FromForm] int[] material_id, [FromForm] string description)
        {
            Constructor();
           
            //1 keer uitvoeren voor setup
            string qry =
                "INSERT INTO `configuration` (`id`, `description`, `room`) VALUES (NULL, '"+ @description +"', 'Badkamer');";
            configurationDataModel.SetConfiguration(qry);
            
            //krijg id terug van net gemaakte configuratie
            string qry2 = "SELECT id FROM `configuration` WHERE description = '" + @description + "' AND room = 'Badkamer'";
            int configurationId = configurationDataModel.GetConfigurationId(qry2);

            //meerdere keren uitvoeren 
            string partOfQry3 = string.Empty;
            int materialIdIndex = material_id.Length;
            foreach (int materialId in material_id)
            {
                //checkt op laatste material
                if (materialIdIndex.Equals(1))
                {
                    partOfQry3 += "(NULL, '" + @configurationId + "', '" + materialId + "')";
                    break;
                }
                partOfQry3 += "(NULL, '"+ @configurationId + "', '"+ materialId + "'),";
                materialIdIndex--;
            }
            string qry3 =
                "INSERT INTO `configuration_material` (`id`, `configuration_id`, `material_id`) VALUES" + partOfQry3 + ";";
            configurationDataModel.SetConfiguration(qry3);

            Response.Redirect("https://localhost:44355/Navigation/Configuration");
        }

        // POST api/<ConfigurationController>
        [HttpPost("GetConfiguration")]
        public void GetConfigurationForProfile([FromForm] int profile_id)
        {
            
        }

    }
}