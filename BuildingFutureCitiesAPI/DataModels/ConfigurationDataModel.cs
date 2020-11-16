using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BuildingFutureCitiesAPI.Models;
using MySql.Data.MySqlClient;

namespace BuildingFutureCitiesAPI.DataModels
{
    public class ConfigurationDataModel : DataModel
    {
        public void SetConfiguration(string qry)
        {
            try
            {
                if (GetDatabaseConnection().Connection.State == ConnectionState.Closed)
                {
                    GetDatabaseConnection().Connection.Open();
                }
                using (MySqlCommand command = GetDatabaseConnection().PrepareSql(qry))
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

        public int GetConfigurationId(string qry)
        {
            int configurationId = new Int32();

            using (MySqlCommand preparedQry = GetDatabaseConnection().PrepareSql(qry))
            {

                try
                {
                    if (GetDatabaseConnection().Connection.State == ConnectionState.Closed)
                    {
                        GetDatabaseConnection().Connection.Open();
                    }

                    using (MySqlDataReader reader = preparedQry.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            configurationId = Convert.ToInt32(reader["id"]);
                        }
                    }
                    GetDatabaseConnection().Connection.Close();
                }
                catch (Exception e)
                {
                    SetErrorMsg(e.Message);
                }

            }

            return configurationId;
        }


        public List<Configuration> GetProfileConfiguration(string qry)
        {
            List<Configuration> configurationList = new List<Configuration>();

            using (MySqlCommand preparedQry = GetDatabaseConnection().PrepareSql(qry))
            {

                try
                {
                    if (GetDatabaseConnection().Connection.State == ConnectionState.Closed)
                    {
                        GetDatabaseConnection().Connection.Open();
                    }

                    using (MySqlDataReader reader = preparedQry.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            configurationList.Add(new Configuration(
                                reader["room"].ToString()
                                , reader["description"].ToString()
                                , null
                                ));
                        }
                    }
                    GetDatabaseConnection().Connection.Close();
                }
                catch (Exception e)
                {
                    SetErrorMsg(e.Message.ToString());
                }

            }

            return configurationList;
        }

        public List<int> GetmaterialIds(string qry)
        {
            List<int> _ids = new List<int>();
            using (MySqlCommand preparedQry = GetDatabaseConnection().PrepareSql(qry))
            {
                try
                {
                    if (GetDatabaseConnection().Connection.State == ConnectionState.Closed)
                    {
                        GetDatabaseConnection().Connection.Open();
                    }
                    using (MySqlDataReader reader = preparedQry.ExecuteReader())
                    {
                        Console.WriteLine(reader);
                        while (reader.Read())
                        {
                            _ids.Add((int)reader["material_id"]);
                        }
                    }
                    GetDatabaseConnection().Connection.Close();
                }
                catch (Exception e)
                {
                    SetErrorMsg(e.Message.ToString());
                }

            }
            return _ids;
        }
    }
}

