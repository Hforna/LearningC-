using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

delegate void IntNumberOperator(double first, double second);

class Product
{
    public int Price { get; set; }
    public string Name { get; set; }

    public Product(int Price, string name)
    {
        Name = name;
        this.Price = Price;
    }

    public override string ToString()
    {
        return $"{Name}, {Price}";
    }
}

class Program
{
    static void Main()
    {

        List<Product> listP = new List<Product>();
        for(int i = 0; i <= 10; i++)
        {
            listP.Add(new Product(20 * i, $"Product {i}"));
        }

        List<string> slistP = listP.Select(x => x.Name.ToUpper()).ToList();
        foreach(string pr in slistP)
        {
            Console.WriteLine(pr);
        }

        static string ToUpp(Product name)
        {
            return name.Name.ToUpper();
        }
        
    }
}