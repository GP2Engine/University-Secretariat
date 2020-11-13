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

namespace University_Secretariat
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            buttonRegister.FlatAppearance.BorderSize = 0; // no borders for register button
            buttonCancel.FlatAppearance.BorderSize = 0; // no borders for cancel button
            buttonLogin.FlatAppearance.BorderSize = 0; // no borders for login button
            button1.FlatAppearance.BorderSize = 0;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            pictureBoxLogin.Image = Image.FromFile("../../resources/student.png");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var helper = new DBHelper();
            var table = new DataTable();
            var adapter = new MySqlDataAdapter();

            var uname = textBoxUsername.Text;
            var pass = textBoxPassword.Text;
            var command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @uname AND `pass` = @pass AND `role` = \"S\" ;", helper.getConnection);

            command.Parameters.Add("@uname", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Logged in successfully!");
                MainForm mform = new MainForm();
                mform.pictureBoxMain.Image = Image.FromFile("../../resources/student.png");
                mform.label1.Text = "You logged in as: " + "\nstudent " + "'" + uname + "'";
                mform.Show();
                // hide student menu
                mform.studentToolStripMenuItem.Visible = false;
                // hide courses menu
                mform.courseToolStripMenuItem.Visible = false;
                // hide scores menu
                mform.scoresToolStripMenuItem1.Visible = false;
                this.Hide();
            } else
            {
                MessageBox.Show("Username or password are incorrect!");
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var teacherForm = new TeacherLoginForm();
            teacherForm.Show();
            this.Hide();
        }
    }
}
