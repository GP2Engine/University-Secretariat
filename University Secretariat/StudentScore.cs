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
    public partial class StudentScore : Form
    {
        public int studentID;

        public StudentScore()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            buttonExit.FlatAppearance.BorderSize = 0;
            dataGridView1.BorderStyle = BorderStyle.None;
        }

        Course course = new Course();

        private void StudentScore_Load(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `scores` WHERE `studentID` = " + studentID);
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = course.getCourses(command);
            dataGridView1.AllowUserToAddRows = false;

            int[] columnData = (from DataGridViewRow row in dataGridView1.Rows
                                where row.Cells[2].FormattedValue.ToString() != string.Empty
                                select Convert.ToInt32(row.Cells[3].FormattedValue)).ToArray();
            labelAvg.Text += (" " + columnData.Where(score => score >= 5).Average());
            labelPassed.Text += (" " + columnData.Where(score => score >= 5).Count());
            labelFailed.Text += (" " + columnData.Where(score => score < 5).Count());
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["MainForm"].Focus();
            this.Hide();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {

        }

        public bool IsPositive(string s)
        {
            float output;
            var result = float.TryParse(s, out output);
            return result && output > 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
