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
            int[] money = new int[] { 10, 20, 30 };
            int indexMoney = 0;
            int cashAccount = 0;            
            Queue<string> clients = new Queue<string>();
            clients.Enqueue("Александр");
            clients.Enqueue("Виталик");
            clients.Enqueue("Дима");
            clients.Enqueue("Бомжик");

            while (clients.Count != 0)
            {
                if (money.Length > indexMoney)
                {
                    cashAccount += money[indexMoney];
                    Console.WriteLine($"Клиент: {clients.Peek()}, оплатил товар на сумму {money[indexMoney]} у.е., Ваш счет: {cashAccount} у.е.");                    
                    indexMoney++;
                }
                else
                {
                    Console.WriteLine($"У клиента {clients.Peek()} не оказалось денег! Ваш счет: {cashAccount} у.е.");
                }                
                clients.Dequeue();

                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine($"Поздравляем! Очередь закончилась! Вы заработали: {cashAccount} у.е.");

            Console.ReadKey();
        }
    }
}
