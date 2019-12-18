using System;
namespace day_17
{
    public static class MatrixExtensions
    {
        public static char At(this char[,] matrix, Pos pos)
        {
            return matrix[pos.l, pos.c];
        }
        public static void Op(this char[,] matrix, Action<Pos> act)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    act(new Pos { l = i, c = j });
            }
        }
        public static char[,] Copy(this char[,] matrix)
        {
            return matrix.Clone() as char[,];
        }
    }
}