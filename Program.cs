using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;


interface ITax
{
    public double Tax(double amount);
}
class BrazilTaxService : ITax
{

    double ITax.Tax(double amount)
    {
        if(amount <= 100)
        {
            return amount * 0.2;
        } else
        {
            return amount * 0.15;
        }
    }
}
class Vehicle
{
    public string Name { get; set; }

    public Vehicle(string Nasme)
    {
        this.Name = Nasme;
    }
}

class RentalService
{
    public double pricePerhour { get; set; }
    public double pricePerDay { get; set; }
    private ITax _itax;
    public RentalService(double priceH, double priceD, ITax taxService)
    {
        pricePerhour = priceH;
        pricePerDay = priceD;
        _itax = taxService;
    }

    public void processInvoice(CarRental carRental)
    {
        TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
        double basicPayment;
        if(duration.TotalHours <= 12)
        {
            basicPayment = pricePerhour * Math.Ceiling(duration.TotalHours);
        } else {
            basicPayment = pricePerDay * Math.Ceiling(duration.TotalDays);
        }

        double tax = _itax.Tax(basicPayment);
        carRental.invoice = new Invoice(basicPayment, tax);
    }
}

class CarRental
{
    public DateTime Start;
    public DateTime Finish;
    public Vehicle vehicle;
    public Invoice? invoice;

    public CarRental(DateTime Start, DateTime Finish, Vehicle vehicle)
    {
        this.Start = Start;
        this.Finish = Finish;
        this.vehicle = vehicle;
        this.invoice = null;
    }
}

class Invoice
{
    public double basicPayment { private get; set; }
    public double Tax { private get; set; }
    
    public Invoice(double basicPayment, double Tax)
    {
        this.basicPayment = basicPayment;
        this.Tax = Tax;
    }

    public double TotalPayment
    {
        get { return basicPayment + Tax; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Basic payment: " + basicPayment);
        sb.AppendLine("Tax: " + Tax.ToString("F2", CultureInfo.InvariantCulture));
        sb.AppendLine("Total payment: " + TotalPayment.ToString("F2", CultureInfo.InvariantCulture));
        return sb.ToString();
    }
}


class Program
{
    static void Main()
    {
        Console.WriteLine("Enter car name: ");
        string carName = Console.ReadLine();
        Vehicle car = new Vehicle(carName);
        Console.WriteLine("Pickup: (dd/mm/yyyy hh:mm): ");
        DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        Console.WriteLine("Return: (dd/mm/yyyy) hh:mm");
        DateTime finishDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        Console.WriteLine("Enter price per hour");
        double priceHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.WriteLine("Enter pricer per day");
        double priceDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        CarRental carental = new CarRental(startDate, finishDate, car);
        RentalService rentaservice = new RentalService(priceHour, priceDay, new BrazilTaxService());
        rentaservice.processInvoice(carental);
        Console.WriteLine("INVOICE");
        Console.WriteLine(carental.invoice);



    }
}
