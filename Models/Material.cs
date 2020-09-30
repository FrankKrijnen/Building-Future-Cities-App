using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingFutureCitiesApp.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string LiveArea { get; set; }
        public string ObjectLiveAreaFunction { get; set; }
        public string ObjectLiveAreaFijn { get; set; }
        public float Removability { get; set; }
        public string MaterialOrigins { get; set; }
        public string MaterialDistance { get; set; }
        public string Unit_KG_M2_Amount { get; set; }
        public string EmbodiedEnergy { get; set; }
        public string EmbodiedCO2 { get; set; }
        public string LifeSpan { get; set; }


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