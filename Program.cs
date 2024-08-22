using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Text;

class Employee
{
    public string Name { get; set; }
    public string Email { get; set; }
    public double Salary { get; set; }

    public Employee(string name, string email, double salary)
    {
        Name = name;
        Email = email;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Email: {Email}, Salary: {Salary}";
    }
}

class Program
{
    static void Main()
    {
        List<Employee> listEmployee = new List<Employee>();
        string path = "logs.txt";
        using (StreamReader sr = File.OpenText(path))
        {
            while (!sr.EndOfStream)
            {
                string[] infos = sr.ReadLine().Split(", ");
                listEmployee.Add(new Employee(infos[0], infos[1], double.Parse(infos[2])));
            }
        }
        Console.Write("Enter salary: ");
        double salaryAmount = double.Parse(Console.ReadLine());
        Console.WriteLine($"Email of people whose salary is than {salaryAmount}");
        var newList = listEmployee.Where(x => x.Salary > salaryAmount).OrderBy(x => x.Salary).Select(x => new { x.Email, x.Salary, x.Name }).Distinct();
        foreach (var item in newList)
        {
            Console.WriteLine(item.Email);
        }
        double sumFirstPeople = listEmployee.Where(x => x.Email == newList.First().Email).Sum(x => x.Salary);
        Console.WriteLine($"Sum of salary of people whose name starts with {newList.First().Name[0]} is: {sumFirstPeople}");

    }
}