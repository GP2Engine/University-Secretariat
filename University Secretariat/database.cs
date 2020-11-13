using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace University_Secretariat
{
    class DBHelper
    {
        private MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=12341234A;database=secrdb");

        public MySqlConnection getConnection
        {
            get
            {
                return con;
            }
        }

        public void openConnection()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void closeConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
