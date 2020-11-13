using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace University_Secretariat
{
    class Score
    {
        DBHelper db = new DBHelper();
        public bool insertScore(int studentID, string course, int mark)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `scores` (`studentID`, `course`, `mark`) VALUES (@stID,@course,@mark)", db.getConnection);
            command.Parameters.Add("@stID", MySqlDbType.Int32).Value = studentID;
            command.Parameters.Add("@mark", MySqlDbType.Int32).Value = mark;
            command.Parameters.Add("@course", MySqlDbType.Text).Value = course;

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

        public DataTable getScores(MySqlCommand command)
        {
            command.Connection = db.getConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        public bool updateScores(int id, int studentID, string course, int mark)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `scores` SET `studentID`=@stID, `course`=@course, `mark`=@mark WHERE `id`=@ID", db.getConnection);
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@stID", MySqlDbType.Int32).Value = studentID;
            command.Parameters.Add("@course", MySqlDbType.VarChar).Value = course;
            command.Parameters.Add("@mark", MySqlDbType.Int32).Value = mark;

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

        public bool deleteScore(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `scores` WHERE `id`=@ID", db.getConnection);
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
