using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuildingFutureCitiesApp.Models
{
    public class Profile
    {
        [Required, DisplayName("Voornaam"), RegularExpression(@"[^\s]+", ErrorMessage = "Een voornaam kan geen spatie bevatten")] public string FirstName { get; set; }
        [Required, DisplayName("Achternaam"), RegularExpression(@"[^\s]+", ErrorMessage = "Een achternaam kan geen spatie bevatten")] public string LastName { get; set; }
        [DataType(DataType.Password), Required, MinLength(5), DisplayName("Wachtwoord"), RegularExpression(@"[^\s]+", ErrorMessage = "Een wachtwooord mag geen spatie bevatten")] public string Password { get; set; }

        [Compare("Password", ErrorMessage = "De wachtwoorden komen niet overeen, probeer het opnieuw!")]
        [DataType(DataType.Password), Required, DisplayName("Herhaal wachtwoord")] public string Password2 { get; set; }
        [Required, EmailAddress] public string Email { get; set; }
    }
}