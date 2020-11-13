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
    public partial class UpdateDeleteScore : Form
    {
        public UpdateDeleteScore()
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
            Score score = new Score();
            var result = score.deleteScore(Int32.Parse(textboxID.Text));
            if (result)
            {
                MessageBox.Show("Score's deletion completed successfully!", "Score Deletion Success");
                this.Hide();
            } else
            {
                MessageBox.Show("Score's deletion has failed!", "Score Deletion Error");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            
        }

        bool verifyScore()
        {
            if (textboxID.Text.Equals("") ||
                textBoxCourseName.Text.Equals("") ||
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

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (verifyScore())
            {
                Score score = new Score();
                var result = score.updateScores(
                    Int32.Parse(textboxID.Text),
                    Int32.Parse(textBoxStudent.Text),
                    textBoxCourseName.Text,
                    Int32.Parse(numericUpDown1.Text)
                );

                if (result)
                {
                    MessageBox.Show("Score modification completed successfully!", "Score modification success");
                    this.Hide();
                } else {
                    MessageBox.Show("Score modification failed!", "Score modification failure");
                }

            } else
            {
                MessageBox.Show("Fields missing", "Score modification failure");
            }
        }
    }
}
