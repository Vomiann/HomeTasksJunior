using System;
using System.Collections.Generic;

namespace Lesson30_OOP__DBPlayers
{
    class Program
    {
        static void Main(string[] args)
        {
            Database dataBase = new Database();
            dataBase.AddPlayer("Anubis", 1);
            dataBase.AddPlayer("Vom", 1);
            dataBase.AddPlayer("Zeus", 1);
            dataBase.BanPlayerById(1);
            dataBase.BanPlayerById(1);
            dataBase.BanPlayerById(5);
            dataBase.ShowPlayers();
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
        public int UniqueId { get; set; }
        public string Nickname { get; set; }
        public int Level { get; set; }
        public bool IsBan { get; set; } = false;
    }


    public class Database
    {
        private static int _identityPlayer;
        private List<Player> _players = new List<Player>();

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

        public void ShowPlayers()
        {
            foreach (var player in _players)
            {
                Console.WriteLine($"Id[{player.UniqueId}], Ник: {player.Nickname}, Уровень: {player.Level}, Статус блокировки: {player.IsBan} ");
            }
        }

        public void AddPlayer(string nickName, int level)
        {
            _players.Add(new Player { UniqueId = _identityPlayer, Nickname = nickName, Level = level });
            Console.WriteLine($"Добавлен игрок: Id[{_identityPlayer}], Ник: {nickName}, Уровень: {level}, Статус блокировки: {false}");
            _identityPlayer++;
        }

        public void BanPlayerById(int playerId)
        {
            Player playerResult = FindPlayerById(playerId);

            if (playerResult != null && playerResult.IsBan == false)
            {
                Console.WriteLine($"Игрок {playerResult.Nickname} был забанен!");
                playerResult.IsBan = true;
            }
            else if(playerResult?.UniqueId == playerId && playerResult?.IsBan == true)
            {
                Console.WriteLine($"Игрок {playerResult.Nickname} уже был забанен!");
            }

            if (playerResult == null)
            {
                Console.WriteLine($"Игрока с Id[{playerId}] не существует!");
            }
        }

        public void UnbanPlayerById(int playerId)
        {
            Player playerResult = FindPlayerById(playerId);

            if (playerResult != null && playerResult.IsBan == true)
            {
                Console.WriteLine($"Игрок {playerResult.Nickname} был разбанен!");
                playerResult.IsBan = false;
            }
            else if(playerResult != null && playerResult?.IsBan == false)
            {
                Console.WriteLine($"Игрок {playerResult.Nickname} уже был разбанен!");
            }
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
    }
}
