using System;
using System.Collections.Generic;

namespace Lesson31_OOP___Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isQuit = false;
            int productId;
            string inputUser;

            Seller seller = new Seller();
            Player player = new Player();

            seller.AddProduct("Празднийчный колпак", "Головное украшение", 10, 3);
            seller.AddProduct("Венец дворфов", "Выступает в роли фонарика", 500, 2);
            seller.AddProduct("Зелье исцеления", "Полностью востанавливает здоровье", 100, 1);

            while (isQuit != true)
            {
                Console.WriteLine($"Ваши деньги: {player.Coins}");
                Console.WriteLine($"Деньги торговца: {seller.Coins}");
                Console.WriteLine();
                Console.WriteLine($"1 - Показать товары торговца");
                Console.WriteLine($"2 - Купить товар у торговца");
                Console.WriteLine($"3 - Посмотреть свои товары");
                Console.WriteLine($"4 - Выход из программы");
                Console.WriteLine();

                Console.Write("Выберете один из пунктов меню от 1 до 4: ");
                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case "1":
                        Console.WriteLine("Товары торговца: ");
                        seller.ShowProducts();
                        break;

                    case "2":
                        seller.ShowProducts();
                        Console.WriteLine();
                        Console.Write("Какой товар вы хотите купить? Укажите Ид товара: ");
                        productId = GetNumber();
                        seller.SellProductById(productId, player);
                        break;

                    case "3":
                        Console.WriteLine("Товары игрока:");
                        player.ShowProducts();
                        break;

                    case "4":
                        isQuit = true;
                        Console.WriteLine("Вы вышли из программы!");
                        break;

                    default:
                        Console.WriteLine("Выбранного пункта меню не существует. Укажите значение от 1 до 4");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }

            Console.ReadKey();
        }

        public static int GetNumber()
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

    public abstract class Character
    {
        private List<Product> _products;
        private Dictionary<int, int> _countProducts;
        private int _coinsToPay;
        private static int _productId;
        public int Coins { get; protected set; }

        public Character()
        {
            _products = new List<Product>();
            _countProducts = new Dictionary<int, int>();
        }

        public void AddProduct(string name, string description, int price, int amount)
        {
            if (CheckIsProductByName(name) == false)
            {
                _productId++;
            }
            AddProductWithId(_productId, name, description, price, amount);
        }

        public void ShowProducts()
        {
            if (_products.Count > 0)
            {
                foreach (var product in _products)
                {
                    int amountProduct = _countProducts[product.ProductId];
                    Console.WriteLine($"Id[{product.ProductId}], Имя товара: {product.Name}, Кол-во: {amountProduct}, Описание: {product.Description}, Цена (за 1ед.): {product.Price} монет.");
                }
            }
            else
            {
                Console.WriteLine("Товары отсутствуют!");
            }
        }

        public void SellProductById(int productId, Character character)
        {
            bool isProduct = false;
            int defaultCountProduct = 1;

            foreach (var product in _products)
            {
                if (product.ProductId == productId)
                {
                    isProduct = true;

                    if (_countProducts[productId] > defaultCountProduct)
                    {
                        Console.Write($"Какое кол-во '{product.Name}' вы планируете купить? (Введите число): ");
                        defaultCountProduct = Program.GetNumber();
                        CalculateCoins(product, character, defaultCountProduct);
                    }
                    else
                    {
                        CalculateCoins(product, character, defaultCountProduct);
                    }
                    break;
                }
            }

            if (isProduct == false)
            {
                Console.WriteLine("По указанному Ид товара не существует!");
            }
        }
        private bool CheckIsProductByName(string name)
        {
            bool isProduct = false;

            foreach (var product in _products)
            {
                if (product.Name == name)
                {
                    isProduct = true;
                }
            }

            return isProduct;
        }
        private void AddProductWithId(int identityProduct, string name, string description, int price, int amount)
        {
            if (GetProductIdByName(name) is int productId)
            {
                _countProducts[productId] += amount;
            }
            else
            {
                _countProducts.Add(identityProduct, amount);
                _products.Add(new Product(identityProduct, name, description, price));
            }
        }

        private void CalculateCoins(Product product, Character character, int defaultCountProduct)
        {
            if (defaultCountProduct <= _countProducts[product.ProductId] && defaultCountProduct > 0)
            {
                if (CheckSolvency(character, product, defaultCountProduct))
                {
                    character.Coins -= _coinsToPay;
                    _countProducts[product.ProductId] -= defaultCountProduct;
                    Coins += _coinsToPay;
                    character.AddProductWithId(product.ProductId, product.Name, product.Description, product.Price, defaultCountProduct);

                    Console.WriteLine($"Вы купили: {product.Name} в кол-ве {defaultCountProduct} шт.");
                }
                else
                {
                    Console.WriteLine("У вас недостаточно денег!");
                }
            }
            else
            {
                Console.WriteLine("Кол-во покупаемого товара не долждно быть больше или меньше того, что есть у торговца!");
            }
        }

        private bool CheckSolvency(Character character, Product product, int countProduct)
        {
            _coinsToPay = product.Price * countProduct;
            if (character.Coins >= _coinsToPay)
            {
                return true;
            }
            else
            {
                _coinsToPay = 0;
                return false;
            }
        }

        private int? GetProductIdByName(string name)
        {
            foreach (var product in _products)
            {
                if (product.Name == name)
                {
                    if (_countProducts.ContainsKey(product.ProductId) == true)
                    {
                        return product.ProductId;
                    }
                }
            }

            return null;
        }
    }
    public class Player : Character
    {
        public Player()
        {
            Coins = 500;
        }
    }

    public class Seller : Character
    {
        public Seller()
        {
            Coins = 1000;
        }
    }

    public class Product
    {
        public int ProductId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Price { get; private set; }

        public Product(int productId, string name, string description, int price)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
