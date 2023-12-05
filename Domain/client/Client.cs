using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.client
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CPF CPF { get; set; }

        public Client(Guid id, string name, string cpf)
        {
            Id = id;
            Name = name;
            CPF = new CPF(cpf);
        }

        public static Client Create(string name, string cpf) 
        {
            return new Client(new Guid(), name, cpf);
        }
    }
}
