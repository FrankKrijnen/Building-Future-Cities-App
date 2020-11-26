using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BuildingFutureCitiesAPI.DataModels;
using BuildingFutureCitiesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BuildingFutureCitiesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportMaterial : ControllerBase
    {

        MaterialDataModel materialDataModel;
        private LinkTableDataModel linkTableDataModel;

        /// <summary>
        /// <see cref="CSV">test</see>
        /// </summary>
        [HttpPost("CSV")]
        public ActionResult CSV()
        {
            //read stream from http body
            Stream requestStream = Request.Body;
            StreamReader streamReader = new StreamReader(requestStream);

            //jsonContent = jsonLinkTableData + "|%delimiter%|" + jsonAllData
            string delimiter = "|%delimiter%|";
            string jsonContent = streamReader.ReadToEnd();

            //split json string into 2 strings
            string jsonLinkTableData = jsonContent.Substring(0,jsonContent.IndexOf(delimiter));
            string jsonAllData = jsonContent.Substring(jsonContent.IndexOf(delimiter) + delimiter.Length);

            //convert json strings to list objects
            List<List<string>> linkTableRecords = JsonConvert.DeserializeObject<List<List<string>>>(jsonLinkTableData);
            //origins = herkomst_1
            //hier
            List<CSVImportData> allDataRecords = JsonConvert.DeserializeObject<List<CSVImportData>>(jsonAllData);


            //linktableRecords met id's
            List<KeyValuePair<int, string>> estateObjectsId = CreateAndGetIdLinkTable(linkTableRecords[0], "estate_objects", "estate_object", "estate_object_id");
            List<KeyValuePair<int, string>> estateAreasId = CreateAndGetIdLinkTable(linkTableRecords[1], "estate_area", "estate_area", "estate_area_id");
            List<KeyValuePair<int, string>> distancesId = CreateAndGetIdLinkTable(linkTableRecords[2], "material_distance", "distance", "material_distance_id");
            List<KeyValuePair<int, string>> functionsId = CreateAndGetIdLinkTable(linkTableRecords[3], "functions", "function", "function_id");
            List<KeyValuePair<int, string>> originsId = CreateAndGetIdLinkTable(linkTableRecords[4], "material_origin", "origins", "origins_id");
            List<KeyValuePair<int, string>> removabilitiesId = CreateAndGetIdLinkTable(linkTableRecords[5], "removability", "removability", "removability_id");

            //vergelijk strings van allDataRecords en vervang strings met id's uit KeyValuePair<int, string>
            foreach (CSVImportData item in allDataRecords) 
            { 
                
            }

            //maak query voor setmaterial
            string materialqry = string.Empty;

            return Ok(jsonContent);
        }

        //EstateObjects = [0]
        //EstateAreas = [1]
        //Distances = [2]
        //Functions = [3]
        //Origins = [4]
        //Removabilities = [5]

        public List<KeyValuePair<int, string>> CreateAndGetIdLinkTable(List<string> linkTable, string linkTableName, string LinkTableColumnName, string LinkTableColumnId)
        {
            linkTableDataModel = new LinkTableDataModel();
            List<KeyValuePair<int,string>> linkTableKeyValuePair = new List<KeyValuePair<int, string>>();

            foreach (string description in linkTable)
            {
                string qry = "INSERT IGNORE INTO `" + linkTableName + "`(`"+ LinkTableColumnName +"`) VALUES ('"+ description +"');" +
                             "SELECT LAST_INSERT_ID();";
                int id = linkTableDataModel.GetLinkTableId(qry, LinkTableColumnId);
                if (id == 0)
                {
                    string qry2 = "SELECT " + LinkTableColumnId + " FROM `" + linkTableName + "` WHERE `" + LinkTableColumnName + "` = '" + description + "'";
                    id = linkTableDataModel.GetLinkTableId(qry2, LinkTableColumnId);
                }
                
                linkTableKeyValuePair.Add(new KeyValuePair<int, string>(id, description));
                
            }
            
            return linkTableKeyValuePair;
        }
 
    }
}
