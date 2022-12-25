// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int[,] CreateMatrix(int[,] matrix, int rows, int colums)
{    
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1)/2; j++)
        {            
            int temp = matrix[i,j];
        }
    }
    return matrix;
}

int[,] CreateMatrixSpiral(int rows, int columns)
{
    int[,] matrix = new int[rows,columns];

    int row = 0, col = 0, dx = 1, dy = 0, dirChanges = 0, gran = columns;

    for (int i = 0; i < matrix.Length; i++)
    {
        matrix[row,col] = i + 1;
        if (--gran == 0)
        {
            gran = columns * (dirChanges % 2) + rows * ((dirChanges + 1) % 2) - (dirChanges / 2 - 1) - 2;

            int temp = dx;
            dx = -dy;
            dy = temp;
            dirChanges++;
        }
        col += dx;
        row += dy;
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
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j], 4} "); //форматирование отступ на 4 
            else Console.Write($"{matrix[i, j], 4}");
        }
        Console.WriteLine("]");
    }
    Console.WriteLine();
}

Console.WriteLine($"Программа заполняет массив по спирали ");
int rows = 4, columns = 4;

int[,] matrix = CreateMatrixSpiral(rows, columns);
CreateMatrix(matrix, rows, columns);
PrintMatrix(matrix);