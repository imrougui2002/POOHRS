namespace P2UpdateClasses;

public class BankAccount
{
    private static int s_nextAccountNumber;
    public static double InterestRate;
    public int AccountNumber { get; }
    public string CustomerId { get; }
    public double Balance { get; set; } = 0;
    public string AccountType { get; set; } = "Checking";

    static BankAccount()
    {
        Random random = new Random();
        s_nextAccountNumber = random.Next(10000000, 20000000);
        InterestRate = 0;
    }

    public BankAccount(string customerIdNumber)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
    }

    public BankAccount(string customerIdNumber, double balance, string accountType)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }
}