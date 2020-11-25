using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CsvHelper;
using BuildingFutureCitiesApp.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace BuildingFutureCitiesApp.Controllers
{

   

    public class ImportMaterialController : Controller
    {
        private List<string> EstateAreas;
        private List<string> EstateObjects;
        private List<string> Distances;
        private List<string> Functions;
        private List<string> Origins;
        private List<string> Removabilities;

        // GET: ImportMaterial
        [HttpPost]
        public async Task<ActionResult> CSV()
        {
            
            using (Stream request = Request.Files["csv-file"].InputStream)
            {
                List<CSVImportData> CSVImportDataList = new List<CSVImportData>();
                using (var reader = new StreamReader(request)) 
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {

                    csv.Read();
                    csv.ReadHeader();
                    try
                    {
                        while (csv.Read())
                        {
                            CSVImportDataList.Add(new CSVImportData
                                (
                                    csv.GetField("Woningbouwdeel (fijn)"),
                                    csv.GetField("Woningbouwdeel (functie)"),
                                    csv.GetField("Woningbouwdeel (grof)"),
                                    csv.GetField("Foto/image"),
                                    csv.GetField("Levensduur"),
                                    csv.GetField("Woningobject"),
                                    csv.GetField<float>("Losmaakbaarheid"),
                                    csv.GetField("Oorsprong"),
                                    csv.GetField("Herkomst_1"),
                                    csv.GetField("Aantal"),
                                    csv.GetField("Eenheid"),
                                    csv.GetField("Embodied energy"),
                                    csv.GetField<float>("Embodied CO2"),
                                    csv.GetField("Herkomst_2"),
                                    csv.GetField("Toekomstscenario/herbruikbaarheid"),
                                    csv.GetField("Bron toekomstscenario"),
                                    csv.GetField("Bron embodied energy"),
                                    csv.GetField("Bron/opmerking")
                                )
                            );
                        }
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("AddMaterial", "Navigation");
                    }


                    FilterDataIntoLists(CSVImportDataList);
                }


                ViewBag.AllRows = CSVImportDataList;

                List<List<string>> allRows = new List<List<string>>();
                allRows.Add(EstateObjects);
                allRows.Add(EstateAreas);
                allRows.Add(Distances);
                allRows.Add(Functions);
                allRows.Add(Origins);
                allRows.Add(Removabilities);
                string json = JsonConvert.SerializeObject(allRows);
                HttpContent estateAreaContent = new StringContent(json);

                using (HttpClient client = new HttpClient())
                {

                    var response = client.PostAsync("http://localhost:5000/API/ImportMaterial/CSV", estateAreaContent).Result.Content.ReadAsStringAsync().Result;

                }
            }
            
            


            ViewBag.EstateAreas = EstateAreas;
            ViewBag.EstateObjects = EstateObjects;
            ViewBag.Distances = Distances;
            ViewBag.Functions = Functions;
            ViewBag.Origins = Origins;
            ViewBag.Removabilities = Removabilities;

            return View();
        }

        public void FilterDataIntoLists(List<CSVImportData> csvImportDataList)
        {
            EstateAreas = new List<string>();
            EstateObjects = new List<string>();
            Distances = new List<string>();
            Functions = new List<string>();
            Origins = new List<string>();
            Removabilities = new List<string>();

            foreach (CSVImportData csvImportData in csvImportDataList)
            {
                EstateAreas.Add(csvImportData.ObjectLiveAreaRoom);
                EstateObjects.Add(csvImportData.ObjectLiveAreaLocation);
                Distances.Add(csvImportData.MaterialDistance);
                Functions.Add(csvImportData.ObjectLiveAreaFunction);
                Origins.Add(csvImportData.MaterialOrigins);
                Removabilities.Add(csvImportData.Removability.ToString());
            }

            EstateAreas = EstateAreas.DistinctBy(x => x).ToList();
            EstateObjects = EstateObjects.DistinctBy(x => x).ToList();
            Distances = Distances.DistinctBy(x => x).ToList();
            Functions = Functions.DistinctBy(x => x).ToList();
            Origins = Origins.DistinctBy(x => x).ToList();
            Removabilities = Removabilities.DistinctBy(x => x).ToList();
        }



    }
}



