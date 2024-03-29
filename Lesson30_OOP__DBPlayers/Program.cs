﻿using System;
using System.Collections.Generic;

namespace Lesson30_OOP__DBPlayers
{
    class Program
    {
        static void Main(string[] args)
        {            
            Database dataBase = new Database();
            ShowMainMenu(dataBase);           
        }

        static void ShowMainMenu(Database dataBase)
        {
            bool isQuit = false;
            int levelResult;
            int playerId;
            string nickNameResult;                                              

            while (isQuit != true)
            {                
                Console.WriteLine($"1 - Добавить игрока");
                Console.WriteLine($"2 - Показать всех игроков");
                Console.WriteLine($"3 - Забанить игрока по ИД");
                Console.WriteLine($"4 - Разбанить игрока по ИД");
                Console.WriteLine($"5 - Удалить игрока по нику");
                Console.WriteLine($"6 - Выход из программы");
                Console.WriteLine();

                Console.Write("Выберете один из пунктов меню от 1 до 6: ");
                int menuSection = GetNumber();

                switch (menuSection)
                {
                    case 1:                        
                        Console.Write("Введите Ник игрока: ");
                        nickNameResult = Console.ReadLine();

                        Console.Write("Введите уровень игрока: ");
                        levelResult = GetNumber();

                        dataBase.AddPlayer(nickNameResult, levelResult);
                        break;

                    case 2:                        
                        dataBase.ShowPlayers();                        
                        break;

                    case 3:                        
                        Console.Write("Укажите Ид игрока чтобы его забанить: ");
                        playerId = GetNumber();
                        dataBase.BanPlayerById(playerId);
                        break;

                    case 4:                        
                        Console.Write("Укажите Ид игрока чтобы его разбанить: ");
                        playerId = GetNumber();
                        dataBase.UnbanPlayerById(playerId);
                        break;

                    case 5:                        
                        Console.Write("Введите Ник игрока для его удаления: ");
                        nickNameResult = Console.ReadLine();
                        dataBase.DeletePlayerByNickname(nickNameResult);
                        break;

                    case 6:
                        isQuit = true;
                        Console.WriteLine("Вы вышли из программы!");
                        break;

                    default:                        
                        Console.WriteLine("Выбранного пункта меню не существует. Укажите значение от 1 до 6");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();                
                Console.Clear();
            }
        }

        static int GetNumber()
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
    }
      
    public class Player
    {
        private int _level;
        public int UniqueId { get; private set; }
        public string Nickname { get; private set; }        
        public bool IsBan { get; private set; }

        public Player(int uniqueId, string nickname, int level)
        {
            UniqueId = uniqueId;
            Nickname = nickname;
            _level = level;
            IsBan = false;
        }

        public void ShowPlayer()
        {
            Console.WriteLine($"Id[{UniqueId}], Ник: {Nickname}, Уровень: {_level}, Статус блокировки: {IsBan}");
        }

        public void ChangeFieldIsBan(bool value)
        {
            IsBan = value;
        }        
    }

    public class Database
    {
        private static int _identityPlayer;
        private List<Player> _players;        
        
        public Database()
        {            
            _players = new List<Player>();
        }
               
        public void ShowPlayers()
        {
            if (_players.Count > 0)
            {
                foreach (var player in _players)
                {
                    player.ShowPlayer();
                }
            }
            else
            {
                Console.WriteLine("Нет добавленных игроков! Добавьте хотя бы 1 игрока!");
            }
        }

        public void AddPlayer(string nickName, int level)
        {            
            _players.Add(new Player(_identityPlayer, nickName, level));            
            Console.WriteLine($"Добавлен игрок: Id[{_identityPlayer}], Ник: {nickName}, Уровень: {level}, Статус блокировки: {false}");
            _identityPlayer++;
        }
        
        public void BanPlayerById(int playerId)
        {
            ToggleStatus(playerId, "забанен");
        }

        public void UnbanPlayerById(int playerId)
        {
            ToggleStatus(playerId, "разбанен");            
        }

        public void DeletePlayerByNickname(string nickname)
        {
            bool isNickname = false;

            foreach (var player in _players)
            {
                if (player.Nickname == nickname)
                {
                    _players.Remove(player);
                    Console.WriteLine($"Игрок {player.Nickname}, был удален!");
                    isNickname = true;
                    break;
                }
            }

            if (isNickname == false)
            {
                Console.WriteLine($"Игрока с Ником [{nickname}] не существует. Его не возможно удалить!");
            }
        }

        private Player FindPlayerById(int playerId)
        {
            foreach (var player in _players)
            {
                if (player.UniqueId == playerId)
                {
                    return player;
                }
            }

            return null;
        }

        private void ToggleStatus(int playerId, string message)
        {
            Player playerResult = FindPlayerById(playerId);

            if (playerResult != null)
            {
                if (playerResult.IsBan == false && message == "забанен")
                {
                    Console.WriteLine($"Игрок {playerResult.Nickname} был {message}!");
                    playerResult.ChangeFieldIsBan(true);
                }
                else if (playerResult.IsBan == true && message == "забанен")
                {
                    Console.WriteLine($"Игрок {playerResult.Nickname} уже был {message}!");
                }
                else if (playerResult.IsBan == true && message == "разбанен")
                {
                    Console.WriteLine($"Игрок {playerResult.Nickname} был {message}!");
                    playerResult.ChangeFieldIsBan(false);
                }
                else if (playerResult.IsBan == false && message == "разбанен")
                {
                    Console.WriteLine($"Игрок {playerResult.Nickname} уже был {message}!");
                }
            }

            if (playerResult == null)
            {
                Console.WriteLine($"Игрока с Id[{playerId}] не существует!");
            }
        }
    }
}
