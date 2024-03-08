using ATMsoftwareWithRepository.Data_Access_Layer;
using ATMsoftwareWithRepository.Domain_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ATMsoftwareWithRepository.Data_Access_Layer
{
    public class ATM
    {
        private IAccountRepository _accountRepository;

        public ATM(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public bool Withdraw(string accountNumber, double amount)
        {
            Account account = _accountRepository.GetAccount(accountNumber);
            if (account == null || amount <= 0 || amount > account.Balance)
            {
                return false;
            }

            account.Balance -= amount;
            _accountRepository.UpdateAccount(account);
            return true;
        }
        public bool Deposit(string accountNumber, double amount)
        {
            Account account = _accountRepository.GetAccount(accountNumber);
            if (account == null || amount <= 0)
            {
                return false;
            }

            account.Balance += amount;
            _accountRepository.UpdateAccount(account);
            return true;
        }

        public double CheckBalance(string accountNumber)
        {
            Account account = _accountRepository.GetAccount(accountNumber);
            return account?.Balance ?? -1;
        }
    }
}
