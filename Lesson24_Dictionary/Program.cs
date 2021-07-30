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
            listWords.Add("1","Слово01");
            listWords.Add("2", "Слово01");
            listWords.Add("3", "Слово01");

            Console.Write("Ввведите слово: ");
            string resultInput = Console.ReadLine();

            string result = FindWord(resultInput, listWords);

            Console.WriteLine($"{result}");


            Console.ReadKey();
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
                result = "По данному слову нет значений! Попробуйте ввесчти другое слово!";
            }

            return result;
        }
    }
}
