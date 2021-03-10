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

            int countPeople;


            Console.WriteLine("Введите кол-во старушек:");


            // time result



            //Пользователь вводит кол - во людей в очереди.
            //Фиксированное время приема одного человека всегда равно 10 минутам.
            //Пример ввода: Введите кол-во старушек: 14
            //Пример вывода: "Вы должны отстоять в очереди 2 часа и 20 минут."

            Console.WriteLine($"Вы должны отстоять в очереди {} часа и {} минут.");

            Console.ReadKey();
        }
    }
}
