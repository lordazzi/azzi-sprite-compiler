using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Azzi_Sprite_Compiler
{
    public partial class LoginForm : Form
    {
        int tries = 0;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string[] pieces;
            string response = RememberMe.read();
            if (Program.login != "" && Program.password != "")
            {
                loginid.Text = Program.login;
                loginsenha.Text = Program.password;
            }

            else if (response != "||0")
            {
                pieces = response.Split(new string[] { "|" }, StringSplitOptions.None);
                if (pieces.Length == 3)
                {
                    loginid.Text = pieces[0];
                    loginsenha.Text = pieces[1];
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (loginid.Text == MasterForm.gettedPassword && loginsenha.Text == MasterForm.gettedPassword)
            {
                MasterForm.canPass = true;
                this.Close();
            }

            else if (tries == 5)
            {
                MessageBox.Show("You has not imagined that you could try all possible passwords, right? ;D", "Ops...", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Application.Exit();
            }

            else
            {
                tries++;
            }
        }
    }
}
