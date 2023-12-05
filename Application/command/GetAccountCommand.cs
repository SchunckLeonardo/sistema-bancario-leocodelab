using Application.repository;
using Domain.account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.command
{
    public class GetAccountCommand : ICommand<CurrentAccount>
    {
        public string Operation { get; set; } = "GetAccount";

        private readonly AccountRepository _repository;

        private string AccountNumber { get; }

        public GetAccountCommand(string accountNumber, AccountRepository repository)
        {
            _repository = repository;
            AccountNumber = accountNumber;

        }

        public CurrentAccount Execute()
        {
           var account = _repository.Get(AccountNumber);

            return account;
        }
    }
}
