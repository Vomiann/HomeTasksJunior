using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson16_MaxElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[,] array = new int [10,10];
            int maxElement = int.MinValue;

            Console.WriteLine("Исходная матрица\n");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {                   
                    array[i, j] = random.Next(10,99);                                        
                    Console.Write(array[i, j] +" ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > maxElement)
                    {
                        maxElement = array[i, j];
                    }
                }
            }

            Console.WriteLine("\nИзмененная матрица\n");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == maxElement)
                    {
                        array[i, j] = 0;
                    }
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
                     
            Console.WriteLine($"\nНаибольший элемент матрицы: {maxElement}");

            Console.ReadKey();
        }
    }
}
