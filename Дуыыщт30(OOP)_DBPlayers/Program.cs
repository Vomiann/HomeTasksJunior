using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson30_OOP__DBPlayers
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.ReadKey();  
        }
    }

    public class Player
    {
        public Player()
        {
            Id++;
        }

        public static int Id { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }
    }


    public class DataBasePlayers
    {
        public Player Player { get; private set; }


        

    }
}
