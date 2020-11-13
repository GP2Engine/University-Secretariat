using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Secretariat
{
    public partial class AddCourseForm : Form
    {
        public AddCourseForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            butCancel.FlatAppearance.BorderSize = 0;
            butAdd.FlatAppearance.BorderSize = 0;
        }

        private void AddCourseForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.OpenForms["MainForm"].Focus();
            this.Hide();
        }

        bool verifyCourse()
        {
            if (textBoxCourseName.Text.Equals("") ||
                textBoxDescription.Text.Equals("") ||
                numericUpDown1.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var name = textBoxCourseName.Text;
            var hours = numericUpDown1.Text;
            var description = textBoxDescription.Text;

            var course = new Course();

            if (verifyCourse())
            {
                if (course.insertCourse(name, Int32.Parse(hours), description))
                {
                    MessageBox.Show("New course was added!", "Course insertion success");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Course could not be added!", "Course insertion failure");
                }
            }
            else
            {
                MessageBox.Show("Fields missing", "Course insertion failure");
            }
        }
    }
}
