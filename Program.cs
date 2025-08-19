static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance < 0m)
        {
            return 3.213f;
        }
        else if (balance < 1000m)
        {
            return 0.5f;
        }
        else if (balance < 5000m)
        {
            return 1.621f;
        }
        else
        {
            return 2.475f;
        }
    }

    public static decimal Interest(decimal balance)
    {
        float interestRate = InterestRate(balance);
        return balance * (decimal)interestRate / 100;
    }

    public static decimal AnnualBalanceUpdate(decimal balance) => balance + Interest(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;
        decimal currentBalance = balance;
        while (currentBalance < targetBalance)
        {
            currentBalance += Interest(currentBalance);
            years++;
            Console.WriteLine("Initial Balance: {0} Year {1}", currentBalance, years);
        }
        return years;
    }
    public static void Main(string[] args)
    {
        YearsBeforeDesiredBalance(100.0m, 125.80m);
    }
}
