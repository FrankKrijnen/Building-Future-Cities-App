using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuildingFutureCitiesApp.Models
{
    public class Profile
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [DataType(DataType.Password), Required, MinLength(5)] public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [Required] public string Password2 { get; set; }
        [Required] public string Email { get; set; }
    }
}