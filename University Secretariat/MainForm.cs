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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            menuStrip1.BackColor = Color.MidnightBlue;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudF = new AddStudentForm();
            addStudF.Show(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
          
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sTUDENTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void studentsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentsListForm stdList = new StudentsListForm();
            stdList.Show(this);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourseForm addCourse = new AddCourseForm();
            addCourse.Show(this);
        }

        private void manageCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCourse courseList = new ManageCourse();
            courseList.Show(this);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScoreForm addScore = new AddScoreForm();
            addScore.Show(this);
        }

        private void manageScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageScore scoreList = new ManageScore();
            scoreList.Show(this);
        }

        private void scoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadStudentID stIDForm = new ReadStudentID();
            stIDForm.Show(this);
        }

        private void editAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditAccount edit = new EditAccount();
            edit.Show(this);
        }
    }
}
