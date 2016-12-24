using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Bibliotecas que eu adicionei
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;

namespace Azzi_Sprite_Compiler
{
    class SprCompiler
    {
        //função responsável por compilar as imagens individualmente
        public static byte[] CompileImg(Image sprite)
        {
            byte[] compiled = new byte[0], coloredgroup = new byte[0], add = new byte[3], coloreds, transps;

            //Quantos pixels coloridos? Quantos transparentes?
            UInt16 colored = 0, transp = 0;

            //Declarando os pixels
            Color pixel, nextPx;
            Bitmap mysprite = new Bitmap(sprite);
            for (int y = 0; y < mysprite.Height; y++)
            {
                for (int x = 0; x < mysprite.Width; x++)
                {

                    pixel = mysprite.GetPixel(x, y);
                    if (isMagenta(pixel))
                    {
                        transp++;
                    }

                    else
                    {
                        //Adicionando o novo pixel
                        add[0] = pixel.R;
                        add[1] = pixel.G;
                        add[2] = pixel.B;

                        //Avisando que mais um pixel colorido foi encontrado
                        colored++;

                        //Próximo pixel
                        nextPx = nextPixel(mysprite, x, y);

                        coloredgroup = groupByteArray(coloredgroup, add);
                        //se o proximo pixel for magenta OU se esse for o ultimo e for colorido
                        if (x == 31 && y == 31 && isMagenta(pixel) == false || isMagenta(nextPx) == true)
                        {
                            //Salvando tudo
                            transps = Change.UInt16_to_Byte(transp);
                            coloreds = Change.UInt16_to_Byte(colored);
                            compiled = groupByteArray(compiled, transps);
                            compiled = groupByteArray(compiled, coloreds);
                            compiled = groupByteArray(compiled, coloredgroup);

                            //Reiniciando
                            coloredgroup = new byte[0];
                            transp = 0;
                            colored = 0;
                        }
                    }
                }
            }

            return compiled;
        }

        //Agrupando array de bytes
        public static byte[] groupByteArray(byte[] myarray, byte[] add)
        {
            byte[] retorna = new byte[myarray.Length + add.Length];
            for (int i = 0; i < myarray.Length; i++)
            {
                retorna[i] = myarray[i];
            }

            int j = 0;
            for (int i = myarray.Length; i < retorna.Length; i++)
            {
                retorna[i] = add[j];
                j++;
            }

            return retorna;
        }

        public static bool isMagenta(Color px)
        {
            if (px.R == 255 && px.G == 0 && px.B == 255)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static Color nextPixel(Bitmap myImage, int myX, int myY)
        {
            myX++;
            //Ultimo pixel X
            if (myX == myImage.Width)
            {
                myY++;
                myX = 0;
                if (myY == myImage.Height)
                {
                    myY = 0;
                }
                return myImage.GetPixel(myX, myY);
            }

            else
            {
                return myImage.GetPixel(myX, myY);
            }
        }
    }

    //Classe responsável por fazer varias conversões
    class Change
    {
        public static UInt16 UInt16_add(UInt16 mynumber, int myadd)
        {
            return UInt16.Parse((int.Parse(mynumber.ToString()) + myadd).ToString());
        }

        public static UInt32 UInt32_add(UInt32 mynumber, int myadd)
        {
            return UInt32.Parse((int.Parse(mynumber.ToString()) + myadd).ToString());
        }

        public static UInt16 Int32_to_UInt16(Int32 inteiro)
        {
            return UInt16.Parse(inteiro.ToString());
        }

        public static UInt32 Int32_to_UInt32(Int32 inteiro)
        {
            return UInt32.Parse(inteiro.ToString());
        }

        public static UInt16 UInt32_to_UInt16(UInt32 inteiro)
        {
            return UInt16.Parse(inteiro.ToString());
        }

        public static UInt32 UInt16_to_UInt32(UInt16 inteiro)
        {
            return UInt32.Parse(inteiro.ToString());
        }

        private bool ImageComparision(Image myimg1, Image myimg2)
        {
            string img1_ref, img2_ref;
            int count1 = 0, count2 = 0;
            bool equal = true;
            Bitmap img1 = new Bitmap(myimg1);
            Bitmap img2 = new Bitmap(myimg2);
            if (img1.Width == img2.Width && img1.Height == img2.Height)
            {
                for (int i = 0; i < img1.Width; i++)
                {
                    for (int j = 0; j < img1.Height; j++)
                    {
                        img1_ref = img1.GetPixel(i, j).ToString();
                        img2_ref = img2.GetPixel(i, j).ToString();
                        if (img1_ref != img2_ref)
                        {
                            count2++;
                            equal = false;
                            break;
                        }
                        count1++;
                    }
                }
                return equal;
            }

            else
            {
                return false;
            }
        }

        public static byte[] UInt16_to_Byte(UInt16 convertme)
        {
            string hex1, hex2, hex = Convert.ToString(convertme, 16);
            byte[] retorna = new byte[2];
            if (hex.Length == 1)
            {
                hex = "000" + hex;
            }

            else if (hex.Length == 2)
            {
                hex = "00" + hex;
            }

            else if (hex.Length == 3)
            {
                hex = "0" + hex;
            }

            hex1 = hex.Substring(2, 2);
            hex2 = hex.Substring(0, 2);

            retorna[0] = byte.Parse(hex1, NumberStyles.HexNumber);
            retorna[1] = byte.Parse(hex2, NumberStyles.HexNumber);

            return retorna;
        }

        public static byte[] UInt32_to_Byte(UInt32 convertme)
        {
            string hex1, hex2, hex3, hex4, hex = Convert.ToString(convertme, 16);
            byte[] retorna = new byte[4];
            if (hex.Length == 1)
            {
                hex = "0000000" + hex;
            }

            else if (hex.Length == 2)
            {
                hex = "000000" + hex;
            }

            else if (hex.Length == 3)
            {
                hex = "00000" + hex;
            }

            else if (hex.Length == 4)
            {
                hex = "0000" + hex;
            }

            else if (hex.Length == 5)
            {
                hex = "000" + hex;
            }

            else if (hex.Length == 6)
            {
                hex = "00" + hex;
            }

            else if (hex.Length == 7)
            {
                hex = "0" + hex;
            }

            hex1 = hex.Substring(6, 2);
            hex2 = hex.Substring(4, 2);
            hex3 = hex.Substring(2, 2);
            hex4 = hex.Substring(0, 2);

            retorna[0] = byte.Parse(hex1, NumberStyles.HexNumber);
            retorna[1] = byte.Parse(hex2, NumberStyles.HexNumber);
            retorna[2] = byte.Parse(hex3, NumberStyles.HexNumber);
            retorna[3] = byte.Parse(hex4, NumberStyles.HexNumber);

            return retorna;
        }
    }
}
