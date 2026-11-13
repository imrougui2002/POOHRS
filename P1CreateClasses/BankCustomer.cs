namespace P1CreateClasses;

public class BankCustomer
{
    public string FirstName = "Tim";
    public string LastName = "Shao";
    public string CustomerId = "1010101010";

    public BankCustomer() { }

    public BankCustomer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public BankCustomer(string firstName, string lastName, string customerIdNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        CustomerId = customerIdNumber;
    }
}