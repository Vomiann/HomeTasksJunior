using System;
using System.Collections.Generic;

namespace Lesson26_DynamicArrayV2
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordExit = "exit";
            string commandSum = "sum";
            string inputUser = string.Empty;
            int resultNumber;
            List<int> numbers = new List<int>();

            Console.WriteLine("Для выхода введите - exit");
            Console.WriteLine("Для расчетта суммы введите - sum");
            while (inputUser.ToLower() != wordExit)
            {
                Console.Write("Введите число или команду: ");
                inputUser = Console.ReadLine();

                if (int.TryParse(inputUser, out resultNumber))
                {
                    numbers.Add(resultNumber);
                }
                else
                {
                    if (inputUser.ToLower() == commandSum)
                    {
                        ShowTotalSum(numbers);
                    }
                    else if(inputUser.ToLower() != wordExit)
                    {
                        Console.WriteLine("Число не введеню или введанной команды не существует!");
                    }
                }
            }

            Console.WriteLine("Вы вышли из программы!");

            Console.ReadKey();
        }

        static void ShowTotalSum(List<int> numbers)
        {
            int sumResult = 0;

            foreach (var number in numbers)
            {
                sumResult += number;
            }
            Console.WriteLine($"Сумма всех чисел составляет: {sumResult}");
        }
    }
}
