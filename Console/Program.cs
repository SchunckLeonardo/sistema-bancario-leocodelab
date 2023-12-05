using Application.command;
using Application.usecase;
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

            Console.WriteLine("Seja bem-vindo!");
            Console.WriteLine("Digite seu nome");
            var name = Console.ReadLine();

            Console.WriteLine("Digite seu CPF");
            var cpf = Console.ReadLine();
            var clientCreateCommand = new CreateClientCommand(name, cpf);
            var client = clientCreateCommand.Execute();

            var createAccountCommand = new CreateAccountCommand(cpf);
            var account = createAccountCommand.Execute();
            Console.WriteLine($"O número da sua conta é {account.Number}");
            Console.WriteLine($"O saldo da sua conta é {account.Balance}");
            Console.WriteLine($"O banco da sua conta é {account.Bank}");
            Console.WriteLine($"A agência da sua conta é {account.Agency}");
        }
    }

}
