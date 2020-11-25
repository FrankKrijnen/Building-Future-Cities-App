using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BuildingFutureCitiesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportMaterial : ControllerBase
    {
        [HttpPost("CSV")]
        public ActionResult CSV()
        {
            Stream requestStream = Request.Body;
            StreamReader streamReader = new StreamReader(requestStream);
            string jsonContent = streamReader.ReadToEnd();

            List<List<string>> allRecords = JsonConvert.DeserializeObject<List<List<string>>>(jsonContent);


            return Ok(jsonContent);
        }

    }
}
