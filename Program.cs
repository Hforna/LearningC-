using System;
using System.Globalization;
using ConsoleApp1;

namespace ConsoleApp1
{
    class Employee
    {
        public string Name { get; set; }
        public int Hours { get; set; }
        public double valuePerHour { get; private set; }

        public Employee()
        {

        }

        public Employee(string name, int hours, double valuePerHour)
        {
            this.Name = name;
            this.Hours = hours;
            this.valuePerHour = valuePerHour;
        }

        public virtual double Payment()
        {
            return valuePerHour * Hours;
        }


    }
    class OutsourcedEmployee : Employee
    {
        public double additionalCharge {get; set;}

        public OutsourcedEmployee()
        {

        }

        public OutsourcedEmployee(string name, int hours, double valuePerHour, double additionalCharge) : base(name, hours, valuePerHour) // utiliza o construtor de cima, ira definir name, hours, valuePerHour sem que precise reescrever novamente
        {
            this.additionalCharge = additionalCharge;
        } 

        public override double Payment()
        {
            
            double Porcent = base.Payment() / 100 ;
            return base.Payment() + Porcent; 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();

            Console.Write("Enter the number of employees: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Employee #{i} data:");
                Console.Write("Outsourced (y/n)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                String name = Console.ReadLine();
                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (ch == 'y')
                {
                    Console.Write("Additional charge: ");
                    double additionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new OutsourcedEmployee(name, hours, valuePerHour, additionalCharge));
                }
                else
                {
                    list.Add(new Employee(name, hours, valuePerHour));
                }
            }

            Console.WriteLine();
            Console.WriteLine("PAYMENTS:");
            foreach (Employee emp in list)
            {
                Console.WriteLine(emp.Name + " - $ " + emp.Payment().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}