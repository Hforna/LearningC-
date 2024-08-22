using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

delegate void IntNumberOperator(double first, double second);

class Product : IComparable
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

        List<Product> listP = new List<Product>
        {
            new Product(250, "Product A"),
            new Product(120, "Product B"),
            new Product(350, "Product C"),
            new Product(90, "Product D"),
            new Product(200, "Product E"),
            new Product(150, "Product F"),
            new Product(400, "Product G"),
            new Product(220, "Product H"),
            new Product(310, "Product I"),
            new Product(180, "Product J"),
            new Product(300, "Product K"),
            new Product(275, "Product L"),
            new Product(50, "Product M"),
            new Product(125, "Product N"),
            new Product(90, "Product A"),
            new Product(500, "Product O"),
            new Product(300, "Product P"),
            new Product(240, "Product Q"),
            new Product(350, "Product R"),
            new Product(150, "Product S"),
        };


        var slistP = listP.Where(x => x.Price >= 100).Select(x => x.Name.ToUpper());
        foreach (string pr in slistP)
        {
            Console.WriteLine(pr);
        }
        var slistPO = listP.OrderBy(x => x.Price).ThenBy(x => x.Name).Select(x => $"{x.Name} Price is: {x.Price}").Skip(2).Take(8).Max();
        Console.WriteLine(listP.Skip(5).Sum(x => x.Price));
        //foreach (var pr in slistPO)
        //{
        //    Console.WriteLine(pr);
        //}
        var listGby = listP.Where(x => x.Price != 0).Select(x => (double)x.Price).Aggregate((x, y) => x * y);
        Console.WriteLine(listGby);

        static string ToUpp(Product name)
        {
            return name.Name.ToUpper();
        }

    }
}