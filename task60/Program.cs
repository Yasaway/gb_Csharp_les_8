// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Например, задан массив размером 2 x 2 x 2.
// Результат:
// 66(0,0,0) 27(0,0,1) 25(0,1,0) 90(0,1,1)
// 34(1,0,0) 26(1,0,1) 41(1,1,0) 55(1,1,1)

int[,,] CreateArrayThree(int temp, int min, int max)
{
    int[,,] arrThree = new int[temp,temp,temp];
    Random rnd = new Random();
    for (int i = 0; i < arrThree.GetLength(0); i++)
    {
        for (int j = 0; j < arrThree.GetLength(1); j++)
        {
            for (int z = 0; z < arrThree.GetLength(2); z++)
            {
                arrThree[i,j,z] = rnd.Next(min, max);
            }
        }
    }
    return arrThree;
}

void PrintArrayThree(int[,,] arrThree)
{
    for (int i = 0; i < arrThree.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < arrThree.GetLength(1); j++)
        {
            for (int z = 0; z < arrThree.GetLength(2); z++)
            {
                if (z < arrThree.GetLength(2) - 1) Console.Write($"{arrThree[i, j, z], 4} "); //форматирование отступ на 4 
                else Console.Write($"{arrThree[i, j, z], 4}");
            }
        }
        Console.WriteLine("]");
    }
    Console.WriteLine();
}

Console.WriteLine($"Программа трёхмерного массива");
int temp = 2;
Console.WriteLine($"задан массив размером {temp} x {temp} x {temp}");
int min = 10;
int max = 99;
int[,,] arrayThree = CreateArrayThree(temp, min, max);
PrintArrayThree(arrayThree);