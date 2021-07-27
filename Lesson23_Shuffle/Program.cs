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
            int rndIndex;

            for (int i = 0; i < tempIndexArray.Length; i++)
            {
                rndIndex = random.Next(0, array.Length);

                if (CheckIndexInArray(tempIndexArray, rndIndex) == false)
                {
                    tempIndexArray[i] = rndIndex;
                }
                else
                {
                    if (tempIndexArray[i] == 0)
                    {
                        for (int j = 0; j < array.Length; j++)
                        {
                            if (tempIndexArray[i] != array[j] && CheckIndexInArray(tempIndexArray, j) == false)
                            {
                                tempIndexArray[i] = j;                                
                            }                            
                        }
                    }

                }
            }
                      
            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = array[tempIndexArray[i]];
            }

            array = tempArray;
        }

        static bool CheckIndexInArray(int[] array, int index)
        {
            bool isIndex = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == index)
                {
                    isIndex = true;
                }
            }
            return isIndex;
        }
    }
}
