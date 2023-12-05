using Application.command;
using Domain.account;
using Domain.client;
using System;


namespace Application.usecase
{
    public class CreateAccountCommand : ICommand<CurrentAccount>
    {
        public string Operation { get; set; } = "CreateAccount";
        private string CPF { get; }
        public CreateAccountCommand(string cpf) 
        {
              CPF = cpf;
        }

        public CurrentAccount Execute()
        {
            var accountNumber = $"{new Random().Next(00000, 99999)}-{new Random().Next(0, 9)}";
            var accountBank = "0001";
            var accountAgency = $"{new Random().Next(00, 10)}";
            var account = CurrentAccount.Create(accountNumber, accountBank, accountAgency, CPF);

            return account;
        }
    }
}
