using System;
using BankSystem;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Тестирование банковской системы ===");

        Console.Write("Введите начальный баланс для Сберегательного счета: ");
        decimal saveBal = decimal.Parse(Console.ReadLine());
        var saveAcc = new SavingAccount("S001", saveBal, 500, 0.05);
        Console.WriteLine(saveAcc);
        Console.WriteLine($"Прибыль за месяц: {saveAcc.CalculateMonthlyProfit()}");

        Console.Write("\nСумма для снятия с Премиум счета (лимит овердрафта 1000): ");
        decimal premWithdraw = decimal.Parse(Console.ReadLine());
        var premAcc = new PremiumAccount("P001", 100, 1000, 10);
        premAcc.Withdraw(premWithdraw);
        Console.WriteLine(premAcc);

        var invAcc = new InvestmentAccount("I001", 5000);
        invAcc.AddAsset("Stocks (AAPL)", 450);
        invAcc.AddAsset("Bonds", 120);
        Console.WriteLine($"\n{invAcc}");
        Console.WriteLine($"Прогноз годового роста активов: {invAcc.ProjectYearlyGrowth()}");

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}