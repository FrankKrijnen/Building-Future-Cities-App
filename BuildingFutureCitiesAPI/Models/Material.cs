using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingFutureCitiesAPI.Models
{
    public class Material
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string EstateObjectName { get; private set; }
        public string EstateArea { get; private set; }
        public string Function { get; private set; }
        public int Units { get; private set; }
        public string OriginName{ get; private set; }
        public string Distance { get; private set; }
        public string EmbodiedEnergy { get; private set; }
        public string EmbodiedCo2 { get; private set; }
        public string Lifespan{ get; private set; }
        public string Removability { get; private set; }
        public string Image { get; private set; }

        public Material()
        {
            Id = 0;
            Name = "";
            EstateObjectName = "";
            EstateArea = ""; 
            Function = "";
            Units = 0; 
            OriginName = "";
            Distance = ""; 
            EmbodiedEnergy = "";
            EmbodiedCo2 = "";
            Lifespan = ""; 
            Removability = ""; 
            Image = "";
        }
        public Material(int id, string name)
        {
            Id = id;
            Name = name;
            EstateObjectName = "";
            EstateArea = "";
            Function = "";
            Units = 0;
            OriginName = "";
            Distance = "";
            EmbodiedEnergy = "";
            EmbodiedCo2 = "";
            Lifespan = "";
            Removability = "";
            Image = "";
        }
        public Material(int id, string name, string estateObjectName, string estateArea, string function,
            int units, string originName, string distance, string embodiedEnergy, string embodiedCo2, string lifespan, string removability, string image)
        {
            Id = id;
            Name = name;
            EstateObjectName = estateObjectName;
            EstateArea = estateArea;
            Function = function;
            Units = units;
            OriginName = originName;
            Distance = distance;
            EmbodiedEnergy = embodiedEnergy;
            EmbodiedCo2 = embodiedCo2;
            Lifespan = lifespan;
            Removability = removability;
            Image = image;
        }
        public int GetMaterialId()
        {
            return Id;
        }
        public string GetMaterialName()
        {
            return Name;
        }
        public void SetMaterialId(int id)
        {
            this.Id = id;
        }
        public void SetMaterialName(string name)
        {
            this.Name = name;
        }


    }
}
