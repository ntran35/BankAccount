using System;
//using Humanizer;

namespace BankLibrary
{
    class Program
    {
        static void Main(string[] args)
        {

            //Testing using Nuget packet humanizer.CORE
            //Console.WriteLine("Car".Pluralize());
            //Console.WriteLine("People".Pluralize());
            //Console.WriteLine("information".Pluralize());
            //Console.WriteLine(3456.ToWords());

            var account = new BankAccount("Nhat", 10000);
            
            Console.WriteLine($"Account #{account.Number} was created for {account.Owner} with a 1st deposit of ${account.Balance}");

            //  var account1 = new BankAccount("Quyen", 10000);
            //  Console.WriteLine($"Account #{account1.Number} was created for {account1.Owner} with a 1st deposit of ${account1.Balance}");

            account.MakeWithdrawal(1000, DateTime.Now, "Piano Purchased");
            Console.WriteLine($"Current balance after withdrawal is {account.Balance}");

            account.MakeDeposit(300, DateTime.Now, "Paychecks");
            Console.WriteLine($"Current balance after deposit is {account.Balance}");

            account.MakeWithdrawal(1000, DateTime.Now, "Rent");
            Console.WriteLine($"Current balance after withdrawal is {account.Balance}");

            account.MakeDeposit(400, DateTime.Now, "Gifts");
            Console.WriteLine($"Current balance after deposit is {account.Balance}");

            account.MakeWithdrawal(5000, DateTime.Now, "Tuition");
            Console.WriteLine($"Current balance after withdrawal is {account.Balance}");

            Console.WriteLine($"{account.getAccountHistory()}");

        }
    }
}
