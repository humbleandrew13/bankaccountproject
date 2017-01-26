using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject
{
    class CheckingAccount : Account
    {
        //fields
        private string accountNumber;
        private float accountBalance;

        //Properties
        protected string AccountNumber
        {
            get { return this.accountNumber; }
            //no set; don't want this to change
        }

        protected float AccountBalance
        {
            get { return this.accountBalance; }
            set { this.accountBalance = value; }
        }

        //Constructor
        public CheckingAccount():base()
        {
            this.accountNumber = "4567891011";
            this.accountBalance = 500; //initializing it with $500
        }

        //Methods
        public override void CheckBalance()
        {
            
        }

        public override void Deposit()
        {
            
        }

        public override void Withdraw()
        {
            
        }
    }
}
