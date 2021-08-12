using System;
using System.Collections.Generic;

namespace Lesson31_OOP___Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Seller seller = new Seller();
            Player player = new Player();

            seller.AddProduct("Празднийчный колпак", 3, "Головное украшение", 10);
            seller.AddProduct("Венец дворфов", 2, "Выступает в роли фонарика", 500);
            seller.AddProduct("Зелье исцеления", 1, "Полностью востанавливает здоровье", 100);

            ShowMainMenu(seller, player);
        }

        static void ShowMainMenu(Seller seller, Player player)
        {
            bool isQuit = false;
            int productId;
            string inputUser;

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

    public class Player : Product
    {
        private static int _productId;
        private int _coinsToPay;
        public int Coins { get; private set; }
        
        public Player()
        {
            Products = new List<Product>();
            Coins = 500;
        }

        public bool CheckSolvency(Product product, int countProduct)
        {
            _coinsToPay = product.Price * countProduct;
            if (Coins >= _coinsToPay)
            {
                return true;
            }
            else
            {
                _coinsToPay = 0;
                return false;
            }
        }

        public int ToPay()
        {
            Coins -= _coinsToPay;
            return _coinsToPay;
        }

        public override void AddProduct(string name, int amount, string description, int price)
        {            
            _identityProduct = _productId++;
            base.AddProduct(name, amount, description, price);            
        }        
    }

    public class Seller : Product
    {
        public int Coins { get; private set; }
        private int _defaultCountProduct;

        public Seller()
        {
            Products = new List<Product>();
            Coins = 1000;
        }

        public void SellProductById(int productId, Player player)
        {
            bool isProduct = false;
            _defaultCountProduct = 1;

            foreach (var product in Products)
            {
                if (product.ProductId == productId)
                {
                    isProduct = true;

                    if (product.Amount > _defaultCountProduct)
                    {
                        Console.Write($"Какое кол-во '{product.Name}' вы планируете купить? (Введите число): ");
                        _defaultCountProduct = Program.GetNumber();
                        CalculateCoins(product, player);
                    }
                    else
                    {
                        CalculateCoins(product, player);
                    }
                    break;
                }
            }

            if (isProduct == false)
            {
                Console.WriteLine("По указанному Ид товара не существует!");
            }
        }

        private void CalculateCoins(Product product, Player player)
        {
            if (_defaultCountProduct <= product.Amount && _defaultCountProduct > 0)
            {
                if (player.CheckSolvency(product, _defaultCountProduct))
                {
                    int coinsResult = player.ToPay();
                    RemoveAmountProduct(product, _defaultCountProduct);
                    Coins += coinsResult;
                    player.AddProduct(product.Name, _defaultCountProduct, product.Description, product.Price);
                    Console.WriteLine($"Вы купили: {product.Name} в кол-ве {_defaultCountProduct} шт.");
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
    }

    public class Product
    {        
        public int ProductId { get; protected set; }
        public string Name { get; protected set; }
        public int Amount { get; protected set; }
        public string Description { get; protected set; }
        public int Price { get; protected set; }
        public List<Product> Products { get; protected set; }

        protected static int _identityProduct;

        public virtual void AddProduct(string name, int amount, string description, int price)
        {
            if (AddProductByName(name, amount) == false)
            {
                Products.Add(new Product() { ProductId = _identityProduct, Name = name, Amount = amount, Description = description, Price = price });
                _identityProduct++;
            }
            else
            {
                Amount += amount;
            }
        }

        public void ShowProducts()
        {
            if (Products.Count > 0)
            {
                foreach (var product in Products)
                {
                    Console.WriteLine($"Id[{product.ProductId}], Имя товара: {product.Name}, Кол-во: {product.Amount}, Описание: {product.Description}, Цена (за 1ед.): {product.Price} монет.");
                }
            }
            else
            {
                Console.WriteLine("Товары отсутствуют!");
            }
        }

        protected void RemoveAmountProduct(Product product, int amount)
        {
            product.Amount -= amount;
        }
               
        private bool AddProductByName(string name, int amount)
        {
            bool isProduct = false;

            foreach (var product in Products)
            {
                if (product.Name == name)
                {
                    isProduct = true;                    
                    product.Amount += amount;
                }
            }
            return isProduct;
        }
    }
}
