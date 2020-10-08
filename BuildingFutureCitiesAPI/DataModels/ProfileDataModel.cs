using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BuildingFutureCitiesAPI.Models;
using MySql.Data.MySqlClient;

namespace BuildingFutureCitiesAPI.DataModels
{
    public class ProfileDataModel : DataModel
    {
        
        public Profile GetProfileData(string qry)
        {
            Profile profile = new Profile();

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
                            profile.FirstName = reader["firstname"].ToString();
                            profile.LastName = reader["lastname"].ToString();
                            profile.Email = reader["email"].ToString();
                        }
                    }
                    GetDatabaseConnection().Connection.Close();
                }
                catch (Exception e)
                {
                    SetErrorMsg(e.Message.ToString());
                }

            }

            return profile;
        }
    }

}
