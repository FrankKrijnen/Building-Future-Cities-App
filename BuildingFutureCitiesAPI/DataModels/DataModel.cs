using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingFutureCitiesAPI.Builders;
using MySql.Data.MySqlClient;

namespace BuildingFutureCitiesAPI.DataModels
{
    // DataModel base class
    // Uses SQL
    // initializes database class
    // Parent class for all Datamodels
    // Reader executes are defined in the child classes 
    public class DataModel
    {
        private DatabaseConnection DatabaseConnection = new DatabaseConnection();
        private string ErrorMsg;

        public void ExecNonQry(MySqlCommand qry)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                qry.ExecuteNonQuery();
                DatabaseConnection.Connection.Close();
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
            }
        }

        public string GetErrorMsg()
        {
            return ErrorMsg;
        }

        public void SetErrorMsg(string errorMsg)
        {
            ErrorMsg = errorMsg;
        }

        public DatabaseConnection GetDatabaseConnection()
        {
            return DatabaseConnection;
        }

    }
}
