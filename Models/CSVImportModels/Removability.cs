using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingFutureCitiesApp.Models
{
    public class Removability : LinkTable
    {
        public Removability(float description, int id = 0)
        {
            Id = id;
            Description = description.ToString();
        }

    }
}