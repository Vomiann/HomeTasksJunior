using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson08_ExitLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordExit = "exit";
            Console.Write(@"Введите ""ключевое"" слово для выхода из программы: ");
            string userInput = Console.ReadLine();

            while (true)
            {
                if (userInput == wordExit)
                {
                    Console.WriteLine(@"""Ключевое"" слово Принято! Вы успешно вышли из программы!");
                    break;
                }
                Console.WriteLine(@"Не верно введено ""Ключевое"" слово! Вы не вышли из программы!");
            }

            Console.ReadKey();
        }
    }
}
