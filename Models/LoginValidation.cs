using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required(ErrorMessage = "Emailadres is vereist"), DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    

        [Required(ErrorMessage = "Wachtwoord is vereist"), DisplayName("Wachtwoord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool isLoggedIn;
        public Profile loggedInProfile;

    }
}