using System;

namespace Lesson21_READINT
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = ConvertToNumber();
            Console.WriteLine($"Число: {result}");

            Console.ReadKey();
        }

        static int ConvertToNumber()
        {
            int number = 0;
            bool isNumber = false;

            while (!isNumber)
            {
                Console.Write("Введите число: ");
                string inputUser = Console.ReadLine();
                if (int.TryParse(inputUser, out number))
                {
                    isNumber = true;
                }
            }

            return number;
        }
    }
}
