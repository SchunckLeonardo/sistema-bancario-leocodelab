using Application.repository;
using Domain.account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.repository
{
    public class AccountRepositoryMemory : AccountRepository
    {
        public List<CurrentAccount> Accounts = new List<CurrentAccount>();

        public CurrentAccount Get(string accountNumber)
        {
            var account = Accounts.FirstOrDefault(account => account.Number == accountNumber);

            if(account is null) 
            {
                throw new Exception("Account was not found");
            }

            return account;
        }

        public void Save(CurrentAccount account)
        {
            Accounts.Add(account);
        }
        public void Delete(string accountNumber)
        {
            var account = Get(accountNumber);
            Accounts.Remove(account);
        }
    }
}
