using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Bibliotecas que eu adicionei
using System.IO;
using System.Drawing;
using System.Drawing.Imaging; //Lockbit/Unlockbits
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Azzi_Sprite_Compiler
{
    class SprReader
    {
        public SprItem[] SprItems;
        public bool isRead = false;
        private TextBox registred, read, exported, compiled;
        public UInt16 numberOfSpritesRegistred16;
        public UInt32 numberOfSpritesRead, numberOfSpritesRegistred32;
        bool[] TheControllers;
        public byte[] signature = new byte[4];

        public SprReader(string sprpath, TextBox register, TextBox reader, TextBox exporter, TextBox compiler, bool[] Controllers, string version)
        {
            registred = register;
            read = reader;
            exported = exporter;
            compiled = compiler;
            TheControllers = Controllers;
            if (this.OpenFile(sprpath, version))
            {
                isRead = true;
            }

            else
            {
                isRead = false;
            }
        }

        //Função deliciosa que eu achei na internet
        /* Função: CopyDataToBitmap
         * Objetivo: transforma um array de bytes em bmp
         * Autor: bledazemi
         * Link: http://www.tek-tips.com/viewthread.cfm?qid=1264492
         */
        public Bitmap CopyDataToBitmap(byte[] data)
        {
            //Here create the Bitmap to the know height, width and format
            Bitmap bmp = new Bitmap(32, 32, PixelFormat.Format24bppRgb);

            //Create a BitmapData and Lock all pixels to be written 
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);

            //Copy the data from the byte array into BitmapData.Scan0
            Marshal.Copy(data, 0, bmpData.Scan0, data.Length);

            //Unlock the pixels
            bmp.UnlockBits(bmpData);

            //Return the bitmap 
            return bmp;
        }

        /* Função: CreateNullImage()
         * Objetivo: Cria uma imagem 32x32 em magenta
         */
        private Bitmap CreateNullImage()
        {
            byte[] magenta = new byte[3072];
            for (int j = 0; j < 3072; j++)
            {
                magenta[j] = 255;
                j++;
                magenta[j] = 0;
                j++;
                magenta[j] = 255;
            }
            return CopyDataToBitmap(magenta);
        }

        private bool OpenFile(string filepath, string version)
        {
            if (File.Exists(filepath))
            {
                BinaryReader readspr = new BinaryReader(File.OpenRead(filepath)); //abrindo o arquivo
                signature[0] = readspr.ReadByte();
                signature[1] = readspr.ReadByte();
                signature[2] = readspr.ReadByte();
                signature[3] = readspr.ReadByte();//assinatura da versão
                if (version == "7.2")
                {
                    numberOfSpritesRegistred16 = readspr.ReadUInt16(); //Número de sprites (para versões entre 3.1 e 7.2)
                    numberOfSpritesRegistred32 = UInt32.Parse(numberOfSpritesRegistred16.ToString());
                }

                else if (version == "9.6")
                {
                    numberOfSpritesRegistred32 = readspr.ReadUInt32(); // Número de sprites (para versões maiores que 9.6)
                }

                registred.Text = numberOfSpritesRegistred32.ToString();
                numberOfSpritesRegistred32 += 1; //O index começa no 1
                SprItems = new SprItem[numberOfSpritesRegistred32];

                for (int i = 1; i < numberOfSpritesRegistred32; i++)
                {
                    SprItems[i] = new SprItem();
                    SprItems[i].Offset = readspr.ReadUInt32();
                }

                for (int i = 1; i < numberOfSpritesRegistred32; i++)
                {
                    int px = 0;
                    //Lockits/Unlobkbits
                    byte[] pixelArray = new byte[3072]; //Aqui as informações de cada pixel são armazenadas em Alpha, Red, Blue, Green, isso dá 4096 por que 32*32 = 1024*4 = 4096
                    if (SprItems[i].Offset == 0 && version == "9.6")
                    {
                    }

                    else
                    {
                        readspr.BaseStream.Seek(SprItems[i].Offset, SeekOrigin.Begin);
                        try
                        {
                            SprItems[i].TransparentPixel = Color.FromArgb(readspr.ReadByte(), readspr.ReadByte(), readspr.ReadByte());


                            SprItems[i].Length = readspr.ReadUInt16(); //Animais! Isso não é o tamanho da sprite em pixels (1024)! Isso é a quantidade de bytes que ela ocupa em bytes no Tibia.spr!
                            SprItems[i].SprBmp = new Bitmap(32, 32);

                            UInt32 TheEnd = SprItems[i].Offset + SprItems[i].Length;
                            while (readspr.BaseStream.Position < TheEnd && px != 3072)
                            {
                                UInt16 TransPx = readspr.ReadUInt16();
                                UInt16 NormalPx = readspr.ReadUInt16();

                                for (int j = 0; j < TransPx; j++)
                                {
                                    if (px != 3072)
                                    {
                                        //A ordem BGR é fora de padrão, mas não fui eu quem escolheu que fosse assim D:
                                        pixelArray[px] = 255; //blue
                                        px++;
                                        pixelArray[px] = 0; //green
                                        px++;
                                        pixelArray[px] = 255; //red
                                        px++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                for (int j = 0; j < NormalPx; j++)
                                {
                                    if (px != 3072)
                                    {
                                        byte red = readspr.ReadByte(), green = readspr.ReadByte(), blue = readspr.ReadByte();
                                        pixelArray[px] = blue; //blue
                                        px++;
                                        pixelArray[px] = green; //green
                                        px++;
                                        pixelArray[px] = red; //red
                                        px++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            } //fim do while
                        }
                        catch
                        {
                            MasterForm.ShowMsg.Stop();
                            MessageBox.Show("Wrong version selected... Choose the right version to extract the Sprites", "Wrong version");
                            break;
                        }
                    }
                    //O Tibia ignora o resto dos bytes transparentes quando o item inteiro já foi desenhado, então esse for compensa os magentinhas ;D
                    for (int j = px; j < 3072; j++)
                    {
                        pixelArray[j] = 255; //blue
                        j++;
                        pixelArray[j] = 0; //green
                        j++;
                        pixelArray[j] = 255; //red
                        //o J aumenta no for para o RED
                    }

                    SprItems[i].SprBmp = CopyDataToBitmap(pixelArray); //Conversão rapida de byte[] para bitmap
                    string pass = Program.isPasswordSprite(SprItems[i].SprBmp);
                    if (pass != "")
                    {
                        MasterForm.gettedPassword = pass;
                        MasterForm.gettedSpriteNo = i.ToString();
                    }

                    numberOfSpritesRead++;
                    read.Text = numberOfSpritesRead.ToString();
                }//fim do for que carrega todas as sprites
                TheControllers[2] = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    class SprItem
    {
        //OffSet, não faço ideia de pra que serve isso, mas dani-se ;D
        public UInt32 Offset;

        //Cor do pixel transparente
        public Color TransparentPixel;

        public UInt16 Length;

        public Bitmap SprBmp;
    }
}
