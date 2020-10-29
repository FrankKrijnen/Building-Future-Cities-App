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
        public string ConfigName;
        public List<Material> MaterialList;

        public ConfigurationClass()
        {
            MaterialList = new List<Material>();
        }

        public ConfigurationClass(List<Material> materialList)
        {
            MaterialList = materialList;
        }

        public ConfigurationClass(string roomName, string configName, List<Material> materialList)
        {
            RoomName = roomName;
            ConfigName = configName;
            MaterialList = materialList;
        }


    }
}