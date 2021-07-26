using System;

namespace Lesson21_READINT
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = ReturnNumberIsTryParse();
            Console.WriteLine($"Число: {result}");

            Console.ReadKey();
        }

        static int ReturnNumberIsTryParse() 
        {
            int number = 0;
            bool isConverted = false;

            while (isConverted == false)
            {
                Console.Write("Введите число: ");
                string inputUser = Console.ReadLine();
                if (int.TryParse(inputUser, out number))
                {
                    isConverted = true;
                }
            }

            return number;
        }
    }
}
