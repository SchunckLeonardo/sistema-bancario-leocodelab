using Application.command;
using Application.repository;
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

            Create(accountRepository, clientRepository);

            Menu(accountRepository, clientRepository);
        }

        static void Create(AccountRepository accountRepository, ClientRepository clientRepository)
        {
            Console.WriteLine("Seja bem-vindo!");
            Console.WriteLine("Digite seu nome");
            var name = Console.ReadLine();

            Console.WriteLine("Digite seu CPF");
            var cpf = Console.ReadLine();
            var clientCreateCommand = new CreateClientCommand(name, cpf, clientRepository);
            var client = clientCreateCommand.Execute();

            var createAccountCommand = new CreateAccountCommand(cpf, accountRepository);
            var account = createAccountCommand.Execute();

            Console.WriteLine($"O número da sua conta é {account.Number}");
        }

        static void Menu(AccountRepository accountRepository, ClientRepository clientRepository)
        {
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Ver Saldo\n2 - Depositar\n3 - Sacar\n4 - Ver suas informações");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Digite o número da conta");
                    var accountNumber = Console.ReadLine();
                    var getAccountCommand = new GetAccountCommand(accountNumber, accountRepository);
                    var account = getAccountCommand.Execute();
                    Console.WriteLine($"Seu saldo é de R${account.Balance}");
                    break;
                case "2":
                    Console.WriteLine("Este mês tem 28 ou 29 dias");
                    break;
                case "3":
                    Console.WriteLine("Este mês tem 30 dias");
                    break;
                case "4":
                    Console.WriteLine("Este mês tem 30 dias");
                    break;
            }
        }

    }

}
