using System;
using System.Collections.Generic;
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
            if (materials.Count <= 0)
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
        public void SetMaterial([FromForm] string ProductName, [FromForm] int LiveArea, [FromForm] int ObjectLiveAreaFunction,
            [FromForm] int Removability, [FromForm] int MaterialOrigins,
            [FromForm] int MaterialDistance, [FromForm] int Unit_Kg_M2_Amount, [FromForm] decimal EmbodiedEnergie,
            [FromForm] decimal EmbodiedCO2, [FromForm] int LifeSpan)
        {
            string qry = @"INSERT INTO materials (materials_id, material, estate_object_id, estate_area_id, function_id, units, origin_id, distance_id, embodied_energy, embodied_co2, lifespan, removability_id, image) VALUES (0, " + ProductName + ", '" + 1 + "', '" + LiveArea + "', '" + ObjectLiveAreaFunction + "', '" + Unit_Kg_M2_Amount + "', '" + MaterialOrigins + "', '" + MaterialDistance + "', '" + EmbodiedEnergie + "', '" + EmbodiedCO2 + "', '" + LifeSpan + "', '" + Removability + "', 'hgfhfgjhfghj');";
            Constructor();
            materialDataModel.SetMaterialItem(qry);
        }

        // PUT api/<MaterialController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MaterialController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
