namespace BuildingFutureCitiesApp.Models
{
    public class CSVImportData : Material
    {
        public string MaterialDistance2 { get; private set; }
        public string UnitType { get; private set; }
        public string Reusability { get; private set; }
        public string SourceReusability { get; private set; }
        public string SourceEmbodiedEnergy { get; private set; }

        public string SourceComment { get; private set; }

        public CSVImportData(string materialName, string objectLiveAreaFunction,
            string objectLiveAreaRoom, string image, string objectLifeSpan, string objectLiveAreaLocation,
            float removAbility, string materialOrigins, string materialDistance, string unit_KG_M2_Amount, string unitType,
            string embodiedEnergy, float embodiedCO2, string materialDistance2, string reusability, string sourceReusability, string sourceEmbodiedEnergy, string sourceComment)
        {
            
            MaterialName = materialName;
            ObjectLiveAreaFunction = objectLiveAreaFunction;
            ObjectLiveAreaRoom = objectLiveAreaRoom;
            Image = image;
            ObjectLifeSpan = objectLifeSpan;
            ObjectLiveAreaLocation = objectLiveAreaLocation;
            Removability = removAbility;
            MaterialOrigins = materialOrigins;
            MaterialDistance = materialDistance;
            MaterialDistance2 = materialDistance2;
            Unit_KG_M2_Amount = unit_KG_M2_Amount;
            UnitType = unitType;
            EmbodiedEnergy = embodiedEnergy;
            EmbodiedCO2 = embodiedCO2;
            Reusability = reusability;
            SourceReusability = sourceReusability;
            SourceEmbodiedEnergy = sourceEmbodiedEnergy;
            SourceComment = sourceComment;
        }

    }
}