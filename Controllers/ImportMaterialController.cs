using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CsvHelper;
using BuildingFutureCitiesApp.Models;
using Microsoft.Ajax.Utilities;

namespace BuildingFutureCitiesApp.Controllers
{

   

    public class ImportMaterialController : Controller
    {
        private List<EstateArea> EstateAreas;
        private List<EstateObject> EstateObjects;
        private List<Distance> Distances;
        private List<Function> Functions;
        private List<Origin> Origins;
        private List<Removability> Removabilities;

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
            EstateAreas = new List<EstateArea>();
            EstateObjects = new List<EstateObject>();
            Distances = new List<Distance>();
            Functions = new List<Function>();
            Origins = new List<Origin>();
            Removabilities = new List<Removability>();

            foreach (CSVImportData csvImportData in csvImportDataList)
            {
                EstateAreas.Add(new EstateArea(csvImportData.ObjectLiveAreaRoom));
                EstateObjects.Add(new EstateObject(csvImportData.ObjectLiveAreaLocation));
                Distances.Add(new Distance(csvImportData.MaterialDistance));
                Functions.Add(new Function(csvImportData.ObjectLiveAreaFunction));
                Origins.Add(new Origin(csvImportData.MaterialOrigins));
                Removabilities.Add(new Removability(csvImportData.Removability));
            }

            EstateAreas = EstateAreas.DistinctBy(x => x.Description).ToList();
            EstateObjects = EstateObjects.DistinctBy(x => x.Description).ToList();
            Distances = Distances.DistinctBy(x => x.Description).ToList();
            Functions = Functions.DistinctBy(x => x.Description).ToList();
            Origins = Origins.DistinctBy(x => x.Description).ToList();
            Removabilities = Removabilities.DistinctBy(x => x.Description).ToList();
        }



    }
}



