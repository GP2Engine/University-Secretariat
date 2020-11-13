using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace University_Secretariat
{
    class Course
    {

        DBHelper db = new DBHelper();
        public bool insertCourse(string name, int hours, string description)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `courses` (`name`, `hours`, `description`) VALUES (@cname,@hours,@descr)", db.getConnection);
            command.Parameters.Add("@cname", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@hours", MySqlDbType.Int32).Value = hours;
            command.Parameters.Add("@descr", MySqlDbType.Text).Value = description;

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

        public DataTable getCourses(MySqlCommand command)
        {
            command.Connection = db.getConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        public bool updateCourses(int id, string name, int hours, string description)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `courses` SET `name`=@cname, `hours`=@hours, `description`=@descr WHERE `id`=@ID", db.getConnection);
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@cname", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@hours", MySqlDbType.VarChar).Value = hours;
            command.Parameters.Add("@descr", MySqlDbType.Text).Value = description;

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

        public bool deleteCourse(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `courses` WHERE `id`=@ID", db.getConnection);
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;

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
