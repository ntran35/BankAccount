using System;
using System.Collections.Generic;
using System.Text;

namespace MySuperBank
{
    public class BankAccount
    {
        
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance {
            get 
            {
                decimal balance = 0;    //initial the return balance by 0
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;  
            }
        }

        private static int accountNumberSeed = 1234567890;

        //this is the constructor for BankAccount
        public BankAccount(string name, decimal initialBalance) {
            this.Owner = name;
            // this.Balance = initialBalance;
            MakeDeposit(initialBalance, DateTime.Now, "initial deposit");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        //keep track of all transactions of an individual account holder
        //in this list
        private List<Transaction> allTransactions = new List<Transaction>(); 

        public void MakeDeposit(decimal amount, DateTime date, string note) {
            if (amount <= 0) {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note) {
            if (amount <= 0) {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string getAccountHistory() {
            var report = new StringBuilder();
            report.AppendLine("Date \t \tAmount\t \tNotes" );

            foreach (var item in allTransactions) {
                report.AppendLine($"{item.Date.ToShortDateString()} \t{item.Amount} \t{item.Notes}");
            }

            return report.ToString();
        }


    }
}
