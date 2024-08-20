using System;
using System.IO;
using System.Collections.Generic;
using System.Text;


class Product : IComparable
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Price: {Price}";
    }

    public int CompareTo(object obj)
    {
        if (!(obj is Product))
        {
            throw new AggregateException("The object is not product");
        }

        Product otobject = obj as Product;
        return Price.CompareTo(otobject.Price);
    }

}

class CalcService
{
    public T Max<T>(List<T> list) where T : IComparable
    {
        T highest = list[0];
        for (int i = 1; i < list.Count; i++)
        {
            if (list[i].CompareTo(highest) > 0)
            {
                highest = list[i];
            }
        }
        return highest;
    }
}



class Program
{
    static void Main(string[] args)
    {
        List<Product> list = new List<Product>();
        for (int i = 0; i <= 10; i++)
        {
            list.Add(new Product($"Iphone {i}", 200 * i));
        }
        CalcService cl = new CalcService();
        Console.WriteLine(cl.Max<Product>(list));
    }
}