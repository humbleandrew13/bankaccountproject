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
            checkingAccountWriter.WriteLine("Checking Account #" + checkingAccount.AccountNumber);
            checkingAccountWriter.WriteLine();
            checkingAccountWriter.WriteLine("Balance as of " + DateTime.Now + " --- $" + checkingAccount.AccountBalance);
            checkingAccountWriter.WriteLine();

            reserveAccountWriter.WriteLine("Reserve Account Information for:");
            reserveAccountWriter.WriteLine(reserveAccount.UserName);
            reserveAccountWriter.WriteLine(reserveAccount.AddressLine1);
            reserveAccountWriter.WriteLine(reserveAccount.AddressLine2);
            reserveAccountWriter.WriteLine("Reserve Account #" + reserveAccount.AccountNumber);
            reserveAccountWriter.WriteLine();
            reserveAccountWriter.WriteLine("Balance as of " + DateTime.Now + " --- $" + reserveAccount.AccountBalance);
            reserveAccountWriter.WriteLine();

            savingsAccountWriter.WriteLine("Savings Account Information for:");
            savingsAccountWriter.WriteLine(savingsAccount.UserName);
            savingsAccountWriter.WriteLine(savingsAccount.AddressLine1);
            savingsAccountWriter.WriteLine(savingsAccount.AddressLine2);
            savingsAccountWriter.WriteLine("Savings Account #" + savingsAccount.AccountNumber);
            savingsAccountWriter.WriteLine();
            savingsAccountWriter.WriteLine("Balance as of " + DateTime.Now + " --- $" + savingsAccount.AccountBalance);
            savingsAccountWriter.WriteLine();

            //UI Intro
            Console.WriteLine("\n\n\n\n\n\n               Welcome to Humble National Bank ATM!\n");
            Console.ReadKey();

            //UI
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" Humble National Bank\n\n\n");
                Console.WriteLine(" Please type the number of the action you would like to perform:\n\n");
                Console.WriteLine("  1 -- Show User Information");
                Console.WriteLine("  2 -- Check Balance");
                Console.WriteLine("  3 -- Make a Deposit");
                Console.WriteLine("  4 -- Withdraw Funds\n\n\n\n\n");
                Console.WriteLine("  9 -- Exit\n\n\n\n\n");

                string userInput = Console.ReadLine();

                userInput = userInput.ToUpper();//using caps in case numbers are entered as text

                if (userInput == "1" || userInput == "ONE")//prints the hard wired user info
                {
                    checkingAccount.ViewClientInformation();
                }
                else if (userInput == "2" || userInput == "TWO")//prints balance of selected account type to screen
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine(" For which Account would you like to check the balance?\n");
                        Console.WriteLine(" Please enter the corresponding number:\n\n\n");
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
                            reserveAccount.CheckBalance();
                        }
                        else if (checkBalanceInput == "3" || checkBalanceInput == "THREE")
                        {
                            savingsAccount.CheckBalance();
                        }
                        else if (checkBalanceInput == "9" || checkBalanceInput == "NINE")
                        {
                            Console.WriteLine("\n\n Please press any key to return to the Main Menu.");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n I am sorry, but that was not a correct selection.");
                            Console.WriteLine("\n Please press any key to try again.");
                        }

                        Console.ReadKey();
                    }
                }
                else if (userInput == "3" || userInput == "THREE")//for a deposit
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine(" For which Account would you like to make a deposit?\n");
                        Console.WriteLine(" Please enter the corresponding number:\n\n\n");
                        Console.WriteLine("  1 -- Checking Account"); //selecting the account type
                        Console.WriteLine("  2 -- Reserve Account");
                        Console.WriteLine("  3 -- Savings Account\n\n");
                        Console.WriteLine("  9 -- Exit to Main Menu\n\n\n\n\n");

                        string depositAccountInput = Console.ReadLine();
                        depositAccountInput = depositAccountInput.ToUpper();

                        if (depositAccountInput == "1" || depositAccountInput == "ONE")
                        {
                            Console.Clear();
                            Console.WriteLine(" Please enter the amount you wish to deposit in your Checking account:\n\n");
                            Console.Write("        $");
                            try
                            {
                                double depositAmount = Convert.ToDouble(Console.ReadLine());


                                if (depositAmount > 9999.99) //deposits $10,000 or greater must have appropriate tax info with them
                                {
                                    Console.WriteLine("\n\n\n\n\n I am sorry, but you must go to a teller for this transaction.");
                                    Console.WriteLine("\n Please press any key to try again.");
                                }
                                else if (depositAmount <= 0) //can't deposit $0 or less
                                {
                                    Console.WriteLine("\n\n\n\n\n I am sorry, but that was not an appropriate amount for a deposit.");
                                    Console.WriteLine("\n Please press any key to try again.");
                                }
                                else
                                {
                                    depositAmount = Math.Round(depositAmount, 2); //make it round to the nearest hundredth
                                    checkingAccount.Deposit(depositAmount);
                                    checkingAccountWriter.WriteLine(DateTime.Now + " -- Made a deposit  +$" + depositAmount + ".  New balance: $" + checkingAccount.AccountBalance);
                                    Console.WriteLine("\n\n\n\n\n Your deposit of $" + depositAmount + " has been recorded in your Checking Account.\n");
                                    Console.WriteLine(" Current balance: $" + checkingAccount.AccountBalance);

                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\n\n I am sorry, but this is not an appropriate format for a dollar amount.\n");
                                Console.WriteLine("Please be more careful when entering the deposit value.");
                            }
                        }
                        else if (depositAccountInput == "2" || depositAccountInput == "TWO")//same code for reserve account
                        {
                            Console.Clear();
                            Console.WriteLine(" Please enter the amount you wish to deposit in your Reserve account:\n\n");
                            Console.Write("        $");
                            try
                            {
                                double depositAmount = Convert.ToDouble(Console.ReadLine());

                                if (depositAmount > 9999.99)
                                {
                                    Console.WriteLine("\n\n\n\n\n I am sorry, but you must go to a teller for this transaction.");
                                    Console.WriteLine("\n Please press any key to try again.");
                                }
                                else if (depositAmount <= 0)
                                {
                                    Console.WriteLine("\n\n\n\n\n I am sorry, but that was not an appropriate amount for a deposit.");
                                    Console.WriteLine("\n Please press any key to try again.");
                                }
                                else
                                {
                                    depositAmount = Math.Round(depositAmount, 2);
                                    reserveAccount.Deposit(depositAmount);
                                    reserveAccountWriter.WriteLine(DateTime.Now + " -- Made a deposit  +$" + depositAmount + ".  New balance: $" + reserveAccount.AccountBalance);
                                    Console.WriteLine("\n\n\n\n\n Your deposit of $" + depositAmount + " has been recorded in your Reserve Account.\n");
                                    Console.WriteLine(" Current balance: $" + reserveAccount.AccountBalance);
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\n\n I am sorry, but this is not an appropriate format for a dollar amount.\n");
                                Console.WriteLine("Please be more careful when entering the deposit value.");
                            }
                        }
                        else if (depositAccountInput == "3" || depositAccountInput == "THREE")//same code for savings account
                        {
                            Console.Clear();
                            Console.WriteLine(" Please enter the amount you wish to deposit in your Savings account:\n\n");
                            Console.Write("        $");
                            try
                            {
                                double depositAmount = Convert.ToDouble(Console.ReadLine());

                                if (depositAmount > 9999.99)
                                {
                                    Console.WriteLine("\n\n\n\n\n I am sorry, but you must go to a teller for this transaction.");
                                    Console.WriteLine("\n Please press any key to try again.");
                                }
                                else if (depositAmount <= 0)
                                {
                                    Console.WriteLine("\n\n\n\n\n I am sorry, but that was not an appropriate amount for a deposit.");
                                    Console.WriteLine("\n Please press any key to try again.");
                                }
                                else
                                {
                                    depositAmount = Math.Round(depositAmount, 2);
                                    savingsAccount.Deposit(depositAmount);
                                    savingsAccountWriter.WriteLine(DateTime.Now + " -- Made a deposit  +$" + depositAmount + ".  New balance: $" + savingsAccount.AccountBalance);
                                    Console.WriteLine("\n\n\n\n\n Your deposit of $" + depositAmount + " has been recorded in your Savings Account.\n");
                                    Console.WriteLine(" Current balance: $" + savingsAccount.AccountBalance);
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\n\n I am sorry, but this is not an appropriate format for a dollar amount.\n");
                                Console.WriteLine("Please be more careful when entering the deposit value.");
                            }
                        }
                        else if (depositAccountInput == "9" || depositAccountInput == "NINE")
                        {
                            Console.WriteLine("\n\n Press any key to go back to the Main Menu.");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n I am sorry, but that was not a correct selection.");
                            Console.WriteLine("\n Please press any key to try again.");
                        }

                        Console.ReadKey();
                    }
                }
                else if (userInput == "4" || userInput == "FOUR")//code for withdrawals
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine(" For which Account would you like to make a withdrawal?\n");
                        Console.WriteLine(" Please enter the corresponding number:\n\n\n");
                        Console.WriteLine("  1 -- Checking Account");//selecting the account type
                        Console.WriteLine("  2 -- Reserve Account");
                        Console.WriteLine("  3 -- Savings Account\n\n");
                        Console.WriteLine("  9 -- Exit to Main Menu\n\n\n\n\n");

                        string withdrawAccountInput = Console.ReadLine();
                        withdrawAccountInput = withdrawAccountInput.ToUpper();

                        if (withdrawAccountInput == "1" || withdrawAccountInput == "ONE")
                        {
                            Console.Clear();
                            Console.WriteLine(" Please enter the amount you wish to withdraw from your Checking account:\n\n");
                            Console.Write("        $");
                            try
                            {
                                double withdrawAmount = Convert.ToDouble(Console.ReadLine());

                                if (withdrawAmount > checkingAccount.AccountBalance) //cannot withdraw more than you have
                                {
                                    Console.WriteLine("\n\n\n\n\n I am sorry, but you do not have sufficient funds in this account.");
                                    Console.WriteLine("\n Please press any key to try again.");
                                }
                                else if (withdrawAmount <= 0) //cannot withdraw $0 or less
                                {
                                    Console.WriteLine("\n\n\n\n\n I am sorry, but that was not an appropriate amount for a withdrawal.");
                                    Console.WriteLine("\n Please press any key to try again.");
                                }
                                else
                                {
                                    withdrawAmount = Math.Round(withdrawAmount, 2); //rounds to nearest hundredth
                                    checkingAccount.Withdraw(withdrawAmount);
                                    checkingAccountWriter.WriteLine(DateTime.Now + " -- Made a withdrawal  -$" + withdrawAmount + ".  New balance: $" + checkingAccount.AccountBalance);
                                    Console.WriteLine("\n\n\n\n\n Your withdrawal of $" + withdrawAmount + " has been removed from your Checking Account.\n");
                                    Console.WriteLine(" Current balance: $" + checkingAccount.AccountBalance);
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\n\n I am sorry, but this is not an appropriate format for a dollar amount.\n");
                                Console.WriteLine("Please be more careful when entering the deposit value.");
                            }
                        }
                        else if (withdrawAccountInput == "2" || withdrawAccountInput == "TWO")
                        {
                            Console.Clear();
                            Console.WriteLine(" Please enter the amount you wish to withdraw from your Reserve account:\n\n");
                            Console.Write("        $");
                            try
                            {
                                double withdrawAmount = Convert.ToDouble(Console.ReadLine());

                                if (withdrawAmount > reserveAccount.AccountBalance)
                                {
                                    Console.WriteLine("\n\n\n\n\n I am sorry, but you do not have sufficient funds in this account.");
                                    Console.WriteLine("\n Please press any key to try again.");
                                }
                                else if (withdrawAmount <= 0)
                                {
                                    Console.WriteLine("\n\n\n\n\n I am sorry, but that was not an appropriate amount for a withdrawal.");
                                    Console.WriteLine("\n Please press any key to try again.");
                                }
                                else
                                {
                                    withdrawAmount = Math.Round(withdrawAmount, 2);
                                    reserveAccount.Withdraw(withdrawAmount);
                                    reserveAccountWriter.WriteLine(DateTime.Now + " -- Made a withdrawal  -$" + withdrawAmount + ".  New balance: $" + reserveAccount.AccountBalance);
                                    Console.WriteLine("\n\n\n\n\n Your withdrawal of $" + withdrawAmount + " has been removed from your Reserve Account.\n");
                                    Console.WriteLine(" Current balance: $" + reserveAccount.AccountBalance);
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\n\n I am sorry, but this is not an appropriate format for a dollar amount.\n");
                                Console.WriteLine("Please be more careful when entering the deposit value.");
                            }
                        }
                        else if (withdrawAccountInput == "3" || withdrawAccountInput == "THREE")
                        {
                            Console.Clear();
                            Console.WriteLine(" Please enter the amount you wish to withdraw from your Savings account:\n\n");
                            Console.Write("        $");
                            try
                            { 
                            double withdrawAmount = Convert.ToDouble(Console.ReadLine());

                                if (withdrawAmount > savingsAccount.AccountBalance)
                                {
                                    Console.WriteLine("\n\n\n\n\n I am sorry, but you do not have sufficient funds in this account.");
                                    Console.WriteLine("\n Please press any key to try again.");
                                }
                                else if (withdrawAmount <= 0)
                                {
                                    Console.WriteLine("\n\n\n\n\n I am sorry, but that was not an appropriate amount for a withdrawal.");
                                    Console.WriteLine("\n Please press any key to try again.");
                                }
                                else
                                {
                                    withdrawAmount = Math.Round(withdrawAmount, 2);
                                    savingsAccount.Withdraw(withdrawAmount);
                                    savingsAccountWriter.WriteLine(DateTime.Now + " -- Made a withdrawal  -$" + withdrawAmount + ".  New balance: $" + savingsAccount.AccountBalance);
                                    Console.WriteLine("\n\n\n\n\n Your withdrawal of $" + withdrawAmount + " has been removed from your Savings Account.\n");
                                    Console.WriteLine(" Current balance: $" + savingsAccount.AccountBalance);
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\n\n I am sorry, but this is not an appropriate format for a dollar amount.\n");
                                Console.WriteLine("Please be more careful when entering the deposit value.");
                            }
                        }
                        else if (withdrawAccountInput == "9" || withdrawAccountInput == "NINE")
                        {
                            Console.WriteLine("\n\n Press any key to go back to the Main Menu.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n\n I am sorry, but that was not a correct selection.\n\n");
                            Console.WriteLine("\n Please press any key to try again.");
                        }

                        Console.ReadKey();
                    }
                }
                else if (userInput == "9" || userInput == "NINE")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\n I am sorry, but that was not a correct selection.\n\n");
                    Console.WriteLine("\n Please press any key to try again.");
                }

                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine("\n\n\n   Thank you for using Humble National Bank!\n\n");
            Console.WriteLine("   It is our pleasure to help with your banking needs.");

            checkingAccountWriter.Close();
            savingsAccountWriter.Close();
            reserveAccountWriter.Close();

            Console.ReadKey();
        }
    }
}
