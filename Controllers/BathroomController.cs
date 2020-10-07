using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BuildingFutureCitiesApp.Models;
using Newtonsoft.Json;
using Renci.SshNet.Messages.Authentication;

namespace BuildingFutureCitiesApp.Controllers
{
    public class BathroomController : Controller
    {
        List<Material> BathroomMaterialList;
        // GET: Bathroom
        public async Task<ActionResult> Index()
        {
            ViewBag.Message = "Badkamer";
            ViewBag.Title = "Stel de " + ViewBag.Message + " samen";








            //BathroomMaterialList.Add(new Material(0, "MaterialName", "ObjectLiveAreaFunction", "ObjectLiveAreaRoom", "Image", "ObjectLifeSpan" ,"ObjectLiveAreaLocation",6.19f, "MaterialOrigins", "MaterialDistance", "Units", "EmbodiedEnergy", "EmbodiedCo2", "Lifespan"));

            

            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://localhost:5000/api/material").Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    string responseString = responseContent.ReadAsStringAsync().Result;

                    List<Material> BathroomMaterialList = JsonConvert.DeserializeObject<List<Material>>(responseString);

                    List<Material> LightingMaterialList = new List<Material>();
                    List<Material> VentilationMaterialList = new List<Material>();
                    List<Material> HeatingMaterialList = new List<Material>();
                    List<Material> DryingCapacityMaterialList = new List<Material>();
                    List<Material> EnergyMaterialList = new List<Material>();
                    List<Material> HandWashMaterialList = new List<Material>();
                    List<Material> BodyWashMaterialList = new List<Material>();
                    List<Material> StorageMaterialList = new List<Material>();
                    List<Material> AfvoerMaterialList = new List<Material>();


                    foreach (var material in BathroomMaterialList)
                    {
                        if (material.ObjectLiveAreaFunction == "Verlichting")
                        {
                            LightingMaterialList.Add(material);
                        }
                        if (material.ObjectLiveAreaFunction == "Ventilatie")
                        {
                            VentilationMaterialList.Add(material);
                        }
                        if (material.ObjectLiveAreaFunction == "Verwarming")
                        {
                            HeatingMaterialList.Add(material);
                        }
                        if (material.ObjectLiveAreaFunction == "Droog Capaciteit")
                        {
                            DryingCapacityMaterialList.Add(material);
                        }
                        if (material.ObjectLiveAreaFunction == "Energie")
                        {
                            EnergyMaterialList.Add(material);
                        }
                        if (material.ObjectLiveAreaFunction == "Handwassen")
                        {
                            HandWashMaterialList.Add(material);
                        }
                        if (material.ObjectLiveAreaFunction == "Lichaamwassen")
                        {
                            BodyWashMaterialList.Add(material);
                        }
                        if (material.ObjectLiveAreaFunction == "Opbergen")
                        {
                            StorageMaterialList.Add(material);
                        }
                        if (material.ObjectLiveAreaFunction == "Afscheiding")
                        {
                            AfvoerMaterialList.Add(material);
                        }
                    }


                    if (BathroomMaterialList.Any())
                    {
                        ViewBag.BathroomMaterialList = BathroomMaterialList;
                    }
                    else
                    {
                        ViewBag.BathroomMaterialList = null;
                    }

                    ViewBag.LightingMaterialList = LightingMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList(); 
                    ViewBag.VentilationMaterialList = VentilationMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList(); 
                    ViewBag.HeatingMaterialList = HeatingMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList(); 
                    ViewBag.DryingCapacityMaterialList = DryingCapacityMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList(); 
                    ViewBag.EnergyMaterialList = EnergyMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList(); 
                    ViewBag.HandWashMaterialList = HandWashMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList(); 
                    ViewBag.BodyWashMaterialList = BodyWashMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList(); 
                    ViewBag.StorageMaterialList = StorageMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList(); 
                    ViewBag.AfvoerMaterialList = AfvoerMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList(); 


                }
            }

            
            return View();
        }

        public async Task DoSomethingAsync()
        {
            // In the Real World, we would actually do something...
            // For this example, we're just going to (asynchronously) wait 100ms.
            
        }
    }
}