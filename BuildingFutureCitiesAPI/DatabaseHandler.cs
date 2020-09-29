using MySql.Data.MySqlClient;

namespace BuildingFutureCitiesAPI
{

    /// <summary> Initializes a new instance of the <see cref="DatabaseConnection"/> class and connects to a database with <see cref="MySqlConnection"/>.
    /// <para>Connect to a database with credentials and execute SQL-queries.</para>
    /// </summary>

    public class DatabaseConnection
    {
        public MySqlConnection Connection { get; private set; }
        private string Server = "127.0.0.1";
        private string Database = "bouwapp";
        private string UID = "root";
        private string Password = "";

        public DatabaseConnection()
        {
            Initialize();
        }

        private void Initialize()
        {

            string connectionString;
            connectionString = "SERVER=" + Server + ";" + "DATABASE=" + Database + ";" + "UID=" + UID + ";" + "PASSWORD=" + Password + ";";
            Connection = new MySqlConnection(connectionString);


        }

        /// <summary> Initializes a new instance of the <see cref="MySqlCommand"/> class and prepares sql for query.
        /// <para>The <paramref name="sql"/> parameter takes a <see cref="string"/>. </para>
        /// <returns>Returns <see cref="MySqlCommand"/>.</returns>
        /// </summary>
        public MySqlCommand PrepareSql(string sql)
        {
            using (MySqlCommand cmd = new MySqlCommand(sql, Connection))
            {
                return cmd;
            }
        }
    }
}

