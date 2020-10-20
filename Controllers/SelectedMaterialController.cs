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
            ViewBag.Title = "Ciculaire variant";

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
                   
                    List<Material> LinearMaterials = new List<Material>();

                    //adds list of materials with highest embodied co2 per function
                    MaterialList.OrderByDescending(x => x.EmbodiedCO2).ToList();
                    foreach (var material in MaterialList)
                    {
                        if (LinearMaterials.All(i => i.ObjectLiveAreaFunction != material.ObjectLiveAreaFunction))
                        {
                            LinearMaterials.Add(material);
                        } else if (LinearMaterials.Count == 0)
                        {
                            LinearMaterials.Add(material);
                        }
                    }

                    //used by for loop in view
                    ViewBag.MaterialCount = LinearMaterials.Count;

                    ViewBag.LinearMaterials = LinearMaterials;

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
                    ViewBag.SelectedMaterials = SelectedMaterials;
                }
            } return View();
        }

        
    }
}
