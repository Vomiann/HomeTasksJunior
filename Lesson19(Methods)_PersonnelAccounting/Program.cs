using System;
using System.Text;

namespace Lesson19_Methods__PersonnelAccounting
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayPositions = new string[0];
            string[] arrayNames = new string[0];
            string inputUser = string.Empty;
            string commandQuit = "5";

            Console.WriteLine("1) Добавить досье ");
            Console.WriteLine("2) Вывести все досье (в одну строку через “-” фио и должность с порядковым номером в начале)");
            Console.WriteLine("3) Удалить досье");
            Console.WriteLine("4) Поиск по фамилии");
            Console.WriteLine("5) Выход ");
            Console.WriteLine();

            while (inputUser != commandQuit)
            {
                Console.Write("Введите один из пунктов меню (от 1 до 5): ");
                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case "1":
                        CreateDossier(ref arrayPositions, ref arrayNames);
                        break;
                    case "2":
                        ReadAllDossiers(arrayPositions, arrayNames);
                        break;
                    case "3":
                        DeleteDossier(ref arrayPositions, ref arrayNames);
                        break;
                    case "4":
                        FindSurname(arrayNames);
                        break;
                    case "5":
                        Console.WriteLine("Вы вышли из программы!");
                        break;
                    default:
                        Console.WriteLine("Выбранного пункта меню не существует. Укажите значение от 1 до 5");
                        break;
                }
            }

            Console.ReadKey();
        }
        static void CreateDossier(ref string[] arrayPositions, ref string[] arrayNames)
        {
            Console.Write("Введите Ф.И.О: ");
            string inputUser = Console.ReadLine();
            string[] tempArrayNames = new string[arrayNames.Length + 1];
            tempArrayNames[tempArrayNames.Length - 1] = inputUser;

            for (int i = 0; i < arrayNames.Length; i++)
            {
                tempArrayNames[i] = arrayNames[i];
            }
            arrayNames = tempArrayNames;

            Console.Write("Введите Должность: ");
            inputUser = Console.ReadLine();

            string[] tempArrayPositions = new string[arrayPositions.Length + 1];
            tempArrayPositions[tempArrayPositions.Length - 1] = inputUser;

            for (int i = 0; i < arrayPositions.Length; i++)
            {
                tempArrayPositions[i] = arrayPositions[i];
            }
            arrayPositions = tempArrayPositions;
        }

        static void ReadAllDossiers(string[] arrayPositions, string[] arrayNames)
        {
            if (arrayPositions != null)
            {
                for (int i = 0; i < arrayNames.Length; i++)
                {
                    Console.WriteLine($"-[{i}] ФИО: {arrayNames[i]} Должность: {arrayPositions[i]}");
                }
            }
            else
            {
                Console.WriteLine("Нет записей!");
            }
        }

        static void FindSurname(string[] arrayNames)
        {
            Console.Write("Введите Фамилию: ");
            string inputUser = Console.ReadLine();
            bool isSurname = false;

            if (arrayNames != null)
            {
                for (int i = 0; i < arrayNames.Length; i++)
                {
                    if (inputUser.Contains(arrayNames[i]))
                    {
                        isSurname = true;
                        Console.WriteLine($"Результат поиска: {arrayNames[i]}");
                    }
                }
            }

            if (!isSurname)
            {
                Console.WriteLine("Фамилия не найдена!");
            }
        }

        static void DeleteDossier(ref string[] arrayPositions, ref string[] arrayNames)
        {
            arrayPositions = null;
            arrayNames = null;
            Console.WriteLine("Досье удалены!");
        }
    }
}
