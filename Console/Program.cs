using Application.command;
using Application.usecase;
using Infra.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] arg)
        {
            var accountRepository = new AccountRepositoryMemory();
            var clientRepository = new ClientRepositoryMemory();

            Console.WriteLine("Seja bem-vindo!");
            Console.WriteLine("Digite seu nome");
            var name = Console.ReadLine();

            Console.WriteLine("Digite seu CPF");
            var cpf = Console.ReadLine();
            var clientCreateCommand = new CreateClientCommand(name, cpf, clientRepository);
            var client = clientCreateCommand.Execute();

            var createAccountCommand = new CreateAccountCommand(cpf, accountRepository);
            var account = createAccountCommand.Execute();
            
        }
    }

}
