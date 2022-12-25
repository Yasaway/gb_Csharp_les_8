// Задача 58: Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

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

int[,] ChangeRowsColumns(int[,] matrix2, int rows, int columns)
{
    int[,] matrix = new int[columns, rows];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i,j] = matrix2[j,i];
        }
    }
    return matrix;
}

int[,] CreateMatrixMultiply(int[,] matrixOne, int[,] matrixTwo, int rowsOne,int columnsOne, int rowsTwo, int columnsTwo)
{
    int[,] matrixMultiply = new int[rowsOne, columnsTwo];
    int[,] remastMatrixTwo = ChangeRowsColumns(matrixTwo, rowsTwo, columnsTwo);
    int temp = 0;
    for (int i = 0; i < matrixMultiply.GetLength(0); i++)
    {        
        for (int j = 0; j < matrixMultiply.GetLength(1); j++)
        {
            for (int p = 0; p < matrixOne.GetLength(0); p++)
            {
                // Console.Write($"temp = {temp} + {matrixOne[i,p], 4} * {remastMatrixTwo[j,p], 4 } |\n"); //Проверка произведения
                temp += matrixOne[i,p] * remastMatrixTwo[j,p];
                // Console.Write($"matrixMultiply[i,j] = {temp, 4} |\n"); // Проверка присвоения
                matrixMultiply[i,j] = temp;
            }
            temp = 0;
        }
    }
    return matrixMultiply;
}


Console.Write($"Произведение матриц \nПервая матрица \n");
Console.Write($"Сколько будет строк: ");
int rows1 = Convert.ToInt32(Console.ReadLine());
Console.Write($"Сколько будет столбцов: ");
int columns1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Вторая матрица ");
Console.Write($"Сколько будет строк: ");
int rows2 = Convert.ToInt32(Console.ReadLine());
Console.Write($"Сколько будет столбцов: ");
int columns2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();

int min = 1;
int max = 10;
int[,] matrix1 = CreateMatrixRndInt(rows1, columns1, min, max);
int[,] matrix2 = CreateMatrixRndInt(rows2, columns2, min, max);
PrintMatrix(matrix1);
PrintMatrix(matrix2);
// int[,] matrix4 = ChangeRowsColumns(matrix2, rows2, columns2); //Проверка замены столбцов на строки
// PrintMatrix(matrix4);
if (columns1 == rows2)
{
    int[,] matrixMultiply = CreateMatrixMultiply(matrix1, matrix2, rows1, columns1, rows2, columns2);
    Console.WriteLine($"Произведение матриц равно ");
    PrintMatrix(matrixMultiply);
}
else Console.WriteLine($"Произведение матриц невозможно! Матрицы не совместимы!");