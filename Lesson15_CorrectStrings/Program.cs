using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15_CorrectStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = {{1,2,3},{4,5,6},{7,8,9}};
            int sumResult = 0;
            int numberRow = 1;
            int numberColumn = 0;
            int multiplicationResult = 1; 

            Console.WriteLine("Исходная матрица:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i == numberRow)
                    {
                        sumResult += array[i, j];
                    }
                    if (j == numberColumn)
                    {
                        multiplicationResult *= array[i, j];
                    }
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
                       
            Console.WriteLine($"Сумма второй строки: {sumResult}");
            Console.WriteLine($"Произведение первого столбца: {multiplicationResult}");

            Console.ReadKey();
        }
    }
}
