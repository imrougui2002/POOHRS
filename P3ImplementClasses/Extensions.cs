namespace P3ImplementClasses;

public static class BankCustomerExtensions
{
    public static bool IsValidCustomerId(this BankCustomer customer)
    {
        return customer.CustomerId.Length == 10;
    }

    public static string GreetCustomer(this BankCustomer customer)
    {
        return $"Hello, {customer.ReturnFullName()}!";
    }
}

public static class BankAccountExtensions
{
    public static bool IsOverdrawn(this BankAccount account)
    {
        return account.Balance < 0;
    }

    public static bool CanWithdraw(this BankAccount account, double amount)
    {
        return account.Balance >= amount;
    }
}