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

        public Material()
        {
            Id = 0;
            Name = "";
        }
        public Material(int id, string name)
        {
            this.Id = id;
            this.Name = name;
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
