using Domain.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.repository
{
    public interface ClientRepository
    {
        public Client Get(string document);

        public void Save(Client client);

        public void Delete(string document);
    }
}
