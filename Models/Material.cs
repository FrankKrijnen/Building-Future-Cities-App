using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingFutureCitiesApp.Models
{
    public class Material
    {
        public int Id { get; private set; }
        public string ProductName { get; private set; }
        public string LiveArea { get; private set; }
        public string ObjectLiveAreaFunction { get; private set; }
        public string ObjectLiveAreaFijn { get; private set; }
        public float Removability { get; private set; }
        public string MaterialOrigins { get; private set; }
        public string MaterialDistance { get; private set; }
        public string Unit_KG_M2_Amount { get; private set; }
        public string EmbodiedEnergy { get; private set; }
        public string EmbodiedCO2 { get; private set; }
        public string LifeSpan { get; private set; }


        public Material(int id ,string productName, string liveArea, string objectLiveAreaFunction, string objectLiveAreaFijn, float removAbility, string materialOrigins, string materialDistance, string unit_KG_M2_Amount, string embodiedEnergy, string embodiedCO2, string LifeSpan)
        {
            this.Id = id;
            this.ProductName = productName;
            this.LiveArea = LiveArea;
            this.ObjectLiveAreaFunction = objectLiveAreaFunction;
            this.ObjectLiveAreaFijn = objectLiveAreaFijn;
            this.Removability = removAbility;
            this.MaterialOrigins = materialOrigins;
            this.MaterialDistance = materialDistance;
            this.Unit_KG_M2_Amount = unit_KG_M2_Amount;
            this.EmbodiedEnergy = embodiedEnergy;
            this.EmbodiedCO2 = embodiedCO2;
            this.LifeSpan = LifeSpan;
        }

    }
}