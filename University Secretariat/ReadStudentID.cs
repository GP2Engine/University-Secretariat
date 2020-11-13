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
    public partial class ReadStudentID : Form
    {
        public ReadStudentID()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonSubmit.FlatAppearance.BorderSize = 0;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            // show student marks
            StudentScore studentMarks = new StudentScore();
            studentMarks.studentID = Int32.Parse(textBoxStudentID.Text);
            studentMarks.Show(this);
        }
    }
}
