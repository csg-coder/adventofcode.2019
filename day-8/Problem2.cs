namespace day_8
{
    class Problem2
    {
        public static char[][] Run(string input, int lmax, int cmax)
        {
            var img = new char[lmax][];
            for (int l = 0; l < lmax; l++)
            {
                img[l] = new char[cmax];
                for (int c = 0; c < cmax; c++)
                {
                    img[l][c] = '2';
                }
            }
            int pos = 0;
            while (pos < input.Length)
            {
                var r = input.Substring(pos, cmax * lmax);

                for (int l = 0; l < lmax; l++)
                    for (int c = 0; c < cmax; c++)
                    {
                        if (img[l][c] == '2')
                            img[l][c] = r[l * cmax + c];
                    }

                pos += cmax * lmax;
            }
            return img;

        }

    }
}
