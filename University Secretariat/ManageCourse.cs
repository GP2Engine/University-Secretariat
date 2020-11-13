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
    public partial class ManageCourse : Form
    {
        public ManageCourse()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            buttonSearch.FlatAppearance.BorderSize = 0;
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonRefresh.FlatAppearance.BorderSize = 0;
            dataGridView1.BorderStyle = BorderStyle.None;
        }

        Course course = new Course();
        private void ManageCourse_Load(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `courses`");
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
            UpdateDeleteCourse updelCourse = new UpdateDeleteCourse();
            updelCourse.textboxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updelCourse.textBoxCourseName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            updelCourse.numericUpDown1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            updelCourse.textBoxDescr.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            // display form
            updelCourse.Show();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `courses`");
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
            int courseID;
            if (textboxID.Text.Equals("") || !IsPositive(textboxID.Text)) {
                MessageBox.Show("Invalid course id!", "Course Search Failure");
            } else {
                courseID = Int32.Parse(textboxID.Text);
                MySqlCommand command = new MySqlCommand("SELECT * FROM `courses` WHERE `id` = " + courseID);
                dataGridView1.ReadOnly = true;
                dataGridView1.RowTemplate.Height = 80;
                dataGridView1.DataSource = course.getCourses(command);
                dataGridView1.AllowUserToAddRows = false;
            }
        }
    }
}
