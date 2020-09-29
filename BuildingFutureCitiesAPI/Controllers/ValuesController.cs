using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BuildingFutureCitiesAPI.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace BuildingFutureCitiesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            Material material = new Material(id, "Metal Door Handle");
            return Ok($"Material found with id:{id} name: {material.Name}");
        }

        // GET api/values/create/4/radiator
        [HttpGet("create/{id}/{name}")]
        public ActionResult<string> Get(int id, string name)
        {
          
            Material material = new Material(id,name);
            return Ok($"Material created in database with id: {material.Id} and name: {material.Name}");
        }

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] string value,string value2)
        {
            if (value == "hey")
            {
                return Ok(value + value2);
            }
            else
            {
                return NotFound();
            }
            
        }

        // PUT api/values/update/4/radiator
        [HttpPut("update/{id}/{newName}")]
        public ActionResult<string> Put(int id, string newName)
        {
            Material material = new Material(id, "Wooden Door");
            return Ok($"Material Updated in database With id: {id} and name: {material.Name} to name : {newName}");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            Material material = new Material(id,"Wooden Door");
            return Ok($"Material Deleted in database With id: {id} and name: {material.Name}");
        }
    }
}
