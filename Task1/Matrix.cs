using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Matrix
    {
        public static int[,] RandomMatrix(int N, int M, int MinValue = -5, int MaxValue = 10)
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
                    if (array[i, j] > 0) Count++;
            }
            return Count;
        }
        public static int MaxNumberMore(int[,] array)
        {
            int maxNumber = 0;
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    for (int n = 0; n < array.GetLength(0); n++)
                        for (int m = 0; m < array.GetLength(1); m++)
                            if (array[i, j] > maxNumber && array[i, j] == array[n, m] 
                                && i != n && j != m) maxNumber = array[i, j];
            return maxNumber;
        }
        public static int CountStringsWithoutZeros(int[,] array)
        {
            int count = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int zero = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                    if (array[i, j] == 0) zero++;
                if (zero == 0) count++;
                zero = 0;
            }
            return count;
        }
        public static int StringWithZero(int[,] array)
        {
            int count = 0;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                int zero = 0;
                for (int j = 0; j < array.GetLength(0); j++)
                    if (array[j, i] == 0) zero++;
                if (zero != 0) count++;
                zero = 0;
            }
            return count;
        }
        public static int SeriesIdenticalElements(int[,] array)
        {
            int[] myArray = new int[array.GetLength(0)];
            int count;
            int temp;
            int index = -1;
            for (int i = 0; i < array.GetLength(0); i++) 
            {
                count = 1;
                temp = 1;
                for (int j = 0; j < array.GetLength(1) - 1; j++)
                {
                    if (array[i, j] == array[i, j + 1]) temp++;
                    if (temp > count) count = temp;
                    if (array[i, j] != array[i, j + 1]) temp = 1;
                }
                myArray[i] = count;
            }
            temp = myArray[0];
            for (int i = 1; i < myArray.Length; i++)
                if (temp < myArray[i])
                {
                    temp = myArray[i];
                    index = i;
                }
            return index;
        }
        public static int SumColumnsNegativeElement(int[,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(1); i++)
                for (int j = 0; j < array.GetLength(0); j++)
                    if (array[j, i] < 0)
                    {
                        for (int m = 0; m < array.GetLength(0); m++)
                            sum += array[m, i];
                        break;
                    }
                    return sum;
        }
        public static int SumColumnsNotNegativeElement(int[,] array)
        {
            int count;
            int sum = 0;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                count = 0;
                for (int j = 0; j < array.GetLength(0); j++)
                    if (array[j, i] >= 0)
                        count++;
                if(count == array.GetLength(0))
                    for (int m = 0; m < array.GetLength(0); m++)
                        sum += array[m, i];
            }
            return sum;
        }
        public static int DobRowsNotNegativeElement(int[,] array)
        {
            int count;
            int dob = 1;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                count = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                    if (array[i, j] > 0)
                        count++;
                if (count == array.GetLength(1))
                    for (int m = 0; m < array.GetLength(1); m++)
                        dob *= array[i, m];
            }
            return dob;
        }
        public static int SumsElementsDiagonalsParallel(int[,] array)
        {
            int[] myArray = new int[array.GetLength(0) + array.GetLength(1)];
            for (int i = 1; i < array.GetLength(0); i++)
            {
                int sumU = 0;
                int sumD = 0;
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (i + j + 1 > array.GetLength(1))
                        break;
                    sumU += array[j, i + j];
                }
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i + j + 1 > array.GetLength(0))
                        break;
                    sumD += array[i + j, j];
                }
                myArray[i - 1] = sumU;
                myArray[myArray.Length - i] = sumD;
            }
            int maxSum = myArray[0];
            for (int i = 1; i < myArray.Length; i++) 
                if (maxSum < myArray[i]) maxSum = myArray[i];
            return maxSum;
        }
        public static int SumsModulsElementsDiagonalsParallel(int[,] array)
        {
            int index;
            if (array.GetLength(0) == array.GetLength(1))
                index = 1;
            index = 0;
            int[] myArray = new int[array.GetLength(0) + array.GetLength(1) - 2];
            for (int i = 0; i < array.GetLength(0) - index; i++)
            {
                int sumU = 0;
                int sumD = 0;
                for (int j = 1; j <= array.GetLength(0); j++)
                {
                    if (array.GetLength(1) - j - 1 - i < 0)
                        break;
                    else
                    {
                        sumU += Math.Abs(array[j - 1, array.GetLength(1) - j - 1 - i]);
                        myArray[i] = sumU;
                    }
                }
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    if (j + i == array.GetLength(0))
                        break;
                    else
                    {
                        sumD += Math.Abs(array[j + i, array.GetLength(1) - j]);
                        if (myArray.Length - array.GetLength(0) + i + 1 < myArray.Length)
                            myArray[myArray.Length - array.GetLength(0) + i + 1] = sumD;
                    }
                }
            }
            int minSum = myArray[0];
            for (int i = 1; i < myArray.Length; i++)
                if (minSum > myArray[i]) minSum = myArray[i];
            return minSum;
        }
    }
}
