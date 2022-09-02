using System;
using System.Collections.Generic;

namespace HomeWork_6_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();
        }
    }

    class Aquarium
    {
        private List<Fish> _fishs;
        private int _maxCount;

        public Aquarium()
        {
            _fishs = new List<Fish>();
            _maxCount = SetCapacityAquarium();
        }

        private void Start()
        {
            Console.WriteLine("Выбирите пункт меню: ");
        }
        private void AddFish()
        {
            const int CommandAddGuppy = 1;
            const int CommandAddGoldFish = 2;
            const int CommandAddLabeo = 3;
            const int CommandAddBarbus = 4;

            Console.Write("Выбирите рыбку которую хотите добавить в аквариум: ");
            Console.WriteLine($"{CommandAddGuppy}. Гуппи ");
            Console.WriteLine($"{CommandAddGoldFish}. Золотая рыбка ");
            Console.WriteLine($"{CommandAddLabeo}. Лабео ");
            Console.WriteLine($"{CommandAddBarbus}. Барбус ");
            int userInput = GetNumber();

            if (_fishs.Count < _maxCount)
            {
                switch (userInput)
                {
                    case CommandAddGuppy:
                        _fishs.Add(new Guppy());
                        break;

                    case CommandAddGoldFish:
                        _fishs.Add(new GoldFish());
                        break;

                    case CommandAddLabeo:
                        _fishs.Add(new Labeo());
                        break;

                    case CommandAddBarbus:
                        _fishs.Add(new Barbus());
                        break;

                    default:
                        Console.WriteLine("Такой рыбки нету !");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Нет места в аквариуме");
                Console.ReadLine();
            }
        }

        private void RemoveFish()
        {
            int index;
            Console.WriteLine("Введите номер рыбки для её удаления: ");
            index = GetNumber();
            _fishs.RemoveAt(index - 1);
        }

        private void GrowAllFishs()
        {
            foreach (Fish fish in _fishs)
            {
                if (fish.IsAlive == true)
                {
                    fish.GrowAge();
                }
                else
                {
                    _fishs.Remove(fish);
                    Console.WriteLine($"Рыбка умерла: {fish.Name}");
                }
            }
        }

        private int GetNumber()
        {
            bool isWork = true;

            while (isWork)
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int number))
                {
                    isWork = false;
                    return number;
                }
                else
                {
                    Console.WriteLine("Попробуйте ещё раз!");
                    isWork = true;
                }
            }
            return 0;
        }

        private int SetCapacityAquarium()
        {
            const string CommandExit = "exit";
            bool IsWork = true;
            Console.Write("Введите емкость аквариума или exit для выхода:");

            while (IsWork)
            {
                string userInput = Console.ReadLine();

                switch (userInput.GetType().Name)
                {
                    case CommandExit:
                        IsWork = false;
                        break;

                    case "Int32":
                        return GetNumber();

                    default:
                        Console.WriteLine("Поробуйте ещё раз!");
                        break;
                }
            }
            return 0;
        }
        private void ShowAllFishs()
        {
            int index = 0;

            Console.WriteLine("Рыбки:");

            foreach (Fish fish in _fishs)
            {
                index++;
                Console.WriteLine($"{fish.Name} - {fish.Age}");
            }
        }
    }

    abstract class Fish
    {
        public bool IsAlive => Age > _maxAge;

        protected int _maxAge;

        public int Age { get; protected set; }
        public string Name { get; protected set; }

        public Fish()
        {
            Age = 0;
            _maxAge = 1;
        }

        public void GrowAge() => Age++;
    }

    class GoldFish : Fish
    {
        public GoldFish()
        {
            int minAge = 15;
            int maxAge = 20;
            Random random = new Random();
            _maxAge = random.Next(minAge, maxAge);
            Name = "Золотая рыбка";
        }
    }

    class Barbus : Fish
    {
        public Barbus()
        {
            int minAge = 5;
            int maxAge = 7;
            Random random = new Random();
            _maxAge = random.Next(minAge, maxAge);
            Name = "Барбус";
        }
    }

    class Labeo : Fish
    {
        public Labeo()
        {
            int minAge = 7;
            int maxAge = 10;
            Random random = new Random();
            _maxAge = random.Next(minAge, maxAge);
            Name = "Лабео";
        }
    }

    class Guppy : Fish
    {
        public Guppy()
        {
            Random random = new Random();
            int minAge = 10;
            int maxAge = 15;
            _maxAge = random.Next(minAge, maxAge);
            Name = "Гуппи";
        }
    }
}





