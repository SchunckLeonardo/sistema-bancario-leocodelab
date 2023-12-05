using Application.repository;
using Domain.account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.command
{
    public class DepositCommand : ICommand<CurrentAccount>
    {
        public string Operation { get; set; } = "Deposit";

        public CurrentAccount Account { get; set; }

        private readonly AccountRepository _repository;
        private double Amount { get; }

        public DepositCommand(CurrentAccount account, double amount ,AccountRepository repository)
        {
            _repository = repository;
            Account = account;
            Amount = amount;
        }

        public CurrentAccount Execute()
        {
            Account.Deposit(Amount);

            _repository.Update(Account);

            return null;
        }
    }
}
