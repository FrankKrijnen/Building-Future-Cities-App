using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BuildingFutureCitiesAPI.Models;
using MySql.Data.MySqlClient;

namespace BuildingFutureCitiesAPI.DataModels
{
    public class LinkTableDataModel : DataModel
    {
        //returns 0, if data already exists in linktable
        public int GetLinkTableId(string qry, string idColumnName)
        {
            int Id = new Int32();

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
                            Id = Convert.ToInt32(reader[idColumnName]);
                        }
                    }
                    GetDatabaseConnection().Connection.Close();
                }
                catch (Exception e)
                {
                    SetErrorMsg(e.Message.ToString());
                }

            }

            return Id;
        }

      
        
    }

}
