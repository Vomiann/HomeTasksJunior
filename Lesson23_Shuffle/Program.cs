using System;

namespace Lesson23_Shuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] array = new int[] { 1, 2, 3, 4, 5 };

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }

            Console.WriteLine();

            Shuffle(ref array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }

            Console.ReadKey();
        }


        static void Shuffle(ref int [] array)
        {
            Random random = new Random();
            int[] tempArray = new int[array.Length];

            int[] tempIndexArray = new int[array.Length];


            for (int i = 0; i < tempArray.Length; i++)
            {
                int rndIndex = random.Next(0, array.Length);

                if (tempArray[i] != array[rndIndex])
                {
                    tempArray[i] = array[rndIndex];
                }
            }
            array = tempArray;
        }
    }
}
