using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingFutureCitiesAPI.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingFutureCitiesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        MaterialDataModel materialDataModel;

        public void Constructor()
        {
            materialDataModel = new MaterialDataModel();
        }

        [HttpPost]
        public void SetProfile([FromForm] string FirstName, [FromForm] string LastName, [FromForm] string Email, [FromForm] string Password, [FromForm] string PasswordRepeat)
        {
            string qry2 = "INSERT INTO profile (id, firstname, lastname, email, password) VALUES (0, '" + @FirstName + "', '" + @LastName + "', '" + @Email + "', '" + @Password + "');";
            Constructor();
            materialDataModel.SetRegisterProfile(qry2);
            Response.Redirect("https://localhost:44355/Navigation/Profile");
        }
    }
}
