// Задача 54: Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows,columns];
    Random rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i,j] = rnd.Next(min, max);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j], 4}, "); //форматирование отступ на 4 
            else Console.Write($"{matrix[i, j], 4}");
        }
        Console.WriteLine("]");
    }
    Console.WriteLine();
}

int[,] FixMatrixByArray(int[,] matrix, int columns, int min, int max)
{
    int m = 0;
    int[] arr = new int[columns];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {        
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            arr[j] = matrix[i,j];
            Array.Sort(arr, (min, max) => max.CompareTo(min));
            m++;
            if (m == matrix.GetLength(1))
            {
                m = 0;
                for (int p = 0; p < matrix.GetLength(1); p++)
                {
                    matrix[i,p] = arr[p];
                    arr[p] = 0;
                }
            }
        }  
    }
    return matrix;
}

Console.WriteLine($"Программа упорядочит элементы каждой строки двумерного массива по убыванию \nСоздание матрицы");
Console.Write($"Сколько будет строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write($"Сколько будет столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());

int min = 0;
int max = 10;
int[,] array2D = CreateMatrixRndInt(rows, columns, min, max);
PrintMatrix(array2D);
FixMatrixByArray(array2D, columns, min, max);
PrintMatrix(array2D);