using System;
using System.Collections.Generic;

namespace Lesson31_OOP___Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isQuit = false;
            string inputUser;

            //while (isQuit != true)
            //{
            //    Console.WriteLine($"{(int)MainMenu.} - Добавить игрока");

            //    Console.Write("Выберете один из пунктов меню от 1 до 6: ");
            //    int menuSection = GetNumber();

            //    switch (menuSection)
            //    {



            //        default:
            //            Console.WriteLine("Выбранного пункта меню не существует. Укажите значение от 1 до 6");
            //            break;
            //    }

            //}





            Console.ReadKey();
        }

        static int GetNumber()
        {
            int number = 0;
            bool isConverted = false;

            while (isConverted == false)
            {
                Console.Write("Введите число: ");
                string inputUser = Console.ReadLine();
                if (int.TryParse(inputUser, out number))
                {
                    isConverted = true;
                }
            }

            return number;
        }
    }

    public enum MainMenu
    {

    }

    public class Seller : Product
    {
        private List<Product> _products;
        private int _totalMoney;
        

        public Seller(Product product) : base(product., amount, description, price)
        {           


            _products = new List<Product>
            {
                

        //        protected string _name;
        //protected int _amount;
        //protected string _description;
        //protected int _price;



        //new Product("Празднийчный колпак", 3, "Головное украшение", 10),
        //new Product("Венец дворфов", 1, "Выступает в роли фонарика", 500),
        //new Product("Зелье исцеления", 2, "Полностью востанавливает здоровье", 100),
            };
        }



        public void ShowProducts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine($"Id[{product.}], Имя товара: {}, Кол-во: {}, Описание: {}, Цена: {} монет.");
            }
        }

        public void SellProduct()
        { 

        }
    }

    public class Player: Product
    {
        private List<Product> _products;
        private int _totalMoney;

        public void ShowProducts()
        {

        }
    }



    public class Product
    {
        private static int _productId;
        protected string _name;
        protected int _amount;
        protected string _description;
        protected int _price;

        public Product(string name, int amount, string description, int price)
        {
            _productId++;
            _name = name;
            _amount = amount;
            _description = description;
            _price = price;
        }   
    }

    //public class Product
    //{
    //    private static int _productId;
    //    private string _name;
    //    private int _amount;
    //    private string _description;
    //    private int _price;

    //    public Product(string name, int amount, string description, int price)
    //    {
    //        _productId++;
    //        _name = name;
    //        _amount = amount;
    //        _description = description;
    //        _price = price;
    //    }
    //}
}
