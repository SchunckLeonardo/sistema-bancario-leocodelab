using Application.repository;
using Domain.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.repository
{
    public class ClientRepositoryMemory : ClientRepository
    {
        
        public List<Client> Clients = new List<Client>();
        public Client Get(string document)
        {
            var client = Clients.FirstOrDefault(client => client.CPF.Value == document);
            
            if(client == null)
            {
                throw new Exception("Client was not found");
            }

            return client;
        }
        public void Save(Client client)
        {
            Clients.Add(client);
        }
        public void Delete(string document)
        {
            var client = Get(document);
            Clients.Remove(client);
        }
    }
}
