using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject
{
    class Account
    {
        //fields
        static private string userName;
        static private string addressLine1;
        static private string addressLine2;

        //Property
        public string UserName
        {
            get { return userName; }
        }

        public string AddressLine1
        {
            get { return addressLine1; }
        }

        public string AddressLine2
        {
            get { return addressLine2; }
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
            Console.Clear();
            Console.WriteLine("\nClient Account Information\n");
            Console.WriteLine("Name:    {0}\n", UserName);
            Console.WriteLine("Address: {0}", addressLine1);
            Console.WriteLine("         {0}", addressLine2);
            Console.ReadKey();
        }
    }
}
