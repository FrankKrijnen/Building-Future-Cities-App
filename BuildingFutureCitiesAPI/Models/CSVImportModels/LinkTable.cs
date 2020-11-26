using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingFutureCitiesAPI.Models
{
    public abstract class LinkTable
    {
        public int Id { get; protected set; }
        public string Description { get; protected set; }
        public LinkTable()
        {
        }
        public LinkTable(string description, int id = 0)
        {
            Id = id;
            Description = description;
        }

    }
}