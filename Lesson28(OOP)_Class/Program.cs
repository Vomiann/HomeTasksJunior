using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson28_OOP__Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Алекс", 25 , "Муж");
            player.ShowInfo();

            Console.ReadKey();
        }
    }

    public class Player
    {
        private string _name;
        private int _age;
        private string _gender;

        public Player(string Name, int Age, string Gender)
        {
            _name = Name;
            _age = Age;
            _gender = Gender;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Имя игрока: {_name}, Возраст:{_age}, Пол:{_gender}");
        }
    }

}
