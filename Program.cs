using System;
using System.Globalization;
using ConsoleApp1;

namespace ConsoleApp1
{
    class Product
    {
        public string Name {get; set;}
        public double Price {get; set;}

        public Product(string Name, double Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
        public virtual string priceTag()
        {
            return $"{Name} ${Price}";
        } 
    }

    class ImportedProduct : Product
    {
        private double customsFee = 20;

        public ImportedProduct(string name, double price, double customsFee) :base(name, price)
        {
            this.customsFee = customsFee;
        }

        private double totalPrice()
        {
            return Price + customsFee;
        }
        public override string priceTag()
        {
            return base.priceTag() + $" (Customs fee: $ {totalPrice()})";
        }
    }

    class UsedProduct : Product
    {
        public DateTime manufactureDate;

        public UsedProduct(string name, double price, DateTime manufactureDate) : base(name, price)
        {
            this.manufactureDate = manufactureDate;
        }
        public override string priceTag()
        {
            return base.priceTag() + $"Manufacture date: {manufactureDate}";
        }
    }
    class Program
    {
        static void Main()
        {
            Console.Write("Enter number of product: ");
            List<Product> list = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Product #" + i + " data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                String name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (type == 'c')
                {
                    list.Add(new Product(name, price));
                }
                else if (type == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, date));
                }
                else
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new ImportedProduct(name, price, customsFee));
                }
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");
            foreach (Product prod in list)
            {
                Console.WriteLine(prod.priceTag());
            }
            }
        }
    }
