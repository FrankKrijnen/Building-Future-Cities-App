﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingFutureCitiesApp.Models
{
    public class EstateArea : LinkTable
    {
        public EstateArea(string description , int id = 0)
        {
            Id = id;
            Description = description;
        }

    }
}