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
        public int Configuration_id { get; set; }

        public Configuration()
        {
            MaterialList = new List<Material>();
        }

        public Configuration(List<Material> materialList)
        {
            MaterialList = materialList;
        }

        public Configuration(int configuration_id ,string roomName, string configName, List<Material> materialList)
        {
            Configuration_id = configuration_id;
            RoomName = roomName;
            ConfigName = configName;
            MaterialList = materialList;
        }
    }
}