using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccountProject
{
    class CheckingAccount : Account
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
        public CheckingAccount():base()
        {
            this.accountNumber = "4567891011";
            this.accountBalance = 500.13; //initializing it with $500
        }
        
        //Methods
        public void CheckBalance()
        {
            Console.Clear();
            Console.WriteLine(" For Checking Account number {0}, the balance is {1}", accountNumber, accountBalance);
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
