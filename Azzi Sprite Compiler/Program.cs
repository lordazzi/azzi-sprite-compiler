using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Security;
using System.Text;
using System.Security.Cryptography;
using System.ComponentModel;

namespace Azzi_Sprite_Compiler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static bool configuracoes_active = false;
        public static string login = "";
        public static string password = "";
        public static bool security = false;

        public static string triedLogin = "";
        public static string triedPassword = "";

        public static string isPasswordSprite(Bitmap Sprite)
        {
            Bitmap cripto = new Bitmap(MasterForm.criptografia.Image);
            bool isvalid = true;
            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (Sprite.GetPixel(x, y) != cripto.GetPixel(x, y))
                    {
                        isvalid = false;
                        break;
                    }
                    y++;
                }

                if (isvalid == false)
                {
                    break;
                }
            }

            if (isvalid == true)
            {
                string retorno = "";
                byte[] bytes = new byte[32];

                short i = 0, color = 0;
                for (short j = 0; j < 32; j++)
                {
                    if (color == 0)
                    {
                        color = 1;
                        bytes[j] = Sprite.GetPixel(i, 21).R;
                    }

                    else if (color == 1)
                    {
                        color = 2;
                        bytes[j] = Sprite.GetPixel(i, 21).G;
                    }

                    else if (color == 2)
                    {
                        color = 0;
                        bytes[j] = Sprite.GetPixel(i, 21).B;
                        i++;
                    }
                }

                retorno = new string(Encoding.ASCII.GetString(bytes).ToCharArray());
                return retorno;
            }
            else
            {
                return "";
            }
        }

        public static Bitmap createPasswordSprite(string password)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            byte[] bytes;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(password);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            password = BitConverter.ToString(encodedBytes);

            //Criando a imagem da criptografia
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MasterForm));
            Bitmap cripto = ((Bitmap)(resources.GetObject("criptografia.Image")));

            ASCIIEncoding encoding = new ASCIIEncoding();
            bytes = encoding.GetBytes(password);

            int i = 0;
            while (i < 32)
            {
                cripto.SetPixel(0, 21, Color.FromArgb(bytes[i], bytes[i + 1], bytes[i + 2]));
                i += 3;
            }
            return cripto;
        }

        public static string toMd5(string convertme)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(password);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MasterForm());
        }
    }
}
