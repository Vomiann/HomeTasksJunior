using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson09_CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            float numberRub = 100;
            float numberEur = 100;
            float numberUsd = 100;
            string wordExit = "exit";
            string inputUser = string.Empty;
            float valueCurrency;
            float rubRateToUsd = 0.014f;
            float rubRateToEur = 0.011f;
            float eurRateToRub = 87.06f;
            float eurRateToUsd = 1.19f;
            float usdRateToRub = 73.08f;
            float usdRateToEur = 0.84f;

            Console.WriteLine($"Здравствуйте! Ваш текущий баланс составляет: RUB:{numberRub}(руб.) EUR:{numberEur}(евро) USD:{numberUsd}(долларов)");
            Console.WriteLine();
            Console.WriteLine("1 - Сконвертировать RUB в USD");
            Console.WriteLine("2 - Сконвертировать RUB в EUR");
            Console.WriteLine("3 - Сконвертировать EUR в RUB");
            Console.WriteLine("4 - Сконвертировать EUR в USD");
            Console.WriteLine("5 - Сконвертировать USD в RUB");
            Console.WriteLine("6 - Сконвертировать USD в EUR");            
            Console.WriteLine($"Выход из программы: {wordExit}");
            Console.WriteLine();

            while (inputUser != wordExit)
            {
                Console.Write("Введите требуемое действие(Введите exit для выхода или введите одно из чисел в диапазоне 1-6): ");
                inputUser = Console.ReadLine();

                if (inputUser == "1" || inputUser == "2" || inputUser == "3" || inputUser == "4" || inputUser == "5" || inputUser == "6")
                {
                    Console.Write("Сколько вы хотите сконвертьировать валюты? Введите значение: ");
                    valueCurrency = Convert.ToSingle(Console.ReadLine());
                }
                else if (inputUser == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("В данной программе отсутствует выбранное действие. Повторите попытку.");
                    continue;
                }                              

                switch (inputUser)
                {
                    case "1":
                        numberRub -= valueCurrency;
                        valueCurrency *= rubRateToUsd;
                        numberUsd += valueCurrency;
                    break;
                    case "2":
                        numberRub -= valueCurrency;
                        valueCurrency *= rubRateToEur;
                        numberUsd += valueCurrency;
                        break;
                    case "3":                        
                        numberEur -= valueCurrency;
                        valueCurrency *= eurRateToRub;
                        numberRub += valueCurrency;
                        break;
                    case "4":
                        numberEur -= valueCurrency;
                        valueCurrency *= eurRateToUsd;
                        numberUsd += valueCurrency;
                        break;
                    case "5":
                        numberEur -= valueCurrency;
                        valueCurrency *= usdRateToRub;
                        numberUsd += valueCurrency;                                                
                        break;
                    case "6":
                        numberEur -= valueCurrency;
                        valueCurrency *= usdRateToEur;
                        numberUsd += valueCurrency;                                                
                        break;                    
                }
                Console.WriteLine($"Ваш текущий баланс составляет: RUB:{numberRub}(руб.) EUR:{numberEur}(евро) USD:{numberUsd}(долларов)");
            }
            Console.WriteLine("Вы вышли из программы");
            
            Console.ReadKey();
        }
    }
}
