using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccountProject
{
    class SavingsAccount : Account
    {
        //fields
        private string accountNumber;
        private double accountBalance;

        //Properties
        protected string AccountNumber
        {
            get { return this.accountNumber; }
            //no set; don't want this to change
        }

        public double AccountBalance
        {
            get { return this.accountBalance; }
            set { this.accountBalance = value; }
        }

        //Constructor
        public SavingsAccount():base()
        {
            this.accountNumber = "7771313777";
            this.accountBalance = 7130.22;
        }

        //Methods
        public void CheckBalance()
        {
            Console.Clear();
            Console.WriteLine(" For Savings Account number {0}, the balance is {1}", AccountNumber, AccountBalance);
        }

        public void Deposit(double depositAmount)
        {
            AccountBalance += depositAmount;
        }

        public void Withdraw(double withdrawAmount)
        {
            AccountBalance -= withdrawAmount;
        }
    }
}
