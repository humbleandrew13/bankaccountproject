using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccountProject
{
    class ReserveAccount : Account
    {
        //fields
        private string accountNumber;
        private double accountBalance;

        //Properties
        public string AccountNumber
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
        public ReserveAccount() : base()
        {
            this.accountNumber = "7891011456";
            this.accountBalance = 45.77;
        }

        //Methods
        public void CheckBalance()
        {
            Console.Clear();
            Console.WriteLine(" For Reserve Account number {0}, the balance is ${1}", accountNumber, accountBalance);
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
