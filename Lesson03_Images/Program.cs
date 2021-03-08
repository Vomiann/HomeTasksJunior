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
            int pictureHeight = 4;
            int pictureWidth = 4;
            int specialScreenAreaHeight = 12;            
            int specialScreenAreaWidth = 12;
                     
            Console.WriteLine($"Всего картинок:{totalImages}");
            Console.WriteLine($"Высота картинки: {pictureHeight}, Ширина картинки:{pictureWidth}");
            Console.WriteLine($"Специальная область экрана, где выводятся картинки имеет Высоту: {specialScreenAreaHeight} и Ширину: {specialScreenAreaWidth}");

            int areaOneImage = pictureHeight * pictureWidth;
            int areaOneRow = areaOneImage * namberImagesRow;
            int imagesOutputArea = specialScreenAreaHeight * specialScreenAreaWidth;
            
            Console.WriteLine($"Всего заполненных рядов картинок можно будет вывести: {imagesOutputArea / areaOneRow}");
            Console.WriteLine($"Общее кол-во картинок за пределами области вывода:{ ((areaOneImage * totalImages) - imagesOutputArea) / areaOneImage }");

            Console.ReadKey();
        }
    }
}
