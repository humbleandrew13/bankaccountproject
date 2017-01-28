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
            //instantiating each account type
            CheckingAccount checkingAccount = new CheckingAccount();
            ReserveAccount reserveAccount = new ReserveAccount();
            SavingsAccount savingsAccount = new SavingsAccount();

            //Instantiating a streamwriter for use in the Methods
            StreamWriter checkingAccountWriter = new StreamWriter("CheckingAccount.txt");
            StreamWriter reserveAccountWriter = new StreamWriter("ReserveAccount.txt");
            StreamWriter savingsAccountWriter = new StreamWriter("SavingsAccount.txt");

            //Starting each file with basic info
            checkingAccountWriter.WriteLine("Checking Account Information for:");
            checkingAccountWriter.WriteLine(checkingAccount.UserName);
            checkingAccountWriter.WriteLine(checkingAccount.AddressLine1);
            checkingAccountWriter.WriteLine(checkingAccount.AddressLine2);
            checkingAccountWriter.WriteLine();

            reserveAccountWriter.WriteLine("Reserve Account Information for:");
            reserveAccountWriter.WriteLine(reserveAccount.UserName);
            reserveAccountWriter.WriteLine(reserveAccount.AddressLine1);
            reserveAccountWriter.WriteLine(reserveAccount.AddressLine2);
            reserveAccountWriter.WriteLine();

            savingsAccountWriter.WriteLine("Savings Account Information for:");
            savingsAccountWriter.WriteLine(savingsAccount.UserName);
            savingsAccountWriter.WriteLine(savingsAccount.AddressLine1);
            savingsAccountWriter.WriteLine(savingsAccount.AddressLine2);
            savingsAccountWriter.WriteLine();

            //UI Intro
            Console.WriteLine("\n\n\n\n\n\n               Thank you for using Humble National Bank!\n");
            Console.ReadKey();

            //UI
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Humble National Bank\n\n\n");
                Console.WriteLine("Please type the number of the action you would like to perform:\n\n");
                Console.WriteLine("  1 -- Show User Information");
                Console.WriteLine("  2 -- Check Balance");
                Console.WriteLine("  3 -- Make a Deposit");
                Console.WriteLine("  4 -- Withdraw Funds\n\n\n\n\n");
                Console.WriteLine("  9 -- Exit\n\n\n\n\n");

                string userInput = Console.ReadLine();

                userInput = userInput.ToUpper();

                if (userInput == "1" || userInput == "ONE")
                {
                    checkingAccount.ViewClientInformation();
                }
                else if (userInput == "2" || userInput == "TWO")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("For which Account would you like to check the balance?\n");
                        Console.WriteLine("Please enter the corresponding number:\n\n\n");
                        Console.WriteLine("  1 -- Checking Account");
                        Console.WriteLine("  2 -- Reserve Account");
                        Console.WriteLine("  3 -- Savings Account\n\n");
                        Console.WriteLine("  9 -- Exit to Main Menu\n\n\n\n\n");

                        string checkBalanceInput = Console.ReadLine();
                        checkBalanceInput = checkBalanceInput.ToUpper();

                        if (checkBalanceInput == "1" || checkBalanceInput == "ONE")
                        {
                            checkingAccount.CheckBalance();
                        }
                        else if (checkBalanceInput == "2" || checkBalanceInput == "TWO")
                        {

                        }
                        else if (checkBalanceInput == "3" || checkBalanceInput == "THREE")
                        {

                        }
                        else if (checkBalanceInput == "9" || checkBalanceInput == "NINE")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n\nI'm sorry, but that was not a correct selection. Please try again.");
                        }

                        Console.ReadKey();
                    }
                }
                else if (userInput == "3" || userInput == "THREE")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("For which Account would you like to make a deposit?\n");
                        Console.WriteLine("Please enter the corresponding number:\n\n\n");
                        Console.WriteLine("  1 -- Checking Account");
                        Console.WriteLine("  2 -- Reserve Account");
                        Console.WriteLine("  3 -- Savings Account\n\n");
                        Console.WriteLine("  9 -- Exit to Main Menu\n\n\n\n\n");

                        string depositAccountInput = Console.ReadLine();
                        depositAccountInput = depositAccountInput.ToUpper();

                        if (depositAccountInput == "1" || depositAccountInput == "ONE")
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter the amount you wish to deposit in your Checking account:\n\n");
                            Console.Write("        $");
                            double depositAmount = Convert.ToDouble(Console.ReadLine());

                            if (depositAmount > 9999)
                            {
                                Console.WriteLine("\n\n\n\n\nI am sorry, but you must go to a teller for this transaction.");
                            }
                            else if (depositAmount <= 0)
                            {
                                Console.WriteLine("\n\n\n\n\nI am sorry, but this is not an appropriate amount for a deposit.");
                            }
                            else
                            {
                                depositAmount = Math.Round(depositAmount, 2);
                                checkingAccount.Deposit(depositAmount);
                                checkingAccountWriter.WriteLine(DateTime.Now + " -- Made a deposit + $" + depositAmount + ". New balance: $" + checkingAccount.AccountBalance);
                                Console.WriteLine("\n\n\n\n\nYour deposit of " + depositAmount + " has been recorded.");
                            }
                        }
                        else if (depositAccountInput == "2" || depositAccountInput == "TWO")
                        {

                        }
                        else if (depositAccountInput == "3" || depositAccountInput == "THREE")
                        {

                        }
                        else if (depositAccountInput == "9" || depositAccountInput == "NINE")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("I'm sorry, but that was not correct input. Please try again.");
                        }

                        Console.ReadKey();
                    }
                }
                else if (userInput == "4" || userInput == "FOUR")
                {

                }
                else if (userInput == "9" || userInput == "NINE")
                {
                    break;
                }
            }

            checkingAccountWriter.Close();
            savingsAccountWriter.Close();
            reserveAccountWriter.Close();
        }
    }
}
