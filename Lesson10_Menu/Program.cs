using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10_Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordExit = "Esc";
            string inputUser = string.Empty;
            string userName = string.Empty;
            string userPassword = string.Empty;
            string inputPassword = string.Empty;
            
            Console.WriteLine("*****Меню*****");
            Console.WriteLine("SetName - установить имя");
            Console.WriteLine("ChangeConsoleColor - изменить цвет консоли");
            Console.WriteLine("SetPassword - установить пароль");
            Console.WriteLine("WriteName – вывести имя (после ввода пароля)");
            Console.WriteLine("Esc – выход из программы");
            Console.WriteLine("**************");

            Console.WriteLine();
            
            while (inputUser != wordExit)
            {
                Console.Write("Введите нужную команду(см. Меню выше): ");
                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case "SetName":
                        Console.Write("Установите имя!: ");
                        inputUser = Console.ReadLine();
                        userName = inputUser;
                        Console.WriteLine("Имя установлено!");
                        break;
                    case "ChangeConsoleColor":                        
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;
                    case "SetPassword":
                        if (userPassword != string.Empty)
                        {
                            Console.WriteLine("Вы хотите заменить свой пароль?(Y/N)");
                            inputUser = Console.ReadLine();
                            if (inputUser == "Y")
                            {
                                Console.Write("Установите новый пароль: ");
                                userPassword = Console.ReadLine();
                                Console.WriteLine("Пароль успешно изменен!");
                            }
                            else if (inputUser == "N")
                            {
                                Console.WriteLine("Пароль остался прежним!");
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ввод! Введите Y для подтверждения или N для отмены!");
                            }
                        }
                        else
                        {
                            Console.Write("Установите пароль: ");
                            userPassword = Console.ReadLine();
                            Console.WriteLine("Пароль установлен!");
                        }                       
                        break;
                    case "WriteName":
                        if (userPassword != string.Empty)
                        {
                            Console.Write("Введите пароль: ");
                            inputPassword = Console.ReadLine();
                            
                            if (userPassword == inputPassword)
                            {
                                if (userName ==string.Empty)
                                {
                                    Console.WriteLine("Имя не введено! Введите имя!");
                                    break;
                                }
                                Console.WriteLine($"Имя: {userName}");
                            }
                            else
                            {
                                Console.WriteLine("Пароль не создан либо введен не верно!");
                            }
                        }                        
                        else
                        {
                            Console.WriteLine("Для начала установите пароль!");
                        }
                        break;                                    
                }
            }
            Console.WriteLine("Вы вышли из программы!");

            Console.ReadKey();
        }
    }
}
