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
    public partial class TeacherLoginForm : Form
    {
        public TeacherLoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            buttonCancel.FlatAppearance.BorderSize = 0; // no borders for cancel button
            buttonLogin.FlatAppearance.BorderSize = 0; // no borders for login button
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void TeacherLoginForm_Load(object sender, EventArgs e)
        {
            pictureBoxLogin.Image = Image.FromFile("../../resources/teacher.png");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var helper = new DBHelper();
            var table = new DataTable();
            var adapter = new MySqlDataAdapter();

            var uname = textBoxUsername.Text;
            var pass = textBoxPassword.Text;
            var command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @uname AND `pass` = @pass AND `role` = \"T\" ;", helper.getConnection);

            command.Parameters.Add("@uname", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Logged in successfully!");
                MainForm mform = new MainForm();
                mform.pictureBoxMain.Image = Image.FromFile("../../resources/teacher.png");
                mform.label1.Text = "You logged in as: " + "\nteacher " + "'" + uname + "'";
                mform.scoreToolStripMenuItem.Visible = false;
                mform.Show();
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

        }
    }
}
