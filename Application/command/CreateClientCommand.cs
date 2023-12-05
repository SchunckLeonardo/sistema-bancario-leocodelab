using Application.repository;
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

        private readonly ClientRepository _repository;

        public CreateClientCommand(string name, string cpf, ClientRepository repository)
        {
            Name = name;
            CPF = cpf;
            _repository = repository;
        }

        public Client Execute()
        {
            var client = Client.Create(Name, CPF);

            _repository.Save(client);

            return client;
        }
    }
}
