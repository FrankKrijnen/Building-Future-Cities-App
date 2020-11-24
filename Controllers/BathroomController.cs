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
    public class BathroomController : LoginController
    {
        List<Material> BathroomMaterialList;

        // GET: Bathroom
        public async Task<ActionResult> Index(int configId)
        {
            HttpCookie configurationCookie = new HttpCookie("configuration_id");
            configurationCookie.Values.Add("configurationId", configId.ToString());
            configurationCookie.Expires = DateTime.Now.AddHours(12);
            Response.Cookies.Add(configurationCookie);

            ViewBag.configId = configId;
            BuildTable();

            if (configId > 0)
            {
                SelectItemsFromConfig(configId);
            }

            if (IsLoggedIn())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Navigation");
            }
        }

        private void SelectItemsFromConfig(int configId)
        {
            using(var client = new HttpClient())
            {
                var response = client.GetAsync("http://localhost:5000/api/configuration/GetMaterials?configurationId=" + configId + "").Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    List<int> configMaterialIds = JsonConvert.DeserializeObject<List<int>>(responseString);
                    ViewBag.configMaterialIds = configMaterialIds;
                }
            }
        }

        private void BuildTable()
        {
            ViewBag.Message = "Badkamer";
            ViewBag.Title = "Stel hier uw " + ViewBag.Message + " samen";

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
                    List<Material> SeparationMaterialList = new List<Material>();

                    //Bathroom list with all sorted material rows 
                    List<List<Material>> BathroomRowList = new List<List<Material>>();

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
                            SeparationMaterialList.Add(material);
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


                    BathroomRowList.Add(LightingMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());
                    BathroomRowList.Add(VentilationMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());
                    BathroomRowList.Add(HeatingMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());
                    BathroomRowList.Add(DryingCapacityMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());
                    BathroomRowList.Add(EnergyMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());
                    BathroomRowList.Add(HandWashMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());
                    BathroomRowList.Add(BodyWashMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());
                    BathroomRowList.Add(StorageMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());
                    BathroomRowList.Add(SeparationMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());

                    ViewBag.BathroomRowList = BathroomRowList;
                }
            }
        }

        public async Task DoSomethingAsync()
        {
            // In the Real World, we would actually do something...
            // For this example, we're just going to (asynchronously) wait 100ms.

        }
    }
}