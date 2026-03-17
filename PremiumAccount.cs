using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class PremiumAccount : BankAccount
    {
        public decimal OverdraftLimit { get; private set; }
        public decimal FixedFee { get; private set; }
        public PremiumAccount(string number, decimal balance, decimal limit, decimal fee)
            : base(number, balance)
        {
            OverdraftLimit = limit;
            FixedFee = fee;
        }
        public override void Withdraw(decimal amount)
        {
            decimal totalToCharge = amount + FixedFee;
            if (Balance - totalToCharge < -OverdraftLimit)
                Console.WriteLine("Ошибка: Превышен лимит овердрафта!");
            else
                Balance -= totalToCharge;
        }
        public override string GetAccountInfo() => 
            $"[Премиум] №{AccountNumber}, Баланс: {Balance}, Лимит овердрафта: {OverdraftLimit}, Комиссия: {FixedFee}";
    }
}