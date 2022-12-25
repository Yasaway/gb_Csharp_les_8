// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке 
// и выдаёт номер строки с наименьшей суммой элементов: 1 строка

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

int[] CreateArray(int[,] matrix, int rows)
{
    int m = 0, sumRow = 0;
    int[] arr = new int[rows];  
    for (int i = 0; i < matrix.GetLength(0); i++)
    {        
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i == m)
            {
                sumRow += matrix[i,j];
            }
        }
        arr[i] = sumRow;
        sumRow = 0;
        m++;
    }
    return arr;
}

void PrintArray(int[] array) //тут вывожу массив для проверки
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i], 3} ");
    }
    Console.Write("]\n");
    Console.WriteLine();
}

void SearchMinSumRows(int[] array)
{
    int numberRow = 0, min = array[0];
    for (int i = 1; i < array.Length; i++)
    {
        if (min > array[i])
        {
            min = array[i];
            numberRow = i;
        }
    }
    Console.WriteLine($"Номер строки с наименьшей суммой элементов: {numberRow + 1}");
}

Console.WriteLine($"Создание матрицы");
Console.Write($"Сколько будет строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write($"Сколько будет столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());

int min = 0;
int max = 10;
int[,] array2D = CreateMatrixRndInt(rows, columns, min, max);
PrintMatrix(array2D);
int[] array = CreateArray(array2D, rows);
PrintArray(array);
SearchMinSumRows(array);