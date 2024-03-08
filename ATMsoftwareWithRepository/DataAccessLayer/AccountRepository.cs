using ATMsoftwareWithRepository.Domain_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMsoftwareWithRepository.Data_Access_Layer
{
    public class AccountRepository : IAccountRepository 
    {
        private List<Account> accounts = new List<Account>();

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public Account GetAccount(string accountNumber)
        {
            return accounts.FirstOrDefault(ac => ac.AccountNumber == accountNumber);
        }
        public void UpdateAccount(Account account)
        {
            Account existingAccount = GetAccount(account.AccountNumber);
            if (existingAccount != null)
            {
                existingAccount.Balance = account.Balance;
            }
        }
    }
}
