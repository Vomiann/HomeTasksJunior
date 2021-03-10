using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03_Images
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalImages = 52;
            int namberImagesRow = 3;

            int numberRowsPictures = totalImages / namberImagesRow;
            int picturesOutsideRows = totalImages - numberRowsPictures * namberImagesRow;

            Console.WriteLine($"Всего заполненных рядов картинок можно вывести: {numberRowsPictures}");
            Console.WriteLine($"Картинок сверх меры:{picturesOutsideRows}");
          
            Console.ReadKey();
        }
    }
}
