using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CurrentAccount : Account
    { 
        public CurrentAccount(string number, string agency,string bank) :base(number, agency, bank ,0){}

        public static CurrentAccount Create(string accountNumber, string accountAgency, string bank) 
        {
            return new CurrentAccount(accountNumber, accountAgency, bank);
        }

        public override void Credit(int amount)
        {
            Balance -= amount;
        }

        public override void Deposit(int amount)
        {
            Balance += amount;
        }

    }
}
