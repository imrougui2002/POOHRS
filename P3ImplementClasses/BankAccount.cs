namespace P3ImplementClasses;

public class BankAccount
{
    private static int s_nextAccountNumber;

    public static double InterestRate { get; private set; }
    public static double TransactionRate { get; private set; }
    public static double MaxTransactionFee { get; private set; }
    public static double OverdraftRate { get; private set; }
    public static double MaxOverdraftFee { get; private set; }

    public int AccountNumber { get; }
    public string CustomerId { get; }
    public double Balance { get; private set; } = 0;
    public string AccountType { get; set; } = "Checking";

    static BankAccount()
    {
        Random random = new Random();
        s_nextAccountNumber = random.Next(10000000, 20000000);
        InterestRate = 0.00;
        TransactionRate = 0.01;
        MaxTransactionFee = 10;
        OverdraftRate = 0.05;
        MaxOverdraftFee = 10;
    }

    public BankAccount(string customerIdNumber, double balance = 200, string accountType = "Checking")
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    public bool Withdraw(double amount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }

    public bool Transfer(BankAccount targetAccount, double amount)
    {
        if (Withdraw(amount))
        {
            targetAccount.Deposit(amount);
            return true;
        }
        return false;
    }

    public void ApplyInterest(double years)
    {
        Balance += AccountCalculations.CalculateCompoundInterest(Balance, InterestRate, years);
    }

    public bool IssueCashiersCheck(double amount)
    {
        if (amount > 0 && Balance >= amount + BankAccount.MaxTransactionFee)
        {
            Balance -= amount;
            Balance -= AccountCalculations.CalculateTransactionFee(amount, BankAccount.TransactionRate, BankAccount.MaxTransactionFee);
            return true;
        }
        return false;
    }

    public void ApplyRefund(double refund)
    {
        Balance += refund;
    }

    public string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {InterestRate}, Customer ID: {CustomerId}";
    }
}