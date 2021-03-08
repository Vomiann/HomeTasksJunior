using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson04_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int crystalCost = 5;
            int totalBuyCrystals = 0;
            bool enoughMoney;

            Console.Write("Введите начальное ко-во золота: ");                       
            int totalMoney = Convert.ToInt32(Console.ReadLine());
            Console.Write("Какое количество кристаллов вы хотите купить? Стоимость 1 кристалла 5 золота: ");
            int countCrystals = Convert.ToInt32(Console.ReadLine());

            enoughMoney = totalMoney >= countCrystals * crystalCost;

            countCrystals *= Convert.ToInt32(enoughMoney);
            
            totalMoney -= countCrystals * crystalCost;
            totalBuyCrystals += countCrystals;

            Console.WriteLine($"Итого золота:{totalMoney}");
            Console.WriteLine($"Итого кристаллов:{totalBuyCrystals}");

            Console.ReadKey();
        }
    }
}
