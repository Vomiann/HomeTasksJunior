using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson14_FightWithBoss
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int spellHuganzakura = 100;
            int spellDamageRashamon = 100;
            int spellInterdimensionalRift = 250;
            bool isHuganzakura = false;
            bool isFractureStone = false;
            int damageSwordRashamon = 300;

            int healthBoss = 500;
            int attackBoss;

            int healthUser = 500;
            int maximumHealthUser = 500;
            string inputUser = string.Empty;

            Console.WriteLine("Добро пожаловать на бой с Боссом!");
            Console.WriteLine("Список ваших заклинаний:");
            Console.WriteLine($"1 - Рашамон: призывает теневого духа для нанесения атаки (Отнимает {spellDamageRashamon} хп игроку)");
            Console.WriteLine($"2 - Хуганзакура: Может быть выполнен только после призыва теневого духа, наносит {spellHuganzakura} ед. урона ");
            Console.WriteLine($"3 - Межпространственный разлом: позволяет скрыться в разломе и восстановить {spellInterdimensionalRift} хп. Урон босса по вам не проходит. Есть шанс получить камень разлома!");
            Console.WriteLine($"4 - Меч Рашамона: Создает огненный меч Рашамона, который наносит урон {damageSwordRashamon} ед. Необходим Теневой дух и камень разлома");

            while (healthBoss > 0 && healthUser > 0)
            {
                Console.WriteLine($"Здоровье Босса: {healthBoss}");
                Console.WriteLine($"Ваше здоровье: {healthUser}");
                Console.Write("Укажите заклинание (от 1 до 4): ");
                inputUser = Console.ReadLine();
                
                switch (inputUser)
                {
                    case "1":
                        healthUser -= spellDamageRashamon;
                        isHuganzakura = true;
                        attackBoss = random.Next(10, 50);
                        healthUser -= attackBoss;
                        Console.WriteLine($"Вы созадли заклинание Рашамон! Заклинание поглатило {spellDamageRashamon} ед. здоровья.");
                        Console.WriteLine($"Пока вы создавали заклинание, Босс атаковал вас на {attackBoss} ед.");
                        break;
                    case "2":
                        if (isHuganzakura)
                        {
                            healthBoss -= spellHuganzakura;
                            attackBoss = random.Next(50, 101);
                            healthUser -= attackBoss;
                            isHuganzakura = false;
                            Console.WriteLine($"Вы создали заклинание Хуганзакура и нанесли урон Боссу в {spellHuganzakura} ед.");
                            Console.WriteLine($"Получив урон, Босс ззацепил вас дубиной и нанес вам {attackBoss} урона");
                        }
                        else
                        {
                            attackBoss = random.Next(50, 151);
                            healthUser -= attackBoss;
                            Console.WriteLine("Заклинание не может быть выполнено! Призовите теневого духа (заклинание Рапшамон)");
                            Console.WriteLine($"Пока вы вспоминали правило выполнения заклинания, Босс атаковал вас на {attackBoss} ед.");
                        }
                        break;
                    case "3":
                        if (healthUser < maximumHealthUser)
                        {
                            int healthResult = healthUser + spellInterdimensionalRift;
                            if (healthResult > maximumHealthUser)
                            {
                                healthUser = maximumHealthUser;
                                Console.WriteLine($"Вы кастуете Межпространственный разлом и восполняете все жизни");
                                Console.WriteLine("Босс в недоумении пытается бить в слепую, но не наносит урон!");
                            }
                            else
                            {
                                healthUser += spellInterdimensionalRift;
                                Console.WriteLine($"Вы кастуете Межпространственный разлом и восполняете {spellInterdimensionalRift} ед. здоровья");
                                Console.WriteLine("Босс в недоумении пытается бить в слепую, но не наносит урон!");
                            }                                                        
                            isFractureStone = Convert.ToBoolean(random.Next(0, 2));
                            if (isFractureStone)
                            {
                                Console.Write("Выйдя из разлома в вашей ладони появляется небольшой камень разлома! Можно создать новое заклинание!");
                            }
                            else
                            {
                                Console.WriteLine("Выйдя из разлома в вашей ладони появляется небольшой светящийся камень, но летучая мышь сверху, выхватывает его из вашей руки!");
                            }
                        }
                        else
                        {
                            attackBoss = random.Next(50, 50);
                            healthUser -= attackBoss;
                            Console.WriteLine("Вы не можете использовать заклинание т.к. ваше здоровье не может быть выше текущего!");                            
                            Console.WriteLine($"Босс увидел, что вы пытаетесь создать заклинание, атакует вас и наносит {attackBoss} ед. урона");
                        }                                                
                        break;
                    case "4":
                        if (!isFractureStone || !isHuganzakura)
                        {
                            attackBoss = random.Next(50, 50);
                            healthUser -= attackBoss;

                            if (!isFractureStone)
                            {
                                Console.WriteLine("У вас нет Камня разлома!");
                            }
                            if (!isHuganzakura)
                            {
                                Console.WriteLine("У вас нет Теневого духа!");
                            }                                                        
                            Console.WriteLine($"Босс увидел, что вы пытаетесь создать заклинание, атакует вас и наносит {attackBoss} ед. урона");
                        }                        
                        else if (isFractureStone && isHuganzakura)
                        {
                            healthBoss -= damageSwordRashamon;
                            isFractureStone = false;
                            isHuganzakura = false;
                            Console.WriteLine($"Используя Теневого духа и камень разлома, Вы создаете Меч рашамона и наносите урон Боссу в {damageSwordRashamon} ед.");
                            Console.WriteLine("Скорость удара настолько быстра, что Босс не успевает нанести урон!");
                        }                                             
                        break;
                    default:
                        attackBoss = random.Next(50, 151);
                        healthUser -= attackBoss;
                        Console.WriteLine("Такого заклинания не существует! Укажите одно из указанных заклинаний!");
                        Console.WriteLine($"Покуа вы думали! Босс нанес вам урон в {attackBoss} ед.");
                        break;
                }
            }
            
            if (healthBoss <= 0 && healthUser > 0)
            {
                healthBoss = 0;
                Console.WriteLine("Поздравляем! Босс повержен!");
                Console.WriteLine($"Здоровье Босса: {healthBoss}");
                Console.WriteLine($"Ваше здоровье: {healthUser}");
            }
            else if (healthBoss > 0 && healthUser <= 0)
            {
                healthUser = 0;
                Console.WriteLine("Сожалеем. Вы погибли!");
                Console.WriteLine($"Здоровье Босса: {healthBoss}");
                Console.WriteLine($"Ваше здоровье: {healthUser}");
            }
            else if (healthBoss <= 0 && healthUser <= 0)
            {
                healthBoss = 0;
                healthUser = 0;
                Console.WriteLine("Умирая вы убили Босса! Память о вас будет навеки!");
                Console.WriteLine($"Здоровье Босса: {healthBoss}");
                Console.WriteLine($"Ваше здоровье: {healthUser}");
            }

            Console.WriteLine("Бой завершен!. Вы вышли из программы!");

            Console.ReadKey();
        }
    }
}
