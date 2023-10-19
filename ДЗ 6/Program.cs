using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_6
{
    abstract class Attraction
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Attraction(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public abstract void Start();
        public abstract void Stop();
    }

    class WaterSlide : Attraction
    {
        public bool IsOpen { get; private set; }

        public WaterSlide(string name, int capacity) : base(name, capacity)
        {
            IsOpen = false;
        }

        public override void Start()
        {
            Console.WriteLine("Водная горка запущена!");
            IsOpen = true;
        }

        public override void Stop()
        {
            Console.WriteLine("Водная горка остановлена!");
            IsOpen = false;
        }

        public void ChangeCapacity(int newCapacity)
        {
            if (newCapacity > 0)
            {
                Capacity = newCapacity;
                Console.WriteLine($"Изменена вместимость водной горки на {newCapacity} человек");
            }
            else
            {
                Console.WriteLine("Некорректное значение вместимости!");
            }
        }
    }

    class Pool : Attraction
    {
        public bool IsOpen { get; private set; }

        public Pool(string name, int capacity) : base(name, capacity)
        {
            IsOpen = false;
        }

        public override void Start()
        {
            Console.WriteLine("Бассейн открыт!");
            IsOpen = true;
        }

        public override void Stop()
        {
            Console.WriteLine("Бассейн закрыт!");
            IsOpen = false;
        }

        public void ChangeTemperature(int newTemperature)
        {
            Console.WriteLine($"Температура бассейна изменена на {newTemperature} градусов");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тема - аквапарк");
            Console.WriteLine("Введите название водной горки:");
            string waterSlideName = Console.ReadLine();

            Console.WriteLine("Введите вместимость водной горки:");
            bool flag = true;
            bool a = int.TryParse(Console.ReadLine(), out int waterSlideCapacity);
            if (a)
            {
                flag = false;
            }
            else
            {
                Console.WriteLine("Неверный ввод - необходимо ввести целое число");
            }

            WaterSlide waterSlide = new WaterSlide(waterSlideName, waterSlideCapacity);

            Console.WriteLine("Введите название бассейна:");
            string poolName = Console.ReadLine();

            Console.WriteLine("Введите вместимость бассейна:");
            bool flag1 = true;
            bool a1 = int.TryParse(Console.ReadLine(), out int poolCapacity);
            if (a1)
            {
                flag1 = false;
            }
            else
            {
                Console.WriteLine("Неверный ввод - необходимо ввести целое число");
            }
            Pool pool = new Pool(poolName, poolCapacity);

            waterSlide.Start();
            Console.WriteLine($"Вместимость водной горки: {waterSlide.Capacity}");

            Console.WriteLine("Введите новую вместимость водной горки:");
            bool flag2 = true;
            bool a2 = int.TryParse(Console.ReadLine(), out int newWaterSlideCapacity);
            if (a2)
            {
                flag2 = false;
            }
            else
            {
                Console.WriteLine("Неверный ввод - необходимо ввести целое число");
            }
            waterSlide.ChangeCapacity(newWaterSlideCapacity);

            waterSlide.Stop();

            pool.Start();
            Console.WriteLine($"Вместимость бассейна: {pool.Capacity}");

            Console.WriteLine("Введите температуру бассейна:");
            bool flag3 = true;
            bool a3 = int.TryParse(Console.ReadLine(), out int newPoolTemperature);
            if (a3)
            {
                flag3 = false;
            }
            else
            {
                Console.WriteLine("Неверный ввод - необходимо ввести целое число");
            }

            pool.ChangeTemperature(newPoolTemperature);

            pool.Stop();
            Console.ReadKey();
        }


    }
}
