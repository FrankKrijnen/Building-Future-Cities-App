using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingFutureCitiesApp.Models
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

        }
        public Material(int id ,string materialName, string objectLiveAreaFunction, string objectLiveAreaRoom,string image,string objectLifeSpan,string objectLiveAreaLocation, float removability, string materialOrigins, string materialDistance, string unit_KG_M2_Amount, string embodiedEnergy, float embodiedCO2)
        {
            Id = id;
            MaterialName = materialName;
            ObjectLiveAreaFunction = objectLiveAreaFunction;
            ObjectLiveAreaRoom = objectLiveAreaRoom;
            Image = image;
            ObjectLifeSpan = objectLifeSpan;
            ObjectLiveAreaLocation = objectLiveAreaLocation;
            Removability = removability;
            MaterialOrigins = materialOrigins;
            MaterialDistance = materialDistance;
            Unit_KG_M2_Amount = unit_KG_M2_Amount;
            EmbodiedEnergy = embodiedEnergy;
            EmbodiedCO2 = embodiedCO2;
        }

    }
}