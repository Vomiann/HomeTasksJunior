using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson25_QueueShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> money = new Queue<int>();
            money.Enqueue(10);
            money.Enqueue(20);
            money.Enqueue(30);
            int cashAccount = 0;            
            
            while (money.Count != 0)
            {                
                cashAccount += money.Peek();
                Console.WriteLine($"Клиент, оплатил товар на сумму {money.Peek()} у.е., Ваш счет: {cashAccount} у.е.");
                money.Dequeue();

                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine($"Поздравляем! Очередь закончилась! Вы заработали: {cashAccount} у.е.");

            Console.ReadKey();
        }
    }
}
