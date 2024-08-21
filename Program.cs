using System;
using System.IO;
using System.Collections.Generic;
using System.Text;


class Product
{
    public string Name { get; set; }
    public int Price { get; set; }

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode() + Price.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Product))
        {
            return false;
        }
        Product other = obj as Product;
        return Name.Equals(other.Name) && Price.Equals(other.Price);
    }
}

class Program
{
    static void Main(string[] args)
    {
        HashSet<string> set = new HashSet<string>();

        for (int i = 1; i <= 10; i++)
        {
            set.Add($"Henrique{i}");
        }
        foreach (string name in set)
        {
            Console.WriteLine(name);
        }

        SortedSet<int> sortset = new SortedSet<int>() { 1, 2, 20, 6, 8, 10 };
        SortedSet<int> sortsetd = new SortedSet<int>() { 1, 2, 212, 3, 558, 10 };
        SortedSet<int> ssd = new SortedSet<int>(sortset);
        ssd.IntersectWith(sortsetd);
        foreach (int ss in ssd)
        {
            Console.WriteLine(ss);
        }
        Console.WriteLine(set.Contains("Henrique2"));

        HashSet<Product> productH = new HashSet<Product>();
        productH.Add(new Product("iPhone 16", 8000));
        Product wnew = new Product("iPhone 16", 8000);
        Console.Write(productH.Contains(wnew));

    }
}