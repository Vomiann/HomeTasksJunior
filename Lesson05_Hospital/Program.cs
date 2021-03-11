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
            int onePersonReceptionTimeInMinutes = 10;         
            int oneHourInMinutes = 60;
            int oneMinutes = 60;

            Console.Write("Введите кол-во старушек:");
            int numberOldLadies = Convert.ToInt32(Console.ReadLine());
                    
            int totalWaitingTimeInMinutes = numberOldLadies * onePersonReceptionTimeInMinutes;
            float waitingTimeInHours = Convert.ToSingle(totalWaitingTimeInMinutes) / oneHourInMinutes;
            float waitingTimeInMinutes = (waitingTimeInHours - totalWaitingTimeInMinutes / oneHourInMinutes) * oneMinutes; 

            Console.WriteLine($"Вы должны отстоять в очереди {waitingTimeInHours.ToString("#")} часа и {waitingTimeInMinutes.ToString()} минут.");

            Console.ReadKey();
        }
    }
}
