using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Globalization;



interface ISystemPayment
{
    double PaymentFee(double Porcent);
    double Interest(double Porcent, double Month);
}

class PayPal : ISystemPayment
{
    private double FeePernetage = 0.02;
    private double MonthlyInterest = 0.01;
    public double Interest(double Amount, double Month)
    {
        return Amount * Month * MonthlyInterest;
    }

    public double PaymentFee(double Amount)
    {
        return Amount * FeePernetage;
    }
}
class Contract
{
    public int Number;
    public DateTime Date;
    public double ContractValue;
    public int NumInstallment;

    public Contract(int number, DateTime date, double contractValue, int numInstall)
    {
        Number = number;
        Date = date;
        ContractValue = contractValue;
        NumInstallment = numInstall;
    }
}

class Installment
{
    public DateTime dueDate;
    public double Amount;

    public Installment(DateTime dueDate, double Amount)
    {
        this.dueDate = dueDate;
        this.Amount = Amount;
    }

    public override string ToString()
    {
        return $"{dueDate} - {Amount}";
    }
}

class PaymentService
{
    public List<Installment> installments = new List<Installment>();
    public Contract contract;
    public ISystemPayment systemPayment;

    public PaymentService(Contract contract, ISystemPayment systemPayment)
    {
        this.contract = contract;
        this.systemPayment = systemPayment;
    }

    public void Calculations()
    {
        double contractQuota = contract.ContractValue / contract.NumInstallment;
        for(int i = 1; i <= contract.NumInstallment; i++)
        {
            double InterestPayment = contractQuota + systemPayment.Interest(contractQuota, i);
            double FeePayment = InterestPayment + systemPayment.PaymentFee(InterestPayment);
            installments.Add(new Installment(contract.Date.AddMonths(i), FeePayment));
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter contract data");
        Console.Write("Number: ");
        int NumContract = int.Parse(Console.ReadLine());
        Console.Write("Date (dd/MM/yyyy): ");
        DateTime dateStart = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        Console.Write("Contract value: ");
        double ContractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Enter number of installments: ");
        int NumInstallments = int.Parse(Console.ReadLine());
        Contract contract = new Contract(NumContract, dateStart, ContractValue, NumInstallments);
        PaymentService paymentService = new PaymentService(contract, new PayPal());
        paymentService.Calculations();
        Console.WriteLine("Installments:");
        foreach(Installment ins in paymentService.installments)
        {
            Console.WriteLine(ins);
        }
    }
}