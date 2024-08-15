using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using ConsoleApp1;

namespace ConsoleApp1
{
    enum WorkerLevel {
        Junior = 1,
        MidLeve = 2,
        Senior = 3
    }
    class Worker {
        public string Name {get; set;}
        public WorkerLevel Level {get; set;}
        public double baseSalary {get; set;}

        public List<HourContract> Contracts {get; set;} = new List<HourContract>();

        public void addContract(HourContract contract) {
            Contracts.Add(contract);
        }

        public void removeContract(ref HourContract Contract) {
            Contracts.Remove(Contract);
        }

        public double income(int year, int month)
        {
            double valueIncome = 0;
            foreach(HourContract Contract in Contracts)
            {
                if(Contract.Date.Year == year && Contract.Date.Month == month)
                {
                    valueIncome += Contract.totalValue();
                }
            }
            Console.Write($"Income for {month}/{year}: ");
            return valueIncome;
        }

        public override string ToString()
        {
            return $"{Name} {Level} {baseSalary}";
        }
    }
    class Department {
        public string? Name {get; set;}
    }

    class HourContract
    {
        public DateTime Date { get; set; }
        public double PriceHour { get; set; }
        public int Hours { get; set; }

        public double totalValue() {
            return PriceHour * Hours;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter departament's name: "); string nameD = Console.ReadLine();
            Console.WriteLine("Enter worker data");
            Console.Write("Name: "); string nameWorker = Console.ReadLine();
            Console.Write("Level (Junior, Pleno, Senior): "); string userLevel = Console.ReadLine();
            Console.Write("Base salary: "); double userSalary = double.Parse(Console.ReadLine());
            Department userDepartament = new Department {Name=nameD};
            WorkerLevel userWorkerLevel = Enum.Parse<WorkerLevel>(userLevel);
            Worker userWorker = new Worker {Name=nameWorker, baseSalary=userSalary, Level=userWorkerLevel};

        }
    }
}