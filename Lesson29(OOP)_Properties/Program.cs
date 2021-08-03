using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson29_OOP__Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Draw draw = new Draw();
            draw.DrawPlayer(player.X, player.Y);

            Console.ReadKey();
        }
    }

    public class Player
    {
        public Player()
        {
            X = 10;
            Y = 5;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

    }

    public class Draw
    {        
        public void DrawPlayer(int x, int y)
        {
            Console.SetCursorPosition(x,y);
            Console.WriteLine("Player");
        }
    }
}
