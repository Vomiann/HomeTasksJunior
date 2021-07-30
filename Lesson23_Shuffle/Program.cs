using System;

namespace Lesson23_Shuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };

            ShowArray(array);

            Console.WriteLine();

            Shuffle(array);

            ShowArray(array);

            Console.ReadKey();
        }


        static void ShowArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
        }

        static void Shuffle(int[] array)
        {
            Random random = new Random();
            int randomIndex;                        
            int tempValue;
            
            for (int i = 0; i < array.Length; i++)
            {
                randomIndex = random.Next(0, array.Length);

                if (array[i] != array[randomIndex])
                {
                    tempValue = array[randomIndex];
                    array[randomIndex] = array[i];
                    array[i] = tempValue;
                }
            }          
        }
    }
}
