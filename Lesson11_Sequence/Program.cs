using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberStep = 7;            
            int totalNumber = 98;           

            for (int i= 7; i <= totalNumber; i+= numberStep)
            {                
                Console.Write(i + " ");                
            }
            Console.ReadKey();
        }
    }
}
