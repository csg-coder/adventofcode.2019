﻿using System;
using System.Drawing;
using static System.String;
using System.Linq;

namespace day_8
{
    public static class Utils
    {

        public static void ShowMatrix(this char[][] img, int lmax, int cmax)
        {
            for (int l = 0; l < lmax; l++)
            {
                for (int c = 0; c < cmax; c++)
                {
                    if (img[l][c] == '0')
                        Console.Write(' ');
                    else
                        Console.Write('*');
                }
                Console.WriteLine();
            }
        }
        public static void DrawMatrix(this char[][] img, int lmax, int cmax)
        {
            using (var bmp = new Bitmap(cmax, lmax))
            using (var gr = Graphics.FromImage(bmp))
            {
                for (int l = 0; l < lmax; l++)
                {
                    for (int c = 0; c < cmax; c++)
                    {
                        bmp.SetPixel(c, l, img[l][c] == '1' ? Color.Black : Color.White);
                    }
                }
                var path = "out.png";
                bmp.Save(path);
            }
        }

        public static string Combine(this char[][] img)
        {
            return Join("", img.Select(o => Join("", o)));
        }
    }
}
