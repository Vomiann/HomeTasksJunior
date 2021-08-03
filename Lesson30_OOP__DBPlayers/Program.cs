using System;
using System.Collections.Generic;

namespace Lesson30_OOP__DBPlayers
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            dataBase.AddPlayer("Anubis", 1);
            dataBase.AddPlayer("Vom", 1);
            dataBase.AddPlayer("Zeus", 1);
            dataBase.BannedPlayerById(1);
            dataBase.BannedPlayerById(1);
            dataBase.BannedPlayerById(5);
            dataBase.DeletePlayerByNickname("Test");
            dataBase.UnbanPlayerById(1);
            dataBase.UnbanPlayerById(1);
            dataBase.DeletePlayerByNickname("Test2");
            dataBase.UnbanPlayerById(-1);
            dataBase.DeletePlayerByNickname("Zeus");

            dataBase.ShowPlayers();

            Console.ReadKey();
        }
    }

    public class Player
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public int Level { get; set; }
        public bool IsBanned { get; set; } = false;
    }


    public class DataBase
    {
        public static int IdentityPlayer { get; private set; }
        public List<Player> Players { get; private set; } = new List<Player>();


        public void ShowPlayers()
        {
            foreach (var player in Players)
            {
                Console.WriteLine($"Id[{player.Id}], Ник:{player.Nickname}, Уровень:{player.Level}, Статус блокировки:{player.IsBanned} ");
            }
        }

        public void AddPlayer(string nickName, int level)
        {
            Players.Add(new Player { Id = IdentityPlayer, Nickname = nickName, Level = level });
            Console.WriteLine($"Добавлен игрок: Id[{IdentityPlayer}], Ник:{nickName}, Уровень:{level}, Статус блокировки:{false}");
            IdentityPlayer++;
        }

        public void BannedPlayerById(int playerId)
        {
            foreach (var player in Players)
            {
                if (player.Id == playerId && player.IsBanned == false)
                {
                    Console.WriteLine($"Игрок {player.Nickname} был забанен!");
                    player.IsBanned = true;
                }
                else
                {
                    if (player.Id == playerId && player.IsBanned == true)
                    {
                        Console.WriteLine($"Игрок {player.Nickname} уже был забанен!");
                    }
                }
            }

            if (playerId > Players.Count - 1 || playerId < 0)
            {
                Console.WriteLine($"Игрока с Id[{playerId}] не существует!");
            }

        }

        public void UnbanPlayerById(int playerId)
        {
            foreach (var player in Players)
            {
                if (player.Id == playerId && player.IsBanned == true)
                {
                    Console.WriteLine($"Игрок {player.Nickname} был разбанен!");
                    player.IsBanned = false;
                }
                else
                {
                    if (player.Id == playerId && player.IsBanned == false)
                    {
                        Console.WriteLine($"Игрок {player.Nickname} уже был разбанен!");
                    }
                }
            }

            if (playerId > Players.Count - 1 || playerId < 0)
            {
                Console.WriteLine($"Игрока с Id[{playerId}] не существует!");
            }
        }

        public void DeletePlayerByNickname(string nickname)
        {
            bool isNickname = false;

            foreach (var player in Players)
            {
                if (player.Nickname == nickname)
                {
                    Players.Remove(player);
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
    }
}
