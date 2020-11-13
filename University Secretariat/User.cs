using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace University_Secretariat
{
    class User
    {
        DBHelper db = new DBHelper();
        
        public bool updatePass(string uname, string pass, string newPass)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `pass`=@newpass WHERE `username`=@uname AND `pass` = @pass", db.getConnection);
            command.Parameters.Add("@uname", MySqlDbType.VarChar).Value = uname;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;
            command.Parameters.Add("@newpass", MySqlDbType.VarChar).Value = newPass;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public bool updateUname(string uname, string newUname, string pass)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `username`=@newuname WHERE `username`=@uname AND `pass` = @pass", db.getConnection);
            command.Parameters.Add("@uname", MySqlDbType.VarChar).Value = uname;
            command.Parameters.Add("@newuname", MySqlDbType.VarChar).Value = newUname;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
    }
}
