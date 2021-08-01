using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson27_PersonnelAccountingV2
{
    class Program
    {
        static void Main(string[] args)
        {            
            Dictionary<string, string> listDossier = new Dictionary<string, string>();
            string inputUser;
            bool isQuit = false;

            Console.WriteLine("1) Добавить досье ");
            Console.WriteLine("2) Вывести все досье (в одну строку через “-” фио и должность с порядковым номером в начале)");
            Console.WriteLine("3) Удалить досье");            
            Console.WriteLine("4) Выход ");
            Console.WriteLine();

            while (isQuit != true)
            {
                Console.Write("Введите один из пунктов меню (от 1 до 4): ");
                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case "1":
                        AddDossier(listDossier);
                        break;
                    case "2":
                        ShowDossiers(listDossier);
                        break;
                    case "3":
                        DeleteDossier(listDossier);
                        break;                    
                    case "4":
                        isQuit = true;
                        Console.WriteLine("Вы вышли из программы!");
                        break;
                    default:
                        Console.WriteLine("Выбранного пункта меню не существует. Укажите значение от 1 до 4");
                        break;
                }
            }
                     
            Console.ReadKey();
        }

        static void AddDossier(Dictionary<string, string> listDossier)
        {
            Console.Write("Введите Ф.И.О: ");
            string inputName = Console.ReadLine();

            Console.Write("Введите Должность: ");
            string inputPosition = Console.ReadLine();

            listDossier.Add(inputName, inputPosition);
        }

        static void ShowDossiers(Dictionary<string, string> listDossier)
        {           
            if (listDossier.Count > 0)
            {
                foreach (var dossier in listDossier)
                {
                    Console.WriteLine($"ФИО: {dossier.Key} Должность: {dossier.Value}");                   
                }
            }
            else
            {
                Console.WriteLine("Нет записей!");
            }
        }

        
        static void DeleteDossier(Dictionary<string, string> listDossier)
        {
            if (listDossier.Count > 0)
            {                
                Console.Write("Введите Ф.И.О. сотрудника для удаления: ");
                string inputUser = Console.ReadLine();

                if (listDossier.Remove(inputUser))
                {
                    Console.WriteLine("Досье удалено!");
                }
                else
                {
                    Console.WriteLine("Досье не может быть удалено! Указанной Ф.И.О. не существует!");
                }               
            }
            else
            {
                Console.WriteLine("Досье не созданы! Создайте досье!");
            }
        }
    }
}
