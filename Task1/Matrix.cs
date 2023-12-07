﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Matrix
    {
        public static int[,] RandomMatrix(int N, int M, int MinValue = -1, int MaxValue = 10)
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
            
            int max = Math.Max(array.GetLength(0), array.GetLength(1));
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
    }
}
