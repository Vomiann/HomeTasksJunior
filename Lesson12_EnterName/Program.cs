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

            Console.WriteLine("Введите имя: ");
            string inputName = Console.ReadLine();

            Console.WriteLine("Введите символ: ");
            string inputSymbol = Console.ReadLine();

            int lengthName = inputName.Length;

            for (int i = 0; i < 3; i++)
            {

                Console.WriteLine($"");
            }



            Console.ReadKey();
        }
    }
}
