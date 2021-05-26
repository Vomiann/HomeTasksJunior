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
            string comandSum = "sum";
            string inputUser = string.Empty;
            int [] arrayNumbers = new int[1];
            int[] tempArrayNumbers = new int[arrayNumbers.Length +1];
            int sumResult = 0;


            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                tempArrayNumbers[i] = arrayNumbers[i];
            }

            while (inputUser != wordExit.ToLower())
            {
                Console.Write("Введите число: ");
                inputUser = Console.ReadLine();

                if (inputUser.All(Char.IsDigit))
                {
                    
                    tempArrayNumbers[tempArrayNumbers.Length - 1] = Convert.ToInt32(inputUser);
                    arrayNumbers = tempArrayNumbers;
                }
                              



                if (inputUser == comandSum.ToLower())
                {
                    for (int i = 0; i < arrayNumbers.Length; i++)
                    {
                        sumResult += arrayNumbers[i];
                    }
                    Console.WriteLine($"Сумма всех чисел составляет: {sumResult}") ;
                }

            }



            Console.ReadKey();
        }
    }
}
