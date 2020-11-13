using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace University_Secretariat
{
    public partial class ManageScore : Form
    {
        public ManageScore()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            buttonSearch.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonRefresh.FlatAppearance.BorderSize = 0;
            dataGridView1.BorderStyle = BorderStyle.None;
        }

        Course course = new Course();
        private void ManageScore_Load(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `scores`");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = course.getCourses(command);
            dataGridView1.AllowUserToAddRows = false;

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["MainForm"].Focus();
            this.Hide();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            UpdateDeleteScore updelScore = new UpdateDeleteScore();
            updelScore.textboxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString(); // id
            updelScore.textBoxStudent.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString(); // student id 
            updelScore.textBoxCourseName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); // course
            updelScore.numericUpDown1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString(); // mark

            // display form
            updelScore.Show();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `scores`");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = course.getCourses(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        public bool IsPositive(string s)
        {
            float output;
            var result = float.TryParse(s, out output);
            return result && output > 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int scoreID;
            if (textboxID.Text.Equals("") || !IsPositive(textboxID.Text)) {
                MessageBox.Show("Invalid score id!", "Score Search Failure");
            } else {
                scoreID = Int32.Parse(textboxID.Text);
                MySqlCommand command = new MySqlCommand("SELECT * FROM `scores` WHERE `id` = " + scoreID);
                dataGridView1.ReadOnly = true;
                dataGridView1.RowTemplate.Height = 80;
                dataGridView1.DataSource = course.getCourses(command);
                dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int studentID;
            if (textBoxStudent.Text.Equals("") || !IsPositive(textBoxStudent.Text))
            {
                MessageBox.Show("Invalid student id!", "Score Search Failure");
            }
            else
            {
                studentID = Int32.Parse(textBoxStudent.Text);
                MySqlCommand command = new MySqlCommand("SELECT * FROM `scores` WHERE `studentID` = " + studentID);
                dataGridView1.ReadOnly = true;
                dataGridView1.RowTemplate.Height = 80;
                dataGridView1.DataSource = course.getCourses(command);
                dataGridView1.AllowUserToAddRows = false;
            }
        }
    }
}
