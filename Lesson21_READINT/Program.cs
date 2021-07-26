using System;

namespace Lesson21_READINT
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = RequestToConvertStringToNumber();
            Console.WriteLine($"Число: {result}");

            Console.ReadKey();
        }

        static int RequestToConvertStringToNumber()
        {
            int number = 0;
            bool isNumber = false;

            while (isNumber == false)
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
