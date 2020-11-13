using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Secretariat
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            buttonBrowse.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonSubmit.FlatAppearance.BorderSize = 0;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
            } else
            {
                return true;
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            var fname = textBoxFirstName.Text;
            var lname = textBoxLastName.Text;
            var date = dateTimePicker1.Value;
            var phoneNo = textBoxPhone.Text;
            var address = textBoxAddress.Text;

            var gender = "Male";
            if (radioButtonFemale.Checked)
            {
                gender = "Female";
            }
            if (radioButtonOther.Checked)
            {
                gender = "Other";
            }

            var student = new Student();
            var stream = new MemoryStream();

            int usersYear = dateTimePicker1.Value.Year;
            int thisYear = DateTime.Now.Year;
            if (thisYear - usersYear < 18 || thisYear - usersYear > 65)
            {
                MessageBox.Show("The student's age must be between 18 and 65 years", "Invalid Age");
            }
            else if (verifyStudent())
            {
                pictureBox1.Image.Save(stream, pictureBox1.Image.RawFormat);
                if(student.insertStudent(fname, lname, date, phoneNo, gender, address, stream))
                {
                    MessageBox.Show("New student was added!", "Student insertion success");
                    this.Close();
                } else
                {
                    MessageBox.Show("Student could not be added!", "Student insertion failure");
                }
            }
            else
            {
                MessageBox.Show("Fields missing", "Student insertion failure");
            }
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
    }
}
