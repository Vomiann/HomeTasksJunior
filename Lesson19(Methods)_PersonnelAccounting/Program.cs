using System;
using System.Text;

namespace Lesson19_Methods__PersonnelAccounting
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] positions = new string[0];
            string[] names = new string[0];
            string inputUser = string.Empty;            
            bool isQuit = false;

            Console.WriteLine("1) Добавить досье ");
            Console.WriteLine("2) Вывести все досье (в одну строку через “-” фио и должность с порядковым номером в начале)");
            Console.WriteLine("3) Удалить досье");
            Console.WriteLine("4) Поиск по фамилии");
            Console.WriteLine("5) Выход ");
            Console.WriteLine();

            while (isQuit != true)
            {
                Console.Write("Введите один из пунктов меню (от 1 до 5): ");
                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case "1":
                        AddDossier(ref positions, ref names);
                        break;
                    case "2":
                        ReadAllDossiers(positions, names);
                        break;
                    case "3":
                        DeleteEmployee(ref positions, ref names);
                        break;
                    case "4":
                        SearchEmployee(names, positions);                        
                        break;
                    case "5":
                        isQuit = true;
                        Console.WriteLine("Вы вышли из программы!");                        
                        break;
                    default:
                        Console.WriteLine("Выбранного пункта меню не существует. Укажите значение от 1 до 5");
                        break;
                }
            }

            Console.ReadKey();
        }

        static string[] AddItemInArray(string value, string []array)
        {
            string[] tempArray = new string[array.Length + 1];
            tempArray[tempArray.Length - 1] = value;

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            array = tempArray;

            return array;
        }

        static void AddDossier(ref string[] positions, ref string[] names)
        {
            Console.Write("Введите Ф.И.О: ");
            string inputUser = Console.ReadLine();            
            names = AddItemInArray(inputUser, names);

            Console.Write("Введите Должность: ");
            inputUser = Console.ReadLine();
            positions = AddItemInArray(inputUser, positions);
        }

        static void ReadAllDossiers(string[] positions, string[] names)//TODO: убрать null
        {
            if (positions != null)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    Console.WriteLine($"-[{i}] ФИО: {names[i]} Должность: {positions[i]}");
                }
            }
            else
            {
                Console.WriteLine("Нет записей!");
            }
        }

        static void SearchEmployee(string[] names, string[] positions)
        {
            Console.Write("Введите Ф.И.О сотрудника: ");
            string inputUser = Console.ReadLine();
            bool employeeFound = false;

            for (int i = 0; i < names.Length; i++)
            {
                if (inputUser.Contains(names[i]))
                {
                    employeeFound = true;
                    Console.WriteLine($"Результат поиска: Сотрудник:{names[i]} Должность: {positions[i]}");
                }
            }
            
            if (employeeFound == false)
            {
                Console.WriteLine("Фамилия не найдена!");
            }
        }

        static void DeleteEmployee(ref string[] positions, ref string[] names)
        {
            Console.WriteLine("Введите Ф.И.О сотрудника для удаления: ");
            string inputUser = Console.ReadLine();

            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Contains(inputUser))
                {                    
                    names = AddItemInArray(names[i], new string[0]);
                    positions = AddItemInArray(positions[i], new string[0]);
                }
                else
                {

                }
            }


            Console.WriteLine("Досье удалены!");
        }
    }
}
