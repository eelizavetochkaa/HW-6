using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace тумаков_7
{
    public enum AccountType { tecuchy, sberegatelny }
    class account
    {


        public account(int number, float balance, AccountType types)
        {
            this.number = number;
            this.balance = balance;
            Type = types;
        }
        private enum types
        {
            tecuchy,
            sberegatelny
        }

        private int number { get; set; }
        public float balance { get; set; }

        private AccountType Type { get; set; }
        public override string ToString() => $"Номер счёта - {number}, Баланс - {balance}, Тип - {Type}";




    }
    public enum AccountType2 { tecuchy, sberegatelny }
    class account2
    {
        int numberaccount;
        static int kolvoaccountov = 0;

        public account2(float balance, AccountType2 types)
        {
            this.numberaccount = kolvoaccountov;
            kolvoaccountov += 1;
            this.balance = balance;
            Type = types;
        }
        private enum types
        {
            tecuchy,
            sberegatelny
        }

        public float balance { get; set; }

        private AccountType2 Type { get; set; }

        public override string ToString() => $"Номер счёта - {numberaccount}, Баланс - {balance}, Тип - {Type}";


        public static void Snyat(int schet1, int balance1)
        {
            if (balance1>=schet1)
            {
                Console.WriteLine("Можно снять деньги");
                Console.WriteLine($"Новый счёт {balance1 - schet1}");
            }
            else
            {
                Console.WriteLine("Деньги нельзя снять : не хватает средств");
            }
        }

    }
    class Building
    {
        private static int lastBuildingNumber = 0;

        public int BuildingNumber { get; private set; }
        public double Height { get; private set; }
        public int Floors { get; private set; }
        public int Apartments { get; private set; }
        public int Entrances { get; private set; }

        public Building(double height, int floors, int apartments, int entrances)
        {
            BuildingNumber = GenerateBuildingNumber();
            Height = height;
            Floors = floors;
            Apartments = apartments;
            Entrances = entrances;
        }

        private int GenerateBuildingNumber()
        {
            return ++lastBuildingNumber;
        }

        public double CalculateFloorHeight()
        {
            return Height / Floors;
        }

        public int CalculateApartmentsPerEntrance()
        {
            return Apartments / Entrances;
        }

        public int CalculateApartmentsPerFloor()
        {
            return Apartments / Floors;
        }

        public void PrintBuildingInfo()
        {
            Console.WriteLine("Номер дома: " + BuildingNumber);
            Console.WriteLine("Высота: " + Height + " метров");
            Console.WriteLine("Этажей: " + Floors);
            Console.WriteLine("Квартир: " + Apartments);
            Console.WriteLine("Подъездов: " + Entrances);
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Упражнение 7.1");
                Console.WriteLine("Программа создаёт класс счет в банке с закрытыми полями");
                AccountType accountType = AccountType.tecuchy;
                Console.WriteLine(accountType);
                account bank = new account(12317771, 120_000, AccountType.sberegatelny);
                Console.WriteLine(bank);

                Console.WriteLine("Упражнение 7.2");
                Console.WriteLine("Программа создаёт класс счет в банке с закрытыми полями");
                AccountType2 accountType1 = AccountType2.tecuchy;
                Console.WriteLine(accountType);
                account2 bank1 = new account2(120_000, AccountType2.sberegatelny);
                Console.WriteLine(bank1);

                Console.WriteLine("Упражнение 7.3");
                Console.WriteLine("Введите, сколько денег вы хотите снять");
                bool flag = true;
                bool success = int.TryParse(Console.ReadLine(), out int schet);
                if (success)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Неверный ввод - необходимо ввести целое число");
                }
                account2.Snyat(schet, 120000);

                Console.WriteLine("Домашняя работа 7.1");
                Building building = new Building(50.5, 10, 100, 5);
                building.PrintBuildingInfo();

                Console.WriteLine("Высота этажа: " + building.CalculateFloorHeight() + " метров");
                Console.WriteLine("Квартир в подъезде: " + building.CalculateApartmentsPerEntrance());
                Console.WriteLine("Квартир на этаже: " + building.CalculateApartmentsPerFloor());

                Console.ReadLine();

            }
        }
    }
}
