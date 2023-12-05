using Application.repository;
using Domain.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.command
{
    public class GetClientCommand : ICommand<Client>
    {
        public string Operation { get; set; } = "GetClient";

        public string CPF { get; }

        private readonly ClientRepository _repository;

        public GetClientCommand( string cpf, ClientRepository repository)
        {
            CPF = cpf;
            _repository = repository;
        }

        public Client Execute()
        {
            return _repository.Get(CPF);
        }
    }
}
