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
    public partial class StudentsListForm : Form
    {
        public StudentsListForm()
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

        Student student = new Student();
        private void StudentsListForm_Load(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `student`");
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = student.getStudents(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["MainForm"].Focus();
            this.Hide();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm updelStd = new UpdateDeleteStudentForm();
            updelStd.textboxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updelStd.textBoxFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            updelStd.textBoxLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            updelStd.dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;

            // show student's gender
            var gender = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            if (gender.Equals("Male"))
            {
                updelStd.radioButtonMale.Checked = true;
            } else if (gender.Equals("Female"))
            {
                updelStd.radioButtonFemale.Checked = true;
            } else
            {
                updelStd.radioButtonOther.Checked = true;
            }

            updelStd.textBoxPhone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            updelStd.textBoxAddress.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            // show student's photograph
            var stream = new MemoryStream((byte []) dataGridView1.CurrentRow.Cells[7].Value);
            updelStd.pictureBox1.Image = Image.FromStream(stream);

            // display form
            updelStd.Show();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `student`");
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = student.getStudents(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
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
            int userID;
            if (textboxID.Text.Equals("") || !IsPositive(textboxID.Text)) {
                MessageBox.Show("Invalid student id!", "Student Search Failure");
            } else {
                userID = Int32.Parse(textboxID.Text);
                MySqlCommand command = new MySqlCommand("SELECT * FROM `student` WHERE `id` = " + userID);
                dataGridView1.ReadOnly = true;
                DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                dataGridView1.RowTemplate.Height = 80;
                dataGridView1.DataSource = student.getStudents(command);
                picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridView1.AllowUserToAddRows = false;
            }
        }
    }
}
