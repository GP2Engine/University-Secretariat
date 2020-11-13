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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonRegister.FlatAppearance.BorderSize = 0;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var uname = textBoxUsername.Text;
            var pass1 = textBoxPassword.Text;
            var pass2 = textBoxVerifyPass.Text;

            if (uname.Equals("") || pass1.Equals("") || pass2.Equals(""))
            {
                // empty form fields
                MessageBox.Show("Some fields are missing!", "User Registration");
            } else
            {
                // check passwords
                if (pass1.Equals(pass2))
                {
                    // create new user
                    var helper = new DBHelper();

                    var userRole = "S";
                    if (checkBox1.Checked)
                    {
                        userRole = "T";
                    }
                    
                    var command = new MySqlCommand("INSERT INTO `users` (`username`, `pass`, `role`) VALUES (@uname, @pass, @role) ;", helper.getConnection);
                    command.Parameters.Add("@uname", MySqlDbType.VarChar).Value = uname;
                    command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass1;
                    command.Parameters.Add("@role", MySqlDbType.VarChar).Value = userRole;

                    helper.openConnection();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        helper.closeConnection();
                        MessageBox.Show("Registered successfully!", "User Registration");
                        var loginForm = new LoginForm();
                        loginForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        helper.closeConnection();
                        MessageBox.Show("An error has occurred please try again!", "User Registration");
                    }
                } else
                {
                    // password not equal
                    MessageBox.Show("Passwords do not match!", "User Registration");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            pictureBoxRegister.Image = Image.FromFile("../../resources/register.png");
        }
    }
}
