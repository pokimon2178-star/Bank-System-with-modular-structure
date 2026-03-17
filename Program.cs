using System;
using System.Collections.Generic;

namespace BankSystem 
{ 
    public abstract class BankAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; protected set; }
        public BankAccount(string number, decimal initialBalance)
        {
            AccountNumber = number;
            Balance = initialBalance;
        }
        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Пополнение: +{amount}. Баланс: {Balance}");
        }
        public abstract void Withdraw(decimal amount);
        public abstract string GetAccountInfo();
        public override string ToString() => GetAccountInfo();
    }
}