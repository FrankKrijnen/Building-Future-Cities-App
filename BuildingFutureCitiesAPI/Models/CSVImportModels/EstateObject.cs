using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingFutureCitiesAPI.Models
{
    public class EstateObject : LinkTable
    {
        public EstateObject(string description, int id = 0) : base(description, id)
        {
        }

    }
}