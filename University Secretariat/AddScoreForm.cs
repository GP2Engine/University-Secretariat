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
    public partial class AddScoreForm : Form
    {
        public AddScoreForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonAdd.FlatAppearance.BorderSize = 0;
        }

        private void AddScoreForm_Load(object sender, EventArgs e)
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
                textBoxStudent.Text.Equals("") ||
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
            var course = textBoxCourseName.Text;
            var mark = numericUpDown1.Text;
            var student = textBoxStudent.Text;

            var score = new Score();

            if (verifyCourse())
            {
                if (score.insertScore(Int32.Parse(student), course, Int32.Parse(mark)))
                {
                    MessageBox.Show("New score was added!", "Score insertion success");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Score could not be added!", "Score insertion failure");
                }
            }
            else
            {
                MessageBox.Show("Fields missing", "Score insertion failure");
            }
        }
    }
}
