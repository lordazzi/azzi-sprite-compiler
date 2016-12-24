using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Azzi_Sprite_Compiler
{
    public partial class configuracoes : Form
    {
        public configuracoes()
        {
            InitializeComponent();
        }

        private void configuracoes_Load(object sender, EventArgs e)
        {
            Program.configuracoes_active = true;
            string[] pieces;
            string response = RememberMe.read();
            if (Program.login != "" && Program.password != "") {
                loginsprite.Text = Program.login;
                loginsenha1.Text = Program.password;
                loginsenha2.Text = Program.password;
                security.Checked = Program.security;
                if (response != "||0")
                {
                    remeberme.Checked = true;
                }
            }

            else if (response != "||0") {
                pieces = response.Split(new string[] { "|" }, StringSplitOptions.None);
                remeberme.Checked = true;
                if (pieces.Length > 1)
                {
                    loginsprite.Text = pieces[0];
                }

                if (pieces.Length > 2)
                {
                    loginsenha1.Text = pieces[1];
                    loginsenha2.Text = pieces[1];
                }

                if (pieces.Length == 3)
                {
                    security.Checked = (pieces[2] == "1");
                }
            }
            
        }

        private void configuracoes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.configuracoes_active = false;
        }

        private void salvar_Click(object sender, EventArgs e)
        {
            if (loginsenha1.Text != loginsenha2.Text)
            {
                MessageBox.Show("Password Field and Repeat Password Field must be equal", "Passwords do not match!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!(loginsenha1.Text.Length > 3))
            {
                MessageBox.Show("The password must be at least 4 characters", "4 chars at least!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                Program.login = loginsprite.Text;
                Program.password = loginsenha1.Text;
                Program.security = security.Checked;

                if (remeberme.Checked == true)
                {
                    if (RememberMe.save(loginsprite.Text, loginsenha1.Text, security.Checked))
                    {
                        this.Close();
                    }
                }

                else
                {
                    RememberMe.remove();
                    this.Close();
                }
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginsprite_TextChanged(object sender, EventArgs e)
        {
            string rebuild = "";
            for (int i = 0; i < loginsprite.Text.Length; i++)
            {
                if (loginsprite.Text[i] == '0' || loginsprite.Text[i] == '1' || loginsprite.Text[i] == '2' || loginsprite.Text[i] == '3' || loginsprite.Text[i] == '4' || loginsprite.Text[i] == '5' || loginsprite.Text[i] == '6' || loginsprite.Text[i] == '7' || loginsprite.Text[i] == '8' || loginsprite.Text[i] == '9')
                {
                    rebuild += loginsprite.Text[i].ToString();
                }
            }

            if (rebuild != "")
            {
                loginsprite.Text = int.Parse(rebuild).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm a = new LoginForm();
            a.Show();
        }
    }

    public class RememberMe
    {
        public static string read()
        {
            if (File.Exists("rememberme.log"))
            {
                TextReader reader = File.OpenText("rememberme.log");
                string texto = "", lendo = "";
                while ((lendo = reader.ReadLine()) != null)
                {
                    texto += lendo;
                }
                reader.Close();
                return texto;
            }

            else
            {
                return "||0";
            }
        }

        public static bool save(string sprite, string senha, bool extremeSecurity)
        {
            if (senha.IndexOf('|') == -1)
            {
                byte seguranca = 0;
                if (extremeSecurity == true)
                {
                    seguranca = 1;
                }

                if (File.Exists("rememberme.log"))
                {
                    File.Delete("rememberme.log");
                }
                StreamWriter swriter = new StreamWriter(@"rememberme.log");
                swriter.WriteLine(sprite + "|" + senha + "|" + seguranca.ToString());
                swriter.Flush();
                swriter.Close();
                return true;
            }

            else
            {
                MessageBox.Show("O caracteres '|' é proibido na senha.", "Impossível Salvar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

        }

        public static void remove()
        {
            if (File.Exists("rememberme.log"))
            {
                File.Delete("rememberme.log");
            }
        }
    }
}
