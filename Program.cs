using System;
using System.Globalization;
using System.Collections.Generic;
using ConsoleApp1;

namespace ConsoleApp1
{
    class BankException : ApplicationException
    {
        public BankException(string message) : base(message)
        {

        }
    }

    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double withdrawLimit { get; set; }

        public Account()
        {

        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void withdraw(double amount)
        {
            if(amount > Balance)
            {
                throw new BankException($"You just have ${Balance}, please digit a amount lower");
            } else if(amount > withdrawLimit)
            {
                throw new BankException($"Your withdraw limit is {withdrawLimit}, please digit a amount lower than limit");
            }

            Balance -= amount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter account data");
            Console.Write("Number: "); 
            int number = int.Parse(Console.ReadLine());
            Console.Write("Holder: ");
            string holder = Console.ReadLine(); 
            Console.Write("Initial balance: ");
            double balance = double.Parse(Console.ReadLine());
            Console.Write("Withdraw limit: ");
            double withdrawLimit = double.Parse(Console.ReadLine());
            Console.Write("Enter amount for withdraw: ");
            double withdraw = double.Parse(Console.ReadLine()); 
            Account newAccount = new Account() {Balance=balance, Holder=holder, Number=number, withdrawLimit=withdrawLimit};
            try
            {
                newAccount.withdraw(withdraw);
                Console.WriteLine($"New balance: {newAccount.Balance}");
            } catch(BankException e)
            {
                Console.WriteLine("Withdraw error" + e);
            }
        }
    }
}
