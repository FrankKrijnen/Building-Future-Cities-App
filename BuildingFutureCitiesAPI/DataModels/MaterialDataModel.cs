using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BuildingFutureCitiesAPI.Models;
using MySql.Data.MySqlClient;

namespace BuildingFutureCitiesAPI.DataModels
{
    public class MaterialDataModel : DataModel
    {
        public List<Material> MaterialList { get; set; }

        public void GetMaterialDataAndBuildList()
        {
            List<Material> materialList = new List<Material>();

            using (MySqlCommand qry = GetDatabaseConnection().PrepareSql($@"SELECT 
                materials_id,
                material,
                embodied_energy,
                embodied_co2,
                image,
                lifespan,
                units,
                estate_area.estate_area, 
                estate_objects.estate_object,
                functions.function,
                material_distance.distance,
                material_origins.origins,
                removability.removability
                FROM `materials` 
                JOIN estate_area ON materials.estate_area_id = estate_area.estate_area_id
                JOIN estate_objects ON materials.estate_object_id = estate_objects.estate_object_id
                JOIN material_distance ON materials.distance_id = material_distance.material_distance_id
                JOIN material_origins ON materials.origin_id = material_origins.origins_id
                JOIN removability ON materials.removability_id = removability.removability_id
                JOIN functions ON materials.function_id = functions.function_id"))
            {

                try
                {
                    if (GetDatabaseConnection().Connection.State == ConnectionState.Closed)
                    {
                        GetDatabaseConnection().Connection.Open();
                    }


                    using (MySqlDataReader reader = qry.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            materialList.Add(new Material
                                (
                                    Convert.ToInt32(reader["materials_id"]),
                                    reader["material"].ToString(),
                                    reader["function"].ToString(),
                                    reader["estate_area"].ToString(),
                                    reader["image"].ToString(),
                                    reader["lifespan"].ToString(),
                                    reader["estate_object"].ToString(),
                                    Convert.ToSingle(reader["removability"]),
                                    reader["origins"].ToString(),
                                    reader["distance"].ToString(),
                                    reader["units"].ToString(),
                                    reader["embodied_energy"].ToString(),
                                    Convert.ToSingle(reader["embodied_co2"].ToString())




                                )
                            );
                        }
                    }
                    GetDatabaseConnection().Connection.Close();
                }
                catch (Exception e)
                {
                    SetErrorMsg(e.Message.ToString());
                }

            }
            MaterialList = materialList;
        }
        public void SetMaterialItem(string _qry)
        {
            try
            {
                if (GetDatabaseConnection().Connection.State == ConnectionState.Closed)
                {
                    GetDatabaseConnection().Connection.Open();
                }
                using (MySqlCommand command = GetDatabaseConnection().PrepareSql(_qry))
                {
                    command.ExecuteNonQuery();
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            GetDatabaseConnection().Connection.Close();
        }

        public void SetRegisterProfile(string _qry2)
        {
             try
             {
                if (GetDatabaseConnection().Connection.State == ConnectionState.Closed)
                {
                    GetDatabaseConnection().Connection.Open();
                }
                using (MySqlCommand command = GetDatabaseConnection().PrepareSql(_qry2))
                {
                    command.ExecuteNonQuery();
                }

             }

             catch (MySqlException ex)
             {
                Console.WriteLine(ex.Message);
             }
            GetDatabaseConnection().Connection.Close();
        }

        public bool DeleteMaterial(int materialId)
        {
            string deleteQuery = $"DELETE FROM `materials` WHERE material_id = {materialId}";
            using (MySqlCommand qry = GetDatabaseConnection().PrepareSql(deleteQuery))
            {
                try
                {
                    ExecNonQry(qry);
                    return true;
                }
                catch (MySqlException e)
                {
                    SetErrorMsg(e.Message);
                    return false;
                }
            }
        }
    }
}
