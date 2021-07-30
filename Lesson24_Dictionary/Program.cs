using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson24_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> listWords = new Dictionary<string, string>();
            listWords.Add("1", "Слово1");
            listWords.Add("2", "Слово2");
            listWords.Add("3", "Слово3");
            string exitWord = "exit";
            string resultInput = string.Empty;
            string resultWord;

            Console.WriteLine($"Для выхода из программы введите: {exitWord}");
            while (resultInput != exitWord)
            {
                Console.Write("Введите слово: ");
                resultInput = Console.ReadLine();
                if (resultInput != exitWord)
                {
                    resultWord = FindWord(resultInput, listWords);
                    ShowMessage(resultWord);
                }                               
            }

            Console.WriteLine("Вы вышли из программы!");

            Console.ReadKey();
        }


        static void ShowMessage (string message)
        {
            Console.WriteLine($"Результат: {message}");
        }

        static string FindWord(string value, Dictionary<string, string> collection)
        {
            string result = string.Empty;
            bool isResult = false;

            foreach (var item in collection)
            {
                if (item.Key == value)
                {
                   result = item.Value;
                   isResult = true;
                   break;
                }
            }

            if (isResult == false)
            {
                result = "По данному слову нет значений! Попробуйте ввести другое слово!";
            }

            return result;
        }
    }
}
