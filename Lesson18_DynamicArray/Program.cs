using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson18_DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordExit = "exit";
            string commandSum = "sum";
            string inputUser = string.Empty;
            int [] arrayNumbers = new int[0];
            int[] tempArrayNumbers;
            int sumResult = 0;

            while (inputUser != wordExit.ToLower())
            {
                Console.Write("Введите число: ");
                inputUser = Console.ReadLine();

                if (inputUser.All(Char.IsDigit))
                {
                    tempArrayNumbers = new int[arrayNumbers.Length + 1];
                    tempArrayNumbers[tempArrayNumbers.Length - 1] = Convert.ToInt32(inputUser);

                    for (int i = 0; i < arrayNumbers.Length; i++)
                    {
                        tempArrayNumbers[i] = arrayNumbers[i];
                    }
                                                        
                    arrayNumbers = tempArrayNumbers;
                }                             
                
                if (inputUser == commandSum.ToLower())
                {
                    for (int i = 0; i < arrayNumbers.Length; i++)
                    {
                        sumResult += arrayNumbers[i];
                    }
                    Console.WriteLine($"Сумма всех чисел составляет: {sumResult}") ;
                    sumResult = 0;
                }
            }

            Console.WriteLine("Вы вышли из программы!");

            Console.ReadKey();
        }
    }
}
