using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BuildingFutureCitiesApp.Models
{

    /// <summary>
    ///  <see cref="LoginValidation"/> class which uses <see cref="Profile"/> class to login
    /// </summary>
    public class LoginValidation
    {
        [Required(ErrorMessage = "Emailadres is vereist")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    

        [Required(ErrorMessage = "Wachtwoord is vereist")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool isLoggedIn;
        public Profile loggedInProfile;

    }
}