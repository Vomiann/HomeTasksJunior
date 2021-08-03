using System;

namespace Lesson29_OOP__Prop
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Render draw = new Render();
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

    public class Render
    {
        public void DrawPlayer(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("@");
        }
    }
}
