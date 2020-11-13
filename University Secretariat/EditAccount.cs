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
    public partial class EditAccount : Form
    {
        public EditAccount()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            butCancel.FlatAppearance.BorderSize = 0;
            butEditPass.FlatAppearance.BorderSize = 0;
            butEditUname.FlatAppearance.BorderSize = 0;
        }

        bool verifyNewPass()
        {
            if (textBoxOldPass.Text.Equals("") ||
                textBoxNewPass.Text.Equals("") ||
                textBoxUsername.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        bool verifyNewUname()
        {
            if (textBoxPass.Text.Equals("") ||
                textBoxOldUsername.Text.Equals("") ||
                textBoxNewUsename.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            Application.OpenForms["MainForm"].Focus();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void butSubmit_Click(object sender, EventArgs e)
        {
            // new password
            User user = new User();

            if (verifyNewPass())
            {
                var uname = textBoxUsername.Text;
                var pass = textBoxOldPass.Text;
                var newPass = textBoxNewPass.Text;

                if (!pass.Equals(newPass)) {
                    if (user.updatePass(uname, pass, newPass))
                    {
                        MessageBox.Show("Your password was changed!", "Password change success");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Your password could not be changed!", "Password change failure");
                    }
                } else
                {
                    MessageBox.Show("Your passwords are equal!", "Password change failure");
                }
            }
            else
            {
                MessageBox.Show("Fields missing", "Password change failure");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User();

            // new username
            if (verifyNewUname())
            {
                var oldUname = textBoxOldUsername.Text;
                var newUname = textBoxNewUsename.Text;
                var pass = textBoxPass.Text;

                if (!oldUname.Equals(newUname))
                {
                    if (user.updateUname(oldUname, newUname, pass))
                    {
                        MessageBox.Show("Your username was changed!", "Username change success");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Your username could not be changed!", "Username change failure");
                    }
                } else {
                    MessageBox.Show("Your username are equal!", "Username change failure");
                }
            } else
            {
                MessageBox.Show("Fields missing", "Username change failure");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
