using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject
{
    abstract class Account
    {
        //fields
        private string userName;
        private string addressLine1;
        private string addressLine2;

        //Property
        public string UserName
        {
            get { return this.userName; }
        }
        
        //Constructor
        protected Account()
        {
            userName = "Ronald J. Dump";
            addressLine1 = "1600 Transylvania Ave";
            addressLine2 = "Dump Tower, ID 87499";
        }

        //Methods
        public void ViewClientInformation()
        {
            Console.WriteLine("\nClient Account Information\n");
            Console.WriteLine("Name:    {0}\n", UserName);
            Console.WriteLine("Address: {0}", addressLine1);
            Console.WriteLine("         {0}", addressLine2);
        }

        //Abstracts that MUST be created in derived classes
        public abstract void CheckBalance();

        public abstract void Deposit();

        public abstract void Withdraw();
    }
}
