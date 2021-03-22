using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13_Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int countAttempts = 3;
            string password = "password";
            string secretMessage = "SecretMessage";
            string inputUser;                       

            for (int i = 0; i < countAttempts; i++)
            {
                Console.Write("Введите пароль: ");
                inputUser = Console.ReadLine();

                if (inputUser == password)
                {
                    Console.WriteLine($"Пароль принят! Секретное сообщение: {secretMessage}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный пароль!");
                    continue;
                }
            }
            Console.WriteLine("Программа завершена! У вас закончились попытки");

            Console.ReadKey();
        }
    }
}
