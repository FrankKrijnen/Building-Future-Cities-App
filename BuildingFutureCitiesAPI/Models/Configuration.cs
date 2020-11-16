using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BuildingFutureCitiesAPI.Models
{
    public class Configuration
    {

        //properties
        public string RoomName;
        public string ConfigName;
        public List<Material> MaterialList;

        public Configuration()
        {
            MaterialList = new List<Material>();
        }

        public Configuration(List<Material> materialList)
        {
            MaterialList = materialList;
        }

        public Configuration(string roomName, string configName, List<Material> materialList)
        {
            RoomName = roomName;
            ConfigName = configName;
            MaterialList = materialList;
        }


    }
}