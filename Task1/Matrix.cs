using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Matrix
    {
        public static int[,] RandomMatrix(int N, int M, int MinValue = -100, int MaxValue = 100)
        {
            int[,] array = new int[N, M];
            Random random = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = random.Next(MinValue, MaxValue);

            return array;
        }
        public static int CountPositive(int[,] array)
        {
            int Count = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    if(array[i, j] > 0)
                        Count++;
            }
         return Count;
        }
    }
}
