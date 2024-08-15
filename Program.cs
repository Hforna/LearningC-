using System;
using System.Globalization;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Write your birthday in the format dd/MM/yyyy");
            string Input = Console.ReadLine();

            DateTime d = DateTime.ParseExact(Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime now = DateTime.Now;

            int age = now.Year - d.Year;
            if (now < d.AddYears(age)) {
                age--;
            }

            Console.WriteLine("You are " + age + " years old.");
        }
    }
}
