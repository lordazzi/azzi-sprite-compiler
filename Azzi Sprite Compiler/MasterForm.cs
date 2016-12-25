using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Eu add
using System.Diagnostics;
using System.IO;

namespace Azzi_Sprite_Compiler
{
    public partial class MasterForm : Form
    {
        //toread
        public static bool alreadyOpen = false, canPass = false;
        public static string gettedSpriteNo = "";
        public static string gettedPassword = "";
        //tocompile
        string pass = "", spriteno = "";
        bool secur = false;
        UInt32 lastOffset;

        double firstSeg = 0, firstMin = 0, firstHour = 0, nowSeg = 0, nowMin = 0, nowHour = 0;
        string segTxt, minTxt;
        string extract_path, extract_path_file_name, compile_path;

        bool[] Decompiler = new bool[5], Compiler = new bool[5];
        byte[] signature = new byte[4], magentabyte = new byte[3];
        //Lê e exporta as sprites
        SprReader AzziSprites;
        int timerRunTimes = 1;

        //COMPILANDOR
        //Encontra o local das sprites
        FileInfo[] sprite_folder;
        //mostra qual sprite está sendo convertida para binário agora
        int currentSprite = 0;
        //QUantidade de sprites
        UInt16 spriteNumber16 = 0;
        UInt32 spriteNumber32 = 0;
        //deslocamento
        UInt32[] offsets;
        //nome do arquivo 
        string novonome;
        BinaryWriter writer;//variavel usada para escrever no arquivo

        /*
         * tmpImage - lugar onde a imagem fica quando esta sendo compilada em bytes
         * compiledimages - Tem só as imagens compiladas
         * fullcompile - Quando junta a compilação das imagens com os offsets
         */
        byte[] compiledimages, fullcompile = new byte[0], tmpImage;


        public MasterForm()
        {
            InitializeComponent();
        }

        private void Extract_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Tibia Sprites|*.spr";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] pieces;
                extract_path_file_name = ofd.FileName.ToString();
                pieces = extract_path_file_name.Split(new string[] { "\\" }, StringSplitOptions.None);
                for (int i = 0; i < pieces.Length - 1; i++)
                {
                    extract_path += pieces[i];
                    if (i != pieces.Length - 1) {
                        extract_path = extract_path + "\\";
                    }
                }

