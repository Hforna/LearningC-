using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

delegate void IntNumberOperator(double first, double second);

class Product : IComparable
{
    public double Price { get; set; }
    public string Name { get; set; }

    public Product(double Price, string name)
    {
        Name = name;
        this.Price = Price;
    }

    public override string ToString()
    {
        return $"{Name}, {Price}";
    }

    public int CompareTo(object obj)
    {
        Product other = obj as Product;
        return Price.CompareTo(other.Price);
    }
}

class Program
{
    static void Main()
    {
        string path = "logs.txt";
        List<Product> listP = new List<Product>();
        Dictionary<double, string> listFile = new Dictionary<double, string>();

        using (StreamReader sr = File.OpenText(path))
        {
            while (!sr.EndOfStream)
            {
                string[] ss = sr.ReadLine().Split(", ");
                listFile[double.Parse(ss[0])] = ss[1];
            }
        }
        foreach (var item in listFile)
        {
            listP.Add(new Product(item.Key, item.Value));
        }
        double average = listP.Average(x => x.Price);
        var listLess = listP.Where(x => x.Price < average).OrderByDescending(x => x.Price).ThenBy(x => x.Name);
        foreach (Product p in listLess)
        {
            Console.WriteLine(p);
        }
        Console.WriteLine(average);


    }
}