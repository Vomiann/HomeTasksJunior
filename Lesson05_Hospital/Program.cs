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
            int servicePersonTime = 10;                     
            
            Console.Write("Введите кол-во старушек:");
            int numberOldLadies = Convert.ToInt32(Console.ReadLine());
                    
            int totalWaitingTime = numberOldLadies * servicePersonTime;
            int waitingHours = totalWaitingTime / 60;
            int waitingMinutes = totalWaitingTime % 60;

            Console.WriteLine($"Вы должны отстоять в очереди {waitingHours} часа и {waitingMinutes} минут.");

            Console.ReadKey();
        }
    }
}
