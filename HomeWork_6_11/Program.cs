using System;
using System.Collections.Generic;

namespace HomeWork_6_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();
            aquarium.Start();
        }
    }

    class Aquarium
    {
        private List<Fish> _fishes;
        private int _maxCount;

        public Aquarium()
        {
            _fishes = new List<Fish>();
            _maxCount = SetCapacityAquarium();
        }

        public void Start()
        {
            const string CommandAddFish = "1";
            const string CommandRemoveFish = "2";
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                ShowAllFishs();
                Console.WriteLine();
                Console.WriteLine("Выбирите пункт меню: ");
                Console.WriteLine($"{CommandAddFish}.Добавить рыбку в аквариум");
                Console.WriteLine($"{CommandRemoveFish}.Удалить рыбку из акавариума");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddFish:
                        AddFish();
                        break;

                    case CommandRemoveFish:
                        RemoveFish();
                        break;

                    default:
                        Console.WriteLine("Введена неверная команда !");
                        break;
                }
                GrowAllFishs();
            }
        }

        private void AddFish()
        {
            const int CommandAddGuppy = 1;
            const int CommandAddGoldFish = 2;
            const int CommandAddLabeo = 3;
            const int CommandAddBarbus = 4;

            Console.Clear();
            Console.WriteLine("Выбирите рыбку которую хотите добавить в аквариум: ");
            Console.WriteLine($"{CommandAddGuppy}. Гуппи ");
            Console.WriteLine($"{CommandAddGoldFish}. Золотая рыбка ");
            Console.WriteLine($"{CommandAddLabeo}. Лабео ");
            Console.WriteLine($"{CommandAddBarbus}. Барбус ");
            int userInput = UserUtils.GetNumber();

            if (_fishes.Count < _maxCount)
            {
                switch (userInput)
                {
                    case CommandAddGuppy:
                        _fishes.Add(new Guppy());
                        break;

                    case CommandAddGoldFish:
                        _fishes.Add(new GoldFish());
                        break;

                    case CommandAddLabeo:
                        _fishes.Add(new Labeo());
                        break;

                    case CommandAddBarbus:
                        _fishes.Add(new Barbus());
                        break;

                    default:
                        Console.WriteLine("Такой рыбки нету !");
                        Console.ReadLine();
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
            index = UserUtils.GetNumber();
            _fishes.RemoveAt(index - 1);
        }

        private void GrowAllFishs()
        {
            if (_fishes.Count > 0)
            {
                for ( int i = 0; i < _fishes.Count; i++)
                {
                    if (_fishes[i].IsAlive == true)
                    {
                        _fishes[i].GrowAge();
                    }
                    else
                    {
                        Console.WriteLine($"Рыбка умерла: {_fishes[i].Name}");
                        _fishes.Remove(_fishes[i]);
                        Console.ReadLine();
                    }
                }
            }
        }

        private int SetCapacityAquarium()
        {
            Console.Write("Введите емкость аквариума: ");
            int userInput = UserUtils.GetNumber();
            return userInput;
        }

        private void ShowAllFishs()
        {
            int index = 0;

            Console.WriteLine("Рыбки:");

            foreach (Fish fish in _fishes)
            {
                index++;
                Console.WriteLine($"{fish.Name} - {fish.Age}");
            }
        }
    }

    abstract class Fish
    {
        public bool IsAlive => Age < _maxAge;
        public int Age { get; protected set; }
        public string Name { get; protected set; }
        protected int _maxAge;

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

    static class UserUtils { 
        public static int GetNumber()
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
    }
}





