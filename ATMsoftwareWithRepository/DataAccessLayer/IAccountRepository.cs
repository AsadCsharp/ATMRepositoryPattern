using ATMsoftwareWithRepository.Domain_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMsoftwareWithRepository.Data_Access_Layer
{
    public interface IAccountRepository
    {
        void AddAccount(Account account);
        Account GetAccount(string accountNumber);
        void UpdateAccount(Account account);
    }
}
