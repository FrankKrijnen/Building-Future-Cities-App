using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingFutureCitiesApp.Models
{
    public class Material
    {
        public int Id { get; private set; }
        public string MaterialName { get; private set; }
        public string EmbodiedEnergy { get; private set; }
        public float EmbodiedCO2 { get; private set; }
        public string Image { get; private set; }

        public string ObjectLifeSpan { get; private set; }

        public string Unit_KG_M2_Amount { get; private set; }
        public string ObjectLiveAreaRoom { get; private set; }
        public string ObjectLiveAreaLocation { get; private set; }
        public string ObjectLiveAreaFunction { get; private set; }

        public string MaterialDistance { get; private set; }

        public string MaterialOrigins { get; private set; }
        public float Removability { get; private set; }


        public Material(int id ,string materialName, string objectLiveAreaFunction, string objectLiveAreaRoom,string image,string objectLifeSpan,string objectLiveAreaLocation, float removAbility, string materialOrigins, string materialDistance, string unit_KG_M2_Amount, string embodiedEnergy, float embodiedCO2, string LifeSpan)
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

    }
}