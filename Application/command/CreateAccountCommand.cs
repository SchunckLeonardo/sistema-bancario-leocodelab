using Application.command;
using Application.repository;
using Domain.account;
using Domain.client;
using System;


namespace Application.usecase
{
    public class CreateAccountCommand : ICommand<CurrentAccount>
    {
        public string Operation { get; set; } = "CreateAccount";
        private string CPF { get; }
        private readonly AccountRepository _repository;
        public CreateAccountCommand(string cpf, AccountRepository repository) 
        {
              CPF = cpf;
            _repository = repository;
        }

        public CurrentAccount Execute()
        {
            var accountNumber = $"{new Random().Next(00000, 99999)}-{new Random().Next(0, 9)}";
            var accountBank = "0001";
            var accountAgency = $"{new Random().Next(00, 100)}";
            var account = CurrentAccount.Create(accountNumber, accountAgency,accountBank, CPF);

            _repository.Save(account);
            return account;
        }
    }
}
