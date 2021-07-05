using System;

namespace Lesson20_UIELEMENT
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 4;
            int maxHealth = 10;
            int mana = 5;
            int maxMana = 10;
            int healthPosX = 5;
            int HealthPosY = 5;
            int manaPosX = 5;
            int manaPosY = 6;
            char symbol = '_';

            DrawBar(health, maxHealth, ConsoleColor.Red, healthPosX, HealthPosY, symbol);
            DrawBar(mana, maxMana, ConsoleColor.Blue, manaPosX, manaPosY, symbol);

            Console.ReadKey();
        }

        static void DrawBar(int value, int maxValue, ConsoleColor color, int posX, int posY, char symbol)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            string bar = string.Empty;

            for (int i = 0; i < value; i++)
            {
                bar += symbol;
            }

            Console.SetCursorPosition(posX, posY);
            Console.Write("[");
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;
            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += symbol;
            }

            Console.Write(bar + ']');
        }
    }
}
