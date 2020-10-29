using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingFutureCitiesAPI.DataModels;
using BuildingFutureCitiesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MySqlX.XDevAPI;

namespace BuildingFutureCitiesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        MaterialDataModel materialDataModel;
        private ProfileDataModel profileDataModel;

        public void Constructor()
        {
            materialDataModel = new MaterialDataModel();
        }

        public void InitializeDataModel()
        {
            profileDataModel = new ProfileDataModel();
        }

        [HttpPost]
        public void SetProfile([FromForm] string FirstName, [FromForm] string LastName, [FromForm] string Email, [FromForm] string Password, [FromForm] string PasswordRepeat)
        {
            string qry2 = "INSERT INTO profile (id, firstname, lastname, email, password) VALUES (0, '" + @FirstName + "', '" + @LastName + "', '" + @Email + "', '" + @Password + "');";
            Constructor();
            materialDataModel.SetRegisterProfile(qry2);
            Response.Redirect("https://localhost:44355/Navigation/Profile");
        } 

        [HttpPost("LoginValidation")]
        public ActionResult GetProfile([FromForm] string Email, [FromForm] string Password)
        {
            string qry = "SELECT * FROM `profile` WHERE email = '" + @Email + "' AND password = '" + @Password + "';";
            InitializeDataModel();
            Profile profile = profileDataModel.GetProfileData(qry);
            if (profileDataModel.GetDatabaseConnection().Connection == null)
            {
                return NoContent();
            }
            if (profile.Email == null)
            {
                Response.Cookies.Append("account_not_found", "true");
                return Redirect("https://localhost:44355/Login/Login");
            }

            //Models.Profile.Email.**get** returned null.
            Response.Cookies.Append("id", profile.Id.ToString());
            Response.Cookies.Append("firstname", profile.FirstName);
            Response.Cookies.Append("lastname", profile.LastName);
            Response.Cookies.Append("email", profile.Email);
            
            return Redirect("https://localhost:44355/Navigation/index");
        }
    }
}
