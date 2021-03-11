using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson05_Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int onePersonTime = 10;         
            int oneHour = 60;
            int oneMinutes = 60;

            Console.Write("Введите кол-во старушек:");
            int numberOldLadies = Convert.ToInt32(Console.ReadLine());
                    
            int totalWaitingTime = numberOldLadies * onePersonTime;

            int waitingHours = totalWaitingTime / oneHour;
            int waitingMinutes = totalWaitingTime - waitingHours * oneMinutes;
             
            Console.WriteLine($"Вы должны отстоять в очереди {waitingHours} часа и {waitingMinutes} минут.");

            Console.ReadKey();
        }
    }
}
