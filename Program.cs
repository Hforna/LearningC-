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
            if(i > 5 && i < 8)
            {
                listP.Add(new Product(40 * i, $"Product {i}"));
            }else
            {
                listP.Add(new Product(20 * i, $"Product {i}"));
            }
            
        }

        var slistP = listP.Where(x => x.Price >= 100 ).Select(x => x.Name.ToUpper());
        foreach(string pr in slistP)
        {
            Console.WriteLine(pr);
        }
        var slistPO = listP.OrderBy(x => x.Price).ThenBy(x => x.Name);
        foreach (Product pr in slistPO)
        {
            Console.WriteLine(pr);
        }

        static string ToUpp(Product name)
        {
            return name.Name.ToUpper();
        }
        
    }
}