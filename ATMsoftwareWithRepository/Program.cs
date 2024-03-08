using ATMsoftwareWithRepository.Data_Access_Layer;
using ATMsoftwareWithRepository.Domain_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ATMsoftwareWithRepository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAccountRepository accountRepository = new AccountRepository();
            ATM atm = new ATM(accountRepository);

            // Simulate creating and adding an account
            Account account = new Account { AccountNumber = "123456789", Balance = 1000 };
            accountRepository.AddAccount(account);

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("============================");
                Console.WriteLine("       ATM Menu:    ");
                Console.WriteLine("============================");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Withdraw Cash");
                Console.WriteLine("3. Deposit Cash");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter account number: ");
                        string accountNumber = Console.ReadLine();
                        double balance = atm.CheckBalance(accountNumber);
                        if (balance >= 0)
                        {
                            Console.WriteLine("Balance: $" + balance);
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter account number: ");
                        accountNumber = Console.ReadLine();
                        Console.Write("Enter amount to withdraw: $");
                        double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                        bool withdrawSuccess = atm.Withdraw(accountNumber, withdrawAmount);
                        if (withdrawSuccess)
                        {

                            Console.WriteLine("Withdrawal successful.");
                            Console.WriteLine("============================");
                        }
                        else
                        {
                            Console.WriteLine("Withdrawal failed.");
                            Console.WriteLine("============================");
                        }
                        break;

                    case "3":
                        Console.Write("Enter account number: ");
                        accountNumber = Console.ReadLine();
                        Console.Write("Enter amount to deposit: $");
                        double depositAmount = Convert.ToDouble(Console.ReadLine());
                        bool depositSuccess = atm.Deposit(accountNumber, depositAmount);
                        if (depositSuccess)
                        {
                            Console.WriteLine("Deposit successful.");
                        }
                        else
                        {
                            Console.WriteLine("Deposit failed.");
                        }
                        break;

                    case "4":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
    

