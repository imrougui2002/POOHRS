namespace P3ImplementClasses;

public partial class BankCustomer
{
    public string ReturnFullName()
    {
        return $"{FirstName} {LastName}";
    }

    public void UpdateName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string DisplayCustomerInfo()
    {
        return $"Customer ID: {CustomerId}, Name: {ReturnFullName()}";
    }
}