using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingFutureCitiesAPI.Models
{
    public class Material
    {
        public int Id { get; protected set; }
        public string MaterialName { get; protected set; }
        public string EmbodiedEnergy { get; protected set; }
        public float EmbodiedCO2 { get; protected set; }
        public string Image { get; protected set; }

        public string ObjectLifeSpan { get; protected set; }

        public string Unit_KG_M2_Amount { get; protected set; }
        public string ObjectLiveAreaRoom { get; protected set; }
        public string ObjectLiveAreaLocation { get; protected set; }
        public string ObjectLiveAreaFunction { get; protected set; }

        public string MaterialDistance { get; protected set; }

        public string MaterialOrigins { get; protected set; }
        public float Removability { get; protected set; }

        public Material()
        {
            Id = 0;
            MaterialName = "";
            ObjectLiveAreaFunction = "";
            ObjectLiveAreaRoom = "";
            Image = "";
            ObjectLifeSpan = "";
            ObjectLiveAreaLocation = "";
            Removability = 0;
            MaterialOrigins = "";
            MaterialDistance = "";
            Unit_KG_M2_Amount = "";
            EmbodiedEnergy = "";
            EmbodiedCO2 = 0f;
        }
        public Material(int id, string materialName)
        {
            Id = id;
            MaterialName = materialName;
            ObjectLiveAreaFunction = "";
            ObjectLiveAreaRoom = "";
            Image = "";
            ObjectLifeSpan = "";
            ObjectLiveAreaLocation = "";
            Removability = 0;
            MaterialOrigins = "";
            MaterialDistance = "";
            Unit_KG_M2_Amount = "";
            EmbodiedEnergy = "";
            EmbodiedCO2 = 0f;
        }
        public Material(int id, string materialName, string objectLiveAreaFunction, string objectLiveAreaRoom, string image, string objectLifeSpan, string objectLiveAreaLocation, float removAbility, string materialOrigins, string materialDistance, string unit_KG_M2_Amount, string embodiedEnergy, float embodiedCO2)
        {
            Id = id;
            MaterialName = materialName;
            ObjectLiveAreaFunction = objectLiveAreaFunction;
            ObjectLiveAreaRoom = objectLiveAreaRoom;
            Image = image;
            ObjectLifeSpan = objectLifeSpan;
            ObjectLiveAreaLocation = objectLiveAreaLocation;
            Removability = removAbility;
            MaterialOrigins = materialOrigins;
            MaterialDistance = materialDistance;
            Unit_KG_M2_Amount = unit_KG_M2_Amount;
            EmbodiedEnergy = embodiedEnergy;
            EmbodiedCO2 = embodiedCO2;
        }
       
        public void SetMaterialId(int id)
        {
            this.Id = id;
        }
        public void SetMaterialName(string materialName)
        {
            this.MaterialName = materialName;
        }


    }
}
