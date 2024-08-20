using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;


class BrazilTaxService
{
    public double Tax { get; set; }
}
class Vehicle
{
    public required string Name { get; set; }

    public Vehicle(string Name)
    {
        this.Name = Name;
    }
}

class RentaService
{
    public double pricePerhour { get; set; }
    public double pricePerDay { get; set; }
    private BrazilTaxService _brazilTaxService = new BrazilTaxService();

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

        _brazilTaxService.Tax = basicPayment;
        carRental.invoice = new Invoice(basicPayment, _brazilTaxService.Tax);
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

    }
}
