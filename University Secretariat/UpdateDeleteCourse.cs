using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace University_Secretariat
{
    public partial class UpdateDeleteCourse : Form
    {
        public UpdateDeleteCourse()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonRemove.FlatAppearance.BorderSize = 0;
            buttonUpdate.FlatAppearance.BorderSize = 0;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            Course course = new Course();
            var result = course.deleteCourse(Int32.Parse(textboxID.Text));
            if (result)
            {
                MessageBox.Show("Course's deletion completed successfully!", "Course Deletion Success");
                this.Hide();
            } else
            {
                MessageBox.Show("Course's deletion has failed!", "Course Deletion Error");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            
        }

        bool verifyCourse()
        {
            if (textboxID.Text.Equals("") ||
                textBoxCourseName.Text.Equals("") ||
                textBoxDescr.Text.Equals("") ||
                numericUpDown1.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (verifyCourse())
            {
                Course course = new Course();
                var result = course.updateCourses(
                    Int32.Parse(textboxID.Text),
                    textBoxCourseName.Text,
                    Int32.Parse(numericUpDown1.Text),
                    textBoxDescr.Text
                );

                if (result)
                {
                    MessageBox.Show("Course modification completed successfully!", "Course modification success");
                    this.Hide();
                } else {
                    MessageBox.Show("Course modification failed!", "Course modification failure");
                }

            } else
            {
                MessageBox.Show("Fields missing", "Course modification failure");
            }
        }
    }
}
