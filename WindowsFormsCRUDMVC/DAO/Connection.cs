using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsCRUDMVC
{
    class Connection
    {
        private static Connection instance = null;
        public static Connection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Connection();
                }

                return instance;
            }
        }

        private MySqlConnection sqlConnection;
        public MySqlConnection SqlConnection { get => sqlConnection; }

        private Connection()
        {
            string server = "localhost";
            string user = "root";
            string password = "root";
            string database = "primer_parcial";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";";

            sqlConnection = new MySqlConnection(connectionString);
        }
    }
}
