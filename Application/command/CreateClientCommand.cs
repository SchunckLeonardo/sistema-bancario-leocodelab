using Domain.account;
using Domain.client;
using System.Runtime.CompilerServices;


namespace Application.command
{
    public class CreateClientCommand : ICommand<Client>
    {
        public string Operation { get; set; } = "CreateClient";
        private string Name { get;set; }
        private string CPF { get; set; }

        public CreateClientCommand(string name, string cpf)
        {
            Name = name;
            CPF = cpf;
        }

        public Client Execute()
        {
            var client = Client.Create(Name, CPF);

            return client;
        }
    }
}
