using System;
using System.Collections.Generic;

namespace Lesson32_OOP__ConfigPassengerTrains
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isQuit = false;
            string inputUser;
            RailwayStation railwayStation = new RailwayStation();
            

            while (isQuit != true)
            {
                //Console.WriteLine($"Ваши деньги: {player.Coins}");
                Console.WriteLine($"Текущий рейс: ");
                Console.WriteLine();
                Console.WriteLine($"1 - Составить план поезда!");                
                Console.WriteLine($"2 - Выход из программы");
                Console.WriteLine();

                Console.Write("Выберете один из пунктов меню от 1 до 2: ");
                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case "1":
                        Console.WriteLine("Создать план поезда");
                        railwayStation.CreateTrainPlan();
                        break;

                    case "2":
                        isQuit = true;
                        Console.WriteLine("Вы вышли из программы!");
                        break;

                    default:
                        Console.WriteLine("Выбранного пункта меню не существует. Укажите значение от 1 до 2");
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

    public class RailwayStation
    {
        public Train Train { get; private set; }
        public Dictionary<int, string> TrainRoutes { get; private set; }
                


        public RailwayStation()
        {
            Train = new Train("Бийск - Барнаул");
        }

        public void ShowTrainDirections()
        {
            Console.WriteLine("Доступные направления поездов:");

            foreach (var trainRoute in TrainRoutes)
            {
                Console.WriteLine($"[{trainRoute.Key}]-{trainRoute.Value}");
            }
        }

        public void CreateTrainPlan()
        {
            //1. -Создать направление - создает направление для поезда(к примеру Бийск - Барнаул)
            CreateRouteTrain();


            //2. -Продать билеты - вы получаете рандомное кол-во пассажиров, которые купили билеты на это направление
            // 3-Сформировать поезд - вы создаете поезд и добавляете ему столько вагонов(вагоны могут быть разные по вместительности), сколько хватит для перевозки всех пассажиров.
            // 4-Отправить поезд - вы отправляете поезд, после чего можете снова создать направление.
        }

        //1 -Создать направление - создает направление для поезда(к примеру Бийск - Барнаул)
        private void CreateRouteTrain()
        {
            Console.Write("");
            ShowTrainDirections();

            //GetNumber



        }

        //2 -Продать билеты - вы получаете рандомное кол-во пассажиров, которые купили билеты на это направление
        private void SellTikets()
        {
            Random random = new Random();



        }


        // 3-Сформировать поезд - вы создаете поезд и добавляете ему столько вагонов(вагоны могут быть разные по вместительности), сколько хватит для перевозки всех пассажиров.
        private void CreateTrain()
        { 

        }


        // 4-Отправить поезд - вы отправляете поезд, после чего можете снова создать направление.
        private void SendTrain ()
        { 

        }

    }


    public class Train
    {

        public Train(string route)
        {
            Route = route;
        }
        
        public string Route { get; private set; }
        public int CountWagons { get; private set; }
        public Wagon Wagons { get; private set; }

    }

    public class Wagon
    {
        public int Number { get; private set; }

        public int NumberSeats { get; private set; }

    }


    public class Passengers
    {

    }  



}
