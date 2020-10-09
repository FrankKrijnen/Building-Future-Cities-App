using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingFutureCitiesAPI.Models
{
    public class Profile
    {
        //properties
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string Email { get; set; }

        //constructor
        public Profile()
        {

        }

        public Profile(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = Email;
        }
        
        
    }
}
