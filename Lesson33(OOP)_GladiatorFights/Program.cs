using System;
using System.Collections.Generic;

namespace Lesson33_OOP__GladiatorFights
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isQuit = false;
            string inputUser;
            Game game = new Game();

            Console.WriteLine($"Добро пожаловать на арену!");

            while (isQuit != true)
            {
                Console.WriteLine("Доступные бойцы:");
                game.ShowFighters();
                Console.WriteLine();
                Console.WriteLine($"1 - Начать бой!");
                Console.WriteLine($"2 - Выход из программы");
                Console.WriteLine();
                Console.Write("Выберете один из пунктов меню от 1 до 2: ");
                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case "1":
                        Console.Write("Выберете 1го бойца: ");
                        int firstFigterId = game.ChooseFirstFighter();
                        Console.Write("Выберете 2го бойца: ");
                        int secondFigterId = game.ChooseSecondFighter(firstFigterId);
                        game.StepsGame(firstFigterId, secondFigterId);
                        break;

                    case "2":
                        isQuit = true;
                        Console.WriteLine("Вы вышли из программы!");
                        break;

                    default:
                        Console.WriteLine("Выбранного пункта меню не существует. Укажите значение от 1 до 2");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
            Console.ReadKey();
        }
    }

    public abstract class Character
    {
        public int Level { get; protected set; }
        public string Name { get; protected set; }
        public float Health { get; protected set; }
        public float MaxHealth { get; protected set; }
        public float Armor { get; protected set; }
        public float DefaultDamage { get; protected set; }
        public float CurrentDamage { get; protected set; }
        public bool DamageBlocked { get; protected set; }
        public Ability Ability { get; protected set; }

        public void CalculateBattle(Character otherCharacter, ref DateTime _startTimeCharacterOne, ref DateTime _startTimeCharacterTwo, DateTime currentTime)
        {
            this.CurrentDamage = GetDamage(this, ref _startTimeCharacterOne, currentTime);
            otherCharacter.CurrentDamage = GetDamage(otherCharacter, ref _startTimeCharacterTwo, currentTime);

            CalculateHealth(this, otherCharacter.CurrentDamage);
            if (this.Health != Сonstants.NO_HEALTH)
            {
                CalculateHealth(otherCharacter, this.CurrentDamage);
            }
        }

        private float GetDamage(Character character, ref DateTime startTime, DateTime currentFightTime)
        {
            float attackСooldown = 0.0f;
            float damageResult;
            int digits = 2;

            double currentTimeResult = TimeSpan.FromTicks(currentFightTime.Ticks).TotalSeconds;
            double startTimeResult = TimeSpan.FromTicks(startTime.Ticks).TotalSeconds;
            double totalFightTime = currentTimeResult - startTimeResult;
            character.Ability.CurrentCooldown = Math.Round(character.Ability.DefaultCooldown - totalFightTime, digits);

            if (character.Ability.CurrentCooldown <= attackСooldown)
            {
                if (character.Ability.Name == Сonstants.SELF_MEDICATION)
                {
                    character.Ability.WasUsed = true;
                }
                else if (character.Ability.Name == Сonstants.SHADOW_STEALTH)
                {
                    character.Ability.WasUsed = true;
                }

                startTime = currentFightTime;
                damageResult = character.Ability.Damage;
                character.Ability.CurrentCooldown = character.Ability.DefaultCooldown;
                Console.WriteLine($"Персонаж [{character.Name}] использует свою способность '{character.Ability.Name}' с уроном в [{damageResult}] ед.");
            }
            else
            {
                damageResult = character.DefaultDamage;
                Console.WriteLine($"Способность '{character.Ability.Name}' у персонажа [{character.Name}] не готова!");
            }

            return damageResult;
        }

        private void CalculateHealth(Character character, float damage)
        {
            float healthResult = 0;

            if (character.Ability.Name == Сonstants.SELF_MEDICATION && character.Ability.WasUsed == true)
            {
                float healingResult = character.Health + character.Ability.Damage;
                float health = healingResult > character.MaxHealth ? character.MaxHealth : healingResult;
                healthResult = health - damage;

                Console.WriteLine($"[{character.Name}] исцеляет себя на: [{health}] ед. и атакует со способности в [{damage}] ед.");
                character.Ability.WasUsed = false;
            }
            else if (character.Ability.Name == Сonstants.SHADOW_STEALTH && character.Ability.WasUsed == true)
            {
                healthResult = character.Health;
            }
            else
            {
                healthResult = (character.Health + character.Armor) - damage;

                if (healthResult >= character.Health)
                {
                    healthResult = character.Health;
                    character.DamageBlocked = true;
                }
                else
                {
                    character.DamageBlocked = false;
                }
            }

            character.Health = healthResult >= Сonstants.NO_HEALTH ? healthResult : Сonstants.NO_HEALTH;
        }
    }

    public class Game
    {
        private DateTime _currentFightTime;
        private DateTime _startTimeCharacterOne;
        private DateTime _startTimeCharacterTwo;
        public Dictionary<int, Character> Fighters { get; private set; }

        public Game()
        {
            Fighters = new Dictionary<int, Character>
            {
                {1, new Wizard()    },
                {2, new Warrior()   },
                {3, new Priest()    },
                {4, new Assassin()  },
                {5, new Archer()    },
            };
        }

        public int ChooseFirstFighter()
        {
            int figterId;
            bool isFighter = false;

            do
            {
                figterId = GetNumber();
                isFighter = IsFighter(figterId);

            } while (isFighter == false);

            return figterId;
        }

        public int ChooseSecondFighter(int firstFighterId)
        {
            int secondFigterId;

            do
            {
                secondFigterId = ChooseFirstFighter();
                if (secondFigterId == firstFighterId)
                {
                    Console.WriteLine($"Не верно выбран боец! Первый боец не может вызвать себя на бой! Выберете другого бойца!");
                }
            } while (secondFigterId == firstFighterId);

            return secondFigterId;
        }

        public void ShowFighters()
        {
            foreach (var fighter in Fighters)
            {
                Console.WriteLine($"[{fighter.Key}] - {fighter.Value.Name}");
            }
        }

        public void StepsGame(int firstFighterId, int secondFighterId)
        {
            Character characterOne = Fighters[firstFighterId];
            Character characterTwo = Fighters[secondFighterId];

            _startTimeCharacterOne = DateTime.Now;
            _startTimeCharacterTwo = DateTime.Now;

            ShowInfoCharacter(characterOne, Сonstants.POSITION_FIRST_FIGTER_X, Сonstants.POSITION_FIRST_FIGTER_Y);
            ShowInfoCharacter(characterTwo, Сonstants.POSITION_SECOND_FIGTER_X, Сonstants.POSITION_SECOND_FIGTER_Y);
            Console.WriteLine();
            Console.WriteLine($"Время начала боя: {_startTimeCharacterOne.ToLongTimeString()}");            

            while (characterOne.Health > Сonstants.NO_HEALTH && characterTwo.Health != Сonstants.NO_HEALTH
                 || characterTwo.Health > Сonstants.NO_HEALTH && characterOne.Health != Сonstants.NO_HEALTH
                 || characterOne.Health != Сonstants.NO_HEALTH && characterTwo.Health != Сonstants.NO_HEALTH)
            {
                _currentFightTime = DateTime.Now;
                Console.WriteLine($"Текущее время боя: {_currentFightTime.ToLongTimeString()}");
                characterOne.CalculateBattle(characterTwo, ref _startTimeCharacterOne, ref _startTimeCharacterTwo, _currentFightTime);
                ShowBattleLog(characterOne, characterTwo);
                ShowBattleLog(characterTwo, characterOne);
                Console.WriteLine();
                System.Threading.Thread.Sleep(Сonstants.DELAY_BETWEEN_ATTACKS);
            }

            CheckWinner(characterOne, characterTwo);
            Fighters = new Dictionary<int, Character>
            {
                {1, new Wizard()    },
                {2, new Warrior()   },
                {3, new Priest()    },
                {4, new Assassin()  },
                {5, new Archer()    },
            };
        }

        private int GetNumber()
        {
            int number = 0;
            bool isConverted = false;

            while (isConverted == false)
            {
                Console.Write("Введите число: ");
                string inputUser = Console.ReadLine();
                if (int.TryParse(inputUser, out number))
                {
                    isConverted = true;
                }
            }
            return number;
        }
        private bool IsFighter(int fighterId)
        {
            bool isFighter = false;

            foreach (var fihter in Fighters)
            {
                if (fihter.Key == fighterId)
                {
                    isFighter = true;
                }
            }

            if (isFighter == false)
            {
                Console.WriteLine($"Бойца с номером: {fighterId} не существует! Выберете другого бойца!");
            }

            return isFighter;
        }

        private void ShowInfoCharacter(Character character, int positionX, int positionY)
        {
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine($"Класс: {character.Name}");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine($"Уровень: {character.Level}");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine($"Жизни: {character.Health} ед.");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine($"Броня: {character.Armor} ед.");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine($"Атака: {character.DefaultDamage} ед.");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine($"Способность: [{character.Ability.Name}]");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine($"Урон способности: [{character.Ability.Damage}] ед.");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine($"Время отката способности: [{character.Ability.DefaultCooldown}] сек.");
        }

        private void ShowBattleLog(Character characterOne, Character characterTwo)
        {
            Console.WriteLine($"Время отката способности у [{characterOne.Name}]: {characterOne.Ability.CurrentCooldown} сек.");
            if (characterTwo.Ability.Name == Сonstants.SHADOW_STEALTH && characterTwo.Ability.WasUsed == true)
            {
                characterTwo.Ability.WasUsed = false;
                Console.WriteLine($"[{characterTwo.Name}] в режиме невидимости не может быть атакован!");
            }
            else
            {
                Console.WriteLine($"[{characterOne.Name}] атакует [{characterTwo.Name}] с уроном в: [{characterOne.CurrentDamage - characterTwo.Armor}] ед.");
            }

            if (characterTwo.DamageBlocked == true)
            {
                Console.WriteLine($"Доспехи персонажа [{characterTwo.Name}] останавливают урон в размере [{characterOne.CurrentDamage}] ед! Урон заблокирован!");
            }
            Console.WriteLine($" Здоровье [{characterTwo.Name}] состваляет: [{characterTwo.Health}]");
        }

        private void CheckWinner(Character characterOne, Character characterTwo)
        {
            if (characterOne.Health == Сonstants.NO_HEALTH)
            {
                Console.WriteLine($"Побеждает: {characterTwo.Name}");
            }
            else if (characterTwo.Health == Сonstants.NO_HEALTH)
            {
                Console.WriteLine($"Побеждает: {characterOne.Name}");
            }
            else if (characterOne.Health == Сonstants.NO_HEALTH && characterTwo.Health == Сonstants.NO_HEALTH)
            {
                Console.WriteLine($"Ничья! Оба героя ({characterOne.Name},{characterTwo.Name}) умирают!");
            }
        }
    }

    public class Сonstants
    {
        public const int DELAY_BETWEEN_ATTACKS = 2000;
        public const int NO_HEALTH = 0;

        public const int POSITION_FIRST_FIGTER_X = 5;
        public const int POSITION_FIRST_FIGTER_Y = 17;
        public const int POSITION_SECOND_FIGTER_X = 45;
        public const int POSITION_SECOND_FIGTER_Y = 17;

        public const string FIRE_BALL = "Огненный шар";
        public const string CLEAVING_BLADE = "Рассекающий клинок";
        public const string SELF_MEDICATION = "Самолечение с атакой";
        public const string SHADOW_STEALTH = "Теневая атака";
        public const string FIREBOLT = "Огненная стрела";
    }

    public class Ability
    {
        public Ability(string name, int damage, double cooldown)
        {
            Name = name;
            Damage = damage;
            DefaultCooldown = cooldown;
            CurrentCooldown = cooldown;
            WasUsed = false;
        }

        public string Name { get; set; }
        public int Damage { get; set; }
        public double DefaultCooldown { get; set; }
        public double CurrentCooldown { get; set; }
        public bool WasUsed { get; set; }
    }

    public class Wizard : Character
    {
        public Wizard()
        {
            Level = 1;
            Name = "Wizard";
            Health = 100;
            MaxHealth = Health;
            Armor = 30;
            DefaultDamage = 50;
            Ability = new Ability(Сonstants.FIRE_BALL, 60, 10);
        }
    }

    public class Warrior : Character
    {
        public Warrior()
        {
            Level = 1;
            Name = "Warrior";
            Health = 100;
            MaxHealth = Health;
            Armor = 80;
            DefaultDamage = 25;
            Ability = new Ability(Сonstants.CLEAVING_BLADE, 45, 10);
        }
    }

    public class Priest : Character
    {
        public Priest()
        {
            Level = 1;
            Name = "Priest";
            Health = 100;
            MaxHealth = Health;
            Armor = 30;
            DefaultDamage = 20;
            Ability = new Ability(Сonstants.SELF_MEDICATION, 30, 10);
        }
    }

    public class Assassin : Character
    {
        public Assassin()
        {
            Level = 1;
            Name = "Assassin";
            Health = 100;
            MaxHealth = Health;
            Armor = 10;
            DefaultDamage = 60;
            Ability = new Ability(Сonstants.SHADOW_STEALTH, 70, 10);
        }
    }

    public class Archer : Character
    {
        public Archer()
        {
            Level = 1;
            Name = "Archer";
            Health = 100;
            MaxHealth = Health;
            Armor = 10;
            DefaultDamage = 55;
            Ability = new Ability(Сonstants.FIREBOLT, 60, 10);
        }
    }
}