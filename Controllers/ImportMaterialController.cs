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
namespace BuildingFutureCitiesApp.Controllers
{

   

    public class ImportMaterialController : Controller
    {

        // GET: ImportMaterial
        [HttpPost]
        public async Task<ActionResult> CSV()
        {
            Stream request = Request.Files["csv-file"].InputStream;
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
                

            }


            ViewBag.ImportMessage += "Importeer bevestiging";
            ViewBag.AllRows = CSVImportDataList;
            return View();
        }
    }
}