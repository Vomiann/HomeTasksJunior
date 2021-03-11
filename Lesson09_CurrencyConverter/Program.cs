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


            float rubRate = 0;
            float eurRate = 0;
            float usdRate = 0;

            // из рублей в доллары
            float convertToUsdFrom;
            // из рублей в евро
            float convertRubToUsd;

            // из евро в рубли
            // из евро в доллары

            // из долларов в рубли
            // из долларов в евро



            Console.WriteLine($"Здравствуйте! Ваш текущий баланс составляет: RUB:{numberRub}(руб.) EUR:{numberEur}(евро) USD:{numberUsd}(долларов)");

            Console.WriteLine("Укажите цифру");

            Console.WriteLine("1 - Сконвертировать RUB в USD");
            Console.WriteLine("2 - Сконвертировать RUB в EUR");
            Console.WriteLine("3 - Сконвертировать EUR в RUB");
            Console.WriteLine("4 - Сконвертировать EUR в USD");
            Console.WriteLine("5 - Сконвертировать USD в RUB");
            Console.WriteLine("6 - Сконвертировать USD в EUR");


            switch (switch_on)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                default:
                    break;
            }


            Console.ReadKey();
        }
    }
}
