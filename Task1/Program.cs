using Task1;

Console.Write("Input N: ");
var N = int.Parse(Console.ReadLine());

Console.Write("Input M: ");
var M = int.Parse(Console.ReadLine());

int[,] myArray = Matrix.RandomMatrix(N, M);

Console.WriteLine("Randomly generated array:");
for (int i = 0; i < myArray.GetLength(0); i++)
{
    for (int j = 0; j < myArray.GetLength(1); j++)
        Console.Write($"{myArray[i, j]}\t");
    Console.WriteLine("\n");
}

int countPositive = Matrix.CountPositive(myArray);
Console.WriteLine($"Count positive elements: {countPositive}");

int maxNumberMore = Matrix.MaxNumberMore(myArray);
Console.WriteLine($"The maximum number that occurs more than once: {maxNumberMore}");

int countStringsWithoutZeros = Matrix.CountStringsWithoutZeros(myArray);
Console.WriteLine($"The number of lines that do not contain any null elements: " +
    $"{countStringsWithoutZeros}");
