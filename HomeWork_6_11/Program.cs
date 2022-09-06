using System;
using System.Collections.Generic;

namespace HomeWork_6_11
{
    internal static class UserUtils
    {
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
                }
            }
            return 0;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();
            aquarium.Start();
        }
    }

    internal class Aquarium
    {
        private List<Fish> _fishes;
        private int _maxCount;

        public Aquarium()
        {
            _fishes = new List<Fish>();
            _maxCount = GetCapacityAquarium();
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
            List<Fish> fishes = new List<Fish>();
            fishes.Add(new GoldFish());
            fishes.Add(new Guppy());
            fishes.Add(new Barbus());
            fishes.Add(new Labeo());
            int index = 0;
            Console.Clear();
            Console.WriteLine("Выбирите рыбку которую хотите добавить в аквариум: ");

            foreach (Fish fish in fishes)
            {
                index++;
                Console.WriteLine($"{index}.{fish.Name}");
            }

            int userInput = UserUtils.GetNumber();

            if (_fishes.Count < _maxCount)
            {
                _fishes.Add(fishes[userInput-1]);
            }
            else
            {
                Console.WriteLine("Нет места в аквариуме");
                Console.ReadLine();
            }
        }

        private void GrowAllFishs()
        {
            if (_fishes.Count > 0)
            {
                foreach (Fish fish in _fishes) 
                {
                    if (fish.IsAlive == true)
                    {
                        fish.GrowAge();
                    }
                }
            }
        }

        private void RemoveFish()
        {
            int index;
            Console.WriteLine("Введите номер рыбки для её удаления: ");
            index = UserUtils.GetNumber();

            if (index <= _fishes.Count)
            {
                _fishes.RemoveAt(index - 1);
            }
            else
            {
                Console.WriteLine("Такой рыбки нет !");
            }    
        }

        private int GetCapacityAquarium()
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
                Console.Write($"{fish.Name} - {fish.Age}");

                if (fish.IsAlive == false)
                {
                    Console.Write(" : Рыбка умерла!");
                }
                Console.WriteLine();
            }
        }
    }
    internal abstract class Fish
    {
        protected int MaxAge;
        public int Age { get; protected set; }
        public bool IsAlive => Age < MaxAge;
        public string Name { get; protected set; }
        
        public Fish(string name, int minAge, int maxAge)
        {
            Age = 0;
            Name = name;
            Random random = new Random();
            MaxAge = random.Next(minAge, maxAge);
        }
        public void GrowAge() => Age++;
    }

    internal class Barbus : Fish
    {
        public Barbus() : base("Барбус", 5, 7) { }
    }

    internal class GoldFish : Fish
    {
        public GoldFish() : base("Золотая рыбка", 15, 20) { }
    }

    internal class Guppy : Fish
    {
        public Guppy() : base("Гуппи", 10, 15) { }
    }

    internal class Labeo : Fish
    {
        public Labeo() : base("Лабео", 7, 10) { }
    }
}