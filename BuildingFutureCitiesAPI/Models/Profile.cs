using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingFutureCitiesAPI.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string Email { get; set; }

        public Profile()
        {
            Id = 0;
            FirstName = null;
            LastName = null;
            Email = null;
        }

        public Profile(int id,string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = Email;
        }
        
        
    }
}
