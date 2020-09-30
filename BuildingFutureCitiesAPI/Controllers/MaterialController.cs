using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BuildingFutureCitiesAPI.Models;
using BuildingFutureCitiesAPI.DataModels;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuildingFutureCitiesAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        MaterialDataModel materialDataModel;
        private string testString = "";

        public void Constructor()
        {
            materialDataModel = new MaterialDataModel();
        }

        // GET: api/<MaterialController>
        [HttpGet]
        public ActionResult Get()
        {
            Constructor();
            materialDataModel.GetMaterialDataAndBuildList();
            List<Material> materials = materialDataModel.MaterialList;
            if (materials.Count <= 0 || materialDataModel.GetDatabaseConnection().Connection == null)
            {
                return NoContent();
            }

            return Ok(materialDataModel.MaterialList);
        }

        // GET api/<MaterialController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MaterialController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MaterialController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MaterialController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int materialId)
        {
            Constructor();
            if (materialDataModel.GetDatabaseConnection().Connection.State ==  ConnectionState.Closed )
            {
                return NoContent();
            }

            return Ok("connection OK");
        }
    }
}
