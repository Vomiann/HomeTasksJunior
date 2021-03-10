using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson06_QuestionToUser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Как вас зовут?");
            string name = Console.ReadLine();

            Console.WriteLine("Какой ваш возраст?");
            string age = Console.ReadLine();

            Console.WriteLine("Какой ваш знак зодиака?");
            string zodiacSign = Console.ReadLine();

            Console.WriteLine("Где вы работаете?");
            string work = Console.ReadLine();

            Console.WriteLine($"Вас зовут {name}, вам {age}, вы {zodiacSign} и работаете на {work}");

            Console.ReadKey();
        }
    }
}
