using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace day_8
{
    class Program2
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");
            //var input = File.ReadAllText("input-test.txt");

            var lmax = 6; var cmax = 25;
            //var lmax = 2; var cmax = 2;

            var img = new char[lmax, cmax];
            for (int l = 0; l < lmax; l++)
                for (int c = 0; c < cmax; c++)
                {
                    img[l, c] = '2';
                }
            int pos = 0;
            while (pos < input.Length)
            {
                var r = input.Substring(pos, cmax * lmax);

                for (int l = 0; l < lmax; l++)
                    for (int c = 0; c < cmax; c++)
                    {
                        if (img[l, c] == '2')
                            img[l, c] = r[l * cmax + c];
                    }

                pos += cmax * lmax;
            }
            show(lmax, cmax, img);
            draw(lmax, cmax, img);
            //EJRGP
        }

        private static void show(int lmax, int cmax, char[,] img)
        {
            for (int l = 0; l < lmax; l++)
            {
                for (int c = 0; c < cmax; c++)
                {
                    if (img[l, c] == '0')
                        Console.Write(' ');
                    else
                        Console.Write('*');
                }
                Console.WriteLine();
            }
        }
        private static void draw(int lmax, int cmax, char[,] img)
        {
            using (var bmp = new Bitmap(cmax, lmax))
            using (var gr = Graphics.FromImage(bmp))
            {
                for (int l = 0; l < lmax; l++)
                {
                    for (int c = 0; c < cmax; c++)
                    {
                        bmp.SetPixel(c, l, img[l, c] == '1' ? Color.Black : Color.White);
                    }
                }
                var path = "out.png";
                bmp.Save(path);
            }
        }
    }
}
