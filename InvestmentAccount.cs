using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class InvestmentAccount : BankAccount
    {
        public Dictionary<string, decimal> Assets { get; private set; } = new Dictionary<string, decimal>();
        public InvestmentAccount(string number, decimal balance) : base(number, balance) { }
        public void AddAsset(string name, decimal annualYield) => Assets.Add(name, annualYield);
        public decimal ProjectYearlyGrowth()
        {
            decimal totalGrowth = 0;
            foreach (var yield in Assets.Values) totalGrowth += yield;
            return totalGrowth;
        }
        public override void Withdraw(decimal amount)
        {
            if (Balance < amount) Console.WriteLine("Ошибка: Недостаточно средств!");
            else Balance -= amount;
        }
        public override string GetAccountInfo() =>
            $"[Инвестиционный] №{AccountNumber}, Баланс: {Balance}, Активoв: {Assets.Count}";
    }
}