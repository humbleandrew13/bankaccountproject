using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccountProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //creating the writers for later use
            StreamWriter checkingAccountWriter = new StreamWriter("CheckingAccount.txt");
            StreamWriter reserveAccountWriter = new StreamWriter("ReserveAccount.txt");
            StreamWriter savingsAccountWriter = new StreamWriter("SavingsAccount.txt");

            CheckingAccount checkingAccount = new CheckingAccount();





            while(true)
            {

            }
        }
    }
}
