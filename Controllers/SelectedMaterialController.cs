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
    public class SelectedMaterialController : Controller
    {

        
        // GET: SelectedMaterial
        public ActionResult Index()
        {
            return View();
        }



        // POST: SelectedMaterial/Create
    [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            ViewBag.Title = "gekozen materialen";

            var IdList = new List<int>();

            //collects material id's from form
            foreach (string key in collection.Keys)
            {
                var value = int.Parse(collection[key]);
                IdList.Add(value);
                             
            }

            //collects list of all materials in database
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://localhost:5000/api/material").Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    string responseString = responseContent.ReadAsStringAsync().Result;

                    List<Material> MaterialList = JsonConvert.DeserializeObject<List<Material>>(responseString);
                    
                 


                    //creates list of selected materials
                    List<Material> SelectedMaterials = new List<Material>();
                    foreach (int id in IdList)
                    {
                        foreach (Material material in MaterialList)
                        {
                            if(material.Id == id)
                            {
                                SelectedMaterials.Add(material);
                            }
                        }
                        
                        
                    }
                    Console.WriteLine(SelectedMaterials[0]);
                    ViewBag.SelectedMaterials = SelectedMaterials;


                    //        //Bathroom list with all sorted material rows 
                    //        List<List<Material>> BathroomRowList = new List<List<Material>>();

                    //        if (MaterialList.Any())
                    //        {
                    //            ViewBag.MaterialList = MaterialList;
                    //        }
                    //        else
                    //        {
                    //            ViewBag.MaterialList = null;
                    //        }


                    //        BathroomRowList.Add(LightingMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());
                    //        BathroomRowList.Add(VentilationMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());
                    //        BathroomRowList.Add(HeatingMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());
                    //        BathroomRowList.Add(DryingCapacityMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());
                    //        BathroomRowList.Add(EnergyMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());
                    //        BathroomRowList.Add(HandWashMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());
                    //        BathroomRowList.Add(BodyWashMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());
                    //        BathroomRowList.Add(StorageMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());
                    //        BathroomRowList.Add(SeparationMaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList());

                    //        ViewBag.BathroomRowList = BathroomRowList;
                }
            }
                    return View();
        }

        
    }
}
