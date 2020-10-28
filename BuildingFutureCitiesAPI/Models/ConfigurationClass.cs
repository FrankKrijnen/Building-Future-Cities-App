using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BuildingFutureCitiesAPI.Models
{
    public class ConfigurationClass
    {

        //properties
        public string RoomName;
        public List<Material> Configuration;

        //current concept
        public double CurrentConceptSCI;
        public int CurrentConceptCO2;

        //new concept
        public double NewConceptSCI;
        public int NewConceptCO2;

        //constructor
        public ConfigurationClass()
        {

        }

        public ConfigurationClass(List<Material> configuration)
        {
            Configuration = configuration;
        }

        public ConfigurationClass(string roomName, double currentConceptSCI, int currentConceptCO2, double newConceptSCI, int newConceptCO2)
        {
            RoomName = roomName;
            CurrentConceptSCI = currentConceptSCI;
            CurrentConceptCO2 = currentConceptCO2;
            NewConceptSCI = newConceptSCI;
            NewConceptCO2 = newConceptCO2;
        }


    }
}