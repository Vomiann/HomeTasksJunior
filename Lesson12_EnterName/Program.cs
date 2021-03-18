using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_EnterName
{
    class Program
    {
        static void Main(string[] args)
        {
            int countSymbols = 2;

            Console.Write("Введите имя: ");
            string inputName = Console.ReadLine();

            Console.Write("Введите символ: ");
            string inputSymbol = Console.ReadLine();

            int lengthName = inputName.Length;

            for (int j = 0; j < lengthName + countSymbols; j++)
            {
                Console.Write($"{inputSymbol}");
            }
            Console.WriteLine();
            Console.WriteLine($"{inputSymbol}"+ inputName + $"{inputSymbol}");

            for (int j = 0; j < lengthName + countSymbols; j++)
            {
                Console.Write($"{inputSymbol}");
            }

            Console.ReadKey();
        }
    }
}
