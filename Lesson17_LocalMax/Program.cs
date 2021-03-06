﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson17_LocalMax
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];

          
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 31);
            }

            Console.WriteLine("Локальные максимумы: ");
            if (array[0] > array[1])
            {
                Console.Write(" " + array[0]);
            }

            for (int i = 1; i < array.Length-1; i++)
            {
                if (array[i] > array[i + 1] && array[i] > array[i - 1])
                {
                    Console.Write(" " + array[i]);
                }
            }

            if (array[array.Length - 1] > array[array.Length - 2])
            {
                Console.Write(" " + array[array.Length - 1]);
            }

            Console.ReadKey();
        }
    }
}
