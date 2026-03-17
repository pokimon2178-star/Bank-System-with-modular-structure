using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class SavingAccount : BankAccount
    {
        public decimal MinBalance { get; private set; }
        public double MonthlyRate { get; private set; }
        public SavingAccount(string number, decimal balance, decimal minBalance, double rate)
            : base(number, balance)
        {
            MinBalance = minBalance;
            MonthlyRate = rate;
        }
        public decimal CalculateMonthlyProfit() => Balance * (decimal)MonthlyRate;
        public override void Withdraw(decimal amount)
        {
            if (Balance - amount < MinBalance)
                Console.WriteLine("Ошибка: Превышен лимит минимального остатка!");
            else
                Balance -= amount;
        }
        public override string GetAccountInfo() => 
            $"[Сберегательный] №{AccountNumber}, Баланс: {Balance}, Мин. остаток: {MinBalance}, Ставка: {MonthlyRate * 100}%";
    }
}