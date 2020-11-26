using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingFutureCitiesAPI.Models
{
    public class Distance : LinkTable
    {
        public Distance(string description, int id = 0) : base(description, id)
        {
        }

    }
}