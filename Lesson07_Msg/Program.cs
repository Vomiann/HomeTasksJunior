using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson07_Msg
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberMessages = 5;

            Console.Write("Введите свое сообщение: ");
            string userMessage = Console.ReadLine();

            for (int i = 0; i < numberMessages; i++)
            {
                Console.WriteLine($"Сообщение ({i}): userMessage");
            }

            Console.ReadKey();
        }
    }
}
