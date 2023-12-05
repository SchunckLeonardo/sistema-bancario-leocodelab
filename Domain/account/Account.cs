using Domain.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.account
{
    public abstract class Account
    {
        public string Number { get; }
        public string Agency { get; }
        public string Bank { get; }
        public double Balance { get; protected set; }
        public CPF ClientCPF { get; }

        public abstract void Credit(double amount);

        public abstract void Deposit(double amount);

        public Account(string number, string agency, string bank, int initialBalance, string clientCPF)
        {
            Number = number;
            Agency = agency;
            Bank = bank;
            Balance = initialBalance;
            ClientCPF = new CPF(clientCPF);
        }

    }

}
