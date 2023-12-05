using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.account
{
    public class CurrentAccount : Account
    {
        public CurrentAccount(string number, string agency, string bank, string cpf) : base(number, agency, bank, 0, cpf) { }

        public static CurrentAccount Create(string accountNumber, string accountAgency, string bank, string cpf)
        {
            return new CurrentAccount(accountNumber, accountAgency, bank, cpf);
        }

        public override void Credit(double amount)
        {
            Balance -= amount;
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
        }

    }
}
