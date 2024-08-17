using System;
using System.Globalization;
using ConsoleApp1;

namespace ConsoleApp1
{
    class AccountBank
    {
        public  int number {get; set;}
        public required string holder { get; set; }
        public double balance { get; private set; }

        public virtual void withDraw(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
            }
        }

        public virtual void Deposit(double amount)
        {
            balance += amount;
        }
    }

    class AccountBusiness : AccountBank
    {
        public double loanLimit = 2;

        public void loan(double amount)
        {
            if (amount < loanLimit)
            {
                Deposit(amount);
            }
        }

        public override void withDraw(double amount)
        {
            base.withDraw(amount);
            base.withDraw(2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AccountBank account = new AccountBank { holder = "Henrique", number=200};
            AccountBank s = new AccountBusiness { holder = "Henrique", number=400};
            AccountBusiness account1 = (AccountBusiness) account;
            account.Deposit(400);
            account.withDraw(200);
            s.Deposit(400);
            s.withDraw(200);
            Console.WriteLine(account.balance);
            Console.WriteLine(s.balance);
            if(s is AccountBank)
            {
                Console.WriteLine("s is account bank");
            }

        }
    }
}