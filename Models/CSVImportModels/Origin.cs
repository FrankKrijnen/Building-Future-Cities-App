﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingFutureCitiesApp.Models
{
    public class Origin : LinkTable
    {
        public Origin(string description, int id = 0)
        {
            Id = id;
            Description = description;
        }

    }
}