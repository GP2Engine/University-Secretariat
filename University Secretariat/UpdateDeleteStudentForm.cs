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
    public partial class UpdateDeleteStudentForm : Form
    {
        public UpdateDeleteStudentForm()
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
            Student student = new Student();
            var result = student.deleteStudent(Int32.Parse(textboxID.Text));
            if (result)
            {
                MessageBox.Show("Student's deletion completed successfully!", "Student Deletion Success");
                this.Hide();
            } else
            {
                MessageBox.Show("Student's deletion has failed!", "Student Deletion Error");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dialog.FileName);
            }
        }

        bool verifyStudent()
        {
            if (textBoxFirstName.Text.Equals("") ||
                textBoxLastName.Text.Equals("") ||
                textBoxAddress.Text.Equals("") ||
                textBoxPhone.Text.Equals("") ||
                pictureBox1.Image == null)
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
            if (verifyStudent())
            {
                string gender = "Male";
                if (radioButtonFemale.Checked)
                {
                    gender = "Female";
                }

                if (radioButtonOther.Checked)
                {
                    gender = "Other";
                }

                var stream = new MemoryStream();
                pictureBox1.Image.Save(stream, pictureBox1.Image.RawFormat);

                Student student = new Student();
                var result = student.updateStudents(
                    Int32.Parse(textboxID.Text),
                    textBoxFirstName.Text,
                    textBoxLastName.Text,
                    dateTimePicker1.Value,
                    textBoxPhone.Text,
                    gender,
                    textBoxAddress.Text,
                    stream
                );

                if (result)
                {
                    MessageBox.Show("Student modification completed successfully!", "Student modification success");
                    this.Hide();
                } else {
                    MessageBox.Show("Student modification failed!", "Student modification failure");
                }

            } else
            {
                MessageBox.Show("Fields missing", "Student modification failure");
            }
        }
    }
}