                if (extract_path != "" && extract_path_file_name != "")
                {
                    nowSeg = 0;
                    nowMin = 0;
                    nowHour = 0;

                    firstSeg = DateTime.Now.Second;
                    firstMin = DateTime.Now.Minute;
                    firstHour = DateTime.Now.Hour;

                    Timer.Enabled = true;

                    Registred.Text = "0";
                    Read.Text = "0";
                    Exported.Text = "0";
                    Compiled.Text = "0";
                    Decompiler[0] = true;
                }
            }
        }

        private void Compile_Click(object sender, EventArgs e)
        {
            //configurações de senha
            string[] pieces;
            string response = RememberMe.read();
            if (Program.login != "" && Program.password != "")
            {
                spriteno = Program.login;
                pass = Program.password;
                secur = Program.security;
            }

            else if (response != "||0")
            {
                pieces = response.Split(new string[] { "|" }, StringSplitOptions.None);
                if (pieces.Length > 1)
                {
                    spriteno = pieces[0];
                }

                if (pieces.Length > 2)
                {
                    pass = pieces[1];
                }

                if (pieces.Length == 3)
                {
                    secur = (pieces[2] == "1");
                }
            }

            //compilação
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            compile_path = fbd.SelectedPath.ToString();

            if (compile_path != "")
            {
                nowSeg = 0;
                nowMin = 0;
                nowHour = 0;

                firstSeg = DateTime.Now.Second;
                firstMin = DateTime.Now.Minute;
                firstHour = DateTime.Now.Hour;

                Timer.Enabled = true;

                Registred.Text = "0";
                Read.Text = "0";
                Exported.Text = "0";
                Compiled.Text = "0";
                Msg.ForeColor = Color.Goldenrod;
                Msg.Text = "Initializing... It is not frozen!";
                Compiler[0] = true;
            }
        }

        private void Donate_Click(object sender, EventArgs e)
        {
            Process.Start("javascript:alert('ops')");
        }

        private void About_Click(object sender, EventArgs e)
        {
            Sobre sobre = new Sobre();
            sobre.Show();
        }

        private void ShowMsg_Tick(object sender, EventArgs e)
        {
            #region Extração das imagens
            if (Decompiler[0] == true)
            {
                Msg.ForeColor = Color.Goldenrod;
                Msg.Text = "It is not frozen! Just reading Tibia.spr (:";
                Decompiler[0] = false;
                Decompiler[1] = true;
                Extract.Enabled = false;
                Compile.Enabled = false;
            }

            else if (Decompiler[1] == true)
            {
                string version = "";
                if (selectversion.SelectedIndex == 0)
                {
                    version = "7.2";
                }

                else if (selectversion.SelectedIndex == 1)
                {
                    version = "9.6";
                }

                AzziSprites = new SprReader(extract_path_file_name, Registred, Read, Exported, Compiled, Decompiler, version);
                if (AzziSprites.isRead == false)
                {
                    Msg.ForeColor = Color.Red;
                    Msg.Text = "Can't find Tibia.spr!";
                }

                Decompiler[1] = false;
                Decompiler[2] = true;
            }

            else if (Decompiler[2] == true)
            {
                Msg.ForeColor = Color.Goldenrod;
                Msg.Text = "Now it is exporting...";
                if (Directory.Exists(extract_path + "\\Sprites"))
                {
                    Msg.ForeColor = Color.Red;
                    Msg.Text = "'Sprites' folder already exists";
                    Decompiler[2] = false;
                    Extract.Enabled = true;
                    MessageBox.Show("Already have a folder called 'Sprites' \n Body... I can't work in these conditions, all right? \n Adjust that for me (:", "There is a problem! Duh...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    Directory.CreateDirectory(extract_path + "\\Sprites");
                    FileStream dat = new FileStream(extract_path + "\\Sprites\\signature.dat", FileMode.Create);
                    BinaryWriter writer = new BinaryWriter(dat);
                    writer.Write(AzziSprites.signature[0]);
                    writer.Write(AzziSprites.signature[1]);
                    writer.Write(AzziSprites.signature[2]);
                    writer.Write(AzziSprites.signature[3]);
                    writer.Flush();
                    writer.Close();
                    Decompiler[2] = false;
                    Decompiler[3] = true;
                }
            }

            else if (Decompiler[3] == true)
            {
                if (MasterForm.gettedPassword != "" && MasterForm.gettedSpriteNo != "" && canPass == false)
                {
                    if (alreadyOpen == false)
                    {
                        Msg.ForeColor = Color.Green;
                        Msg.Text = "Not so easy, this sprites are password protected! /o/";
                        LoginForm loginform = new LoginForm();
                        loginform.Show();
                        alreadyOpen = true;
                    }
                }

                else
                {
                    if (timerRunTimes < AzziSprites.numberOfSpritesRead)
                    {
                        try
                        {
                            for (int i = 0; i < 151; i++)
                            {
                                AzziSprites.SprItems[timerRunTimes].SprBmp.Save(extract_path + "\\Sprites\\s" + timerRunTimes.ToString() + ".bmp");
                                timerRunTimes++;
                                Read.Text = (int.Parse(Read.Text) - 1).ToString();
                                Exported.Text = (int.Parse(Exported.Text) + 1).ToString();
                            }
                        }
                        catch
                        {
                            Msg.ForeColor = Color.Red;
                            Msg.Text = "I'm not feeling well...";
                        }
                    }

                    else
                    {
                        Msg.ForeColor = Color.Green;
                        Msg.Text = "It is over ;D";
                        Decompiler[3] = false;
                        Extract.Enabled = true;
                        Compile.Enabled = true;
                        Timer.Enabled = false;
                        MessageBox.Show("It is over! ;D", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            #endregion
            #region Compactação das imagens
            if (Compiler[0] == true)
            {
                //Bloquenado os botões
                Extract.Enabled = false;
                Compile.Enabled = false;

                //Lendo a assinatura da versão
                BinaryReader signa = new BinaryReader(File.OpenRead(compile_path + "\\signature.dat"));
                signature[0] = signa.ReadByte();
                signature[1] = signa.ReadByte();
                signature[2] = signa.ReadByte();
                signature[3] = signa.ReadByte();

                //Descobrindo os arquivos da pasta
                sprite_folder = new DirectoryInfo(compile_path).GetFiles("*.bmp");
                //Quantidade de sprites para serem compiladas
                if (selectversion.SelectedIndex == 0) //versão 7.2 ~ 9.4
                {
                    spriteNumber16 = Change.Int32_to_UInt16(sprite_folder.Length);
                    spriteNumber16++;

                    offsets = new UInt32[spriteNumber16];
                    //O calculo do primeiro offset é a multiplicação da quantidade de offsets por 4
                    offsets[0] = (Change.UInt16_to_UInt32(spriteNumber16) - 1) * 4 + 6;

                    //Imprimindo o valor
                    Read.Text = (spriteNumber16 - 1).ToString();
                }

                else if (selectversion.SelectedIndex == 1) //versão 9.6
                {
                    spriteNumber32 = Change.Int32_to_UInt32(sprite_folder.Length);
                    spriteNumber32++;

                    offsets = new UInt32[spriteNumber32];
                    //O calculo do primeiro offset é a multiplicação da quantidade de offsets por 4
                    offsets[0] = spriteNumber32 * 4 + 6;

                    //Imprimindo o valor
                    Read.Text = (spriteNumber32 - 1).ToString();
                }
                

                //buscando um nome para o arquivo
                string nome = "Azzi";
                novonome = nome; int onemore = 1;
                while (File.Exists(compile_path + novonome + ".spr"))
                {
                    onemore++;
                    novonome = nome + " " + onemore.ToString();
                }
                novonome = novonome + ".spr";
                //criando o arquivo
                FileStream fs = new FileStream(compile_path + novonome, FileMode.Create);
                writer = new BinaryWriter(fs);

                //Mensagem
                Msg.ForeColor = Color.Goldenrod;
                Msg.Text = "Compiling sprites...";

                Compiler[0] = false;
                Compiler[1] = true;

            }

            else if (Compiler[1] == true)
            {
                UInt32 spriteNumber = 0;
                if (selectversion.SelectedIndex == 0) //versão 7.2 ~ 9.4
                {
                    spriteNumber = Change.UInt16_to_UInt32(spriteNumber16);
                }

                else if (selectversion.SelectedIndex == 1) //9.6
                {
                    spriteNumber = spriteNumber32;
                }
                for (int i = 0; i <= 37; i++)
                {

                    if (currentSprite < (spriteNumber - 1))
                    {
                        currentSprite++;
                        if (secur == true && currentSprite == 2)
                        {
                            tmpImage = new byte[5];
                        }

                        else if (int.Parse(spriteno) == currentSprite)
                        {

                            tmpImage = SprCompiler.CompileImg(Program.createPasswordSprite(pass));
                        }

                        else
                        {
                            tmpImage = SprCompiler.CompileImg(Image.FromFile(compile_path + "\\s" + currentSprite.ToString() + ".bmp"));
                        }

                        //Colocando o OFFSET de um arquivo de imagem para frente
                        if (offsets[currentSprite - 1] != 0) {
                            lastOffset = offsets[currentSprite - 1];
                        }

                        bool fogetaboutme = false;
                        if (currentSprite < spriteNumber)
                        {
                            if (tmpImage.Length == 3 && selectversion.SelectedIndex == 1 && currentSprite != 1) // se a imagem for vazia e a versão for 9.61
                            {
                                offsets[currentSprite] = 0;
                                fogetaboutme = true;
                            }
                            else
                            {
                                //Ele usa currentSprite, mas na verdade esta uma na frente, porque eu comecei com o index do offset em 1, o das sprites começa em 2
                                offsets[currentSprite] = lastOffset + Change.Int32_to_UInt32(tmpImage.Length) + 5; //+5 referente a cor transparente que ocupa 3 bytes e o tamanho da sprite 2 bytes
                            }
                        }

                        ushort tamanho = ushort.Parse(tmpImage.Length.ToString());

                        magentabyte[0] = 255;
                        magentabyte[1] = 0;
                        magentabyte[2] = 255;


                        //tamanho da imagem
                        tmpImage = SprCompiler.groupByteArray(Change.UInt16_to_Byte(tamanho), tmpImage);
                        //pixel invisivel
                        tmpImage = SprCompiler.groupByteArray(magentabyte, tmpImage);

                        if (fogetaboutme == true)
                        {
                            //escrevendo a compilação nele
                            writer.Write(tmpImage);
                        }

                        //compiledimages = SprCompiler.groupByteArray(compiledimages, tmpImage);
                        Compiled.Text = (int.Parse(Compiled.Text) + 1).ToString();

                        Random rand = new Random();
                        if (rand.Next(0, 50000) == i)
                        {
                            Msg.ForeColor = Color.Goldenrod;
                            Msg.Text = "Compiling sprites with perfect love.";
                        }

                    }

                    else
                    {
                        Compiler[1] = false;
                        Compiler[2] = true;
                        Msg.ForeColor = Color.Goldenrod;
                        Msg.Text = "Now it is adjusting the file.";
                    }
                }

            }

            else if (Compiler[2] == true)
            {
                //adicionando a signature
                fullcompile = SprCompiler.groupByteArray(fullcompile, signature);

                //adicionando os 2 bytes do sprite number
                UInt32 spriteNumber = 0;
                if (selectversion.SelectedIndex == 0) //versão 7.2 ~ 9.4
                {
                    spriteNumber = Change.UInt16_to_UInt32(spriteNumber16);
                    fullcompile = SprCompiler.groupByteArray(fullcompile, Change.UInt16_to_Byte(Change.UInt16_add(spriteNumber16, (0 - 1))));
                }
                else if (selectversion.SelectedIndex == 1) //9.6
                {
                    spriteNumber = spriteNumber32;
                    fullcompile = SprCompiler.groupByteArray(fullcompile, Change.UInt32_to_Byte(Change.UInt32_add(spriteNumber32, (0 - 1))));
                }
                //adicionando os offsets

                for (int i = 0; i < (spriteNumber - 1); i++)
                {
                    //compilando os offsets
                    fullcompile = SprCompiler.groupByteArray(fullcompile, Change.UInt32_to_Byte(offsets[i]));
                }

                //Lendo as imagens guardadas no arquivo
                writer.Flush();
                writer.Close();
                BinaryReader readspr = new BinaryReader(File.OpenRead(compile_path + novonome)); //abrindo o arquivo
                readspr.BaseStream.Position = 0;
                compiledimages = readspr.ReadBytes(int.Parse(readspr.BaseStream.Length.ToString()));

                readspr.Close();
                File.Delete(compile_path + novonome);

                FileStream fs = new FileStream(compile_path + novonome, FileMode.Create);
                writer = new BinaryWriter(fs);

                //juntando o grupo de imagens compiladas
                fullcompile = SprCompiler.groupByteArray(fullcompile, compiledimages);

                //CONCLUSÃO
                //escrevendo a compilação nele
                for (int i = 0; i < fullcompile.Length; i++)
                {
                    writer.Write(fullcompile[i]);
                }
                writer.Flush();

                //Fechando tudo
                writer.Close();
                Compiler[2] = false;

                //Desbloqeuando os botões
                Extract.Enabled = true;
                Compile.Enabled = true;
                Timer.Enabled = false;

                Msg.ForeColor = Color.Green;
                Msg.Text = "It is over ;D";
            }
            #endregion
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            #region mostrando os segundos
            nowSeg = DateTime.Now.Second;
            nowMin = DateTime.Now.Minute;
            nowHour = DateTime.Now.Hour;

            nowSeg = firstSeg - nowSeg;
            nowMin = firstMin - nowMin;
            nowHour = firstHour - nowHour;

            nowSeg = nowSeg + (nowMin * 60) + (nowHour * 60 * 60);

            nowMin = nowSeg / 60;
            nowMin = Math.Ceiling(nowMin) * (0 - 1);
            nowSeg = nowSeg % 60 * (0 - 1);


            if (nowSeg < 10)
            {
                segTxt = "0" + nowSeg.ToString();
            }
            else
            {
                segTxt = nowSeg.ToString();
            }

            if (nowMin < 10)
            {
                minTxt = "0" + nowMin.ToString();
            }
            else
            {
                minTxt = nowMin.ToString();
            }

            labelTempo.Text = minTxt + ":" + segTxt;
            #endregion
        }

        private void Configs_Click(object sender, EventArgs e)
        {
            if (Program.configuracoes_active == false)
            {
                configuracoes minhas_configuracoes = new configuracoes();
                minhas_configuracoes.Show();
            }
        }

        private void selectversion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectversion.SelectedIndex == 2)
            {
                Extract.Enabled = false;
                Compile.Enabled = false;
                Msg.ForeColor = Color.Goldenrod;
                Msg.Text = "Unable to work with these versions.";
            }

            else
            {
                Extract.Enabled = true;
                Compile.Enabled = true;
                Msg.ForeColor = Color.Green;
                Msg.Text = "Welcome, foreign! (:";
            }
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
            selectversion.SelectedIndex = 1;
        }
    }
}
