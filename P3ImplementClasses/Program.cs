using P3ImplementClasses;

Console.WriteLine("Creating BankCustomer objects...");
string firstName = "Tim";
string lastName = "Shao";

BankCustomer customer1 = new BankCustomer(firstName, lastName);

firstName = "Lisa";
BankCustomer customer2 = new BankCustomer(firstName, lastName);

firstName = "Sandy";
lastName = "Zoeng";
BankCustomer customer3 = new BankCustomer(firstName, lastName);

Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.CustomerId}");
Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.CustomerId}");
Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.CustomerId}");

Console.WriteLine("\nCreating BankAccount objects for customers...");
BankAccount account1 = new BankAccount(customer1.CustomerId, 1000, "Checking");
BankAccount account2 = new BankAccount(customer2.CustomerId, 1500, "Checking");
BankAccount account3 = new BankAccount(customer3.CustomerId, 2500, "Checking");

Console.WriteLine($"Account 1: Account # {account1.AccountNumber}, type {account1.AccountType}, balance {account1.Balance}, rate {BankAccount.InterestRate}, customer ID {account1.CustomerId}");
Console.WriteLine($"Account 2: Account # {account2.AccountNumber}, type {account2.AccountType}, balance {account2.Balance}, rate {BankAccount.InterestRate}, customer ID {account2.CustomerId}");
Console.WriteLine($"Account 3: Account # {account3.AccountNumber}, type {account3.AccountType}, balance {account3.Balance}, rate {BankAccount.InterestRate}, customer ID {account3.CustomerId}");

Console.WriteLine("\nUpdating BankCustomer 1's name...");
customer1.FirstName = "Thomas";
customer1.LastName = "Margand";
Console.WriteLine($"Updated BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.CustomerId}");

Console.WriteLine("\nDemonstrating BankAccount methods...");

Console.WriteLine("Depositing 500 into Account 1...");
account1.Deposit(500);
Console.WriteLine($"Account 1 after deposit: Balance = {account1.Balance}");

Console.WriteLine("Withdrawing 200 from Account 2...");
bool withdrawSuccess = account2.Withdraw(200);
Console.WriteLine($"Account 2 after withdrawal: Balance = {account2.Balance}, Withdrawal successful: {withdrawSuccess}");

Console.WriteLine("Transferring 300 from Account 3 to Account 1...");
bool transferSuccess = account3.Transfer(account1, 300);
Console.WriteLine($"Account 3 after transfer: Balance = {account3.Balance}, Transfer successful: {transferSuccess}");
Console.WriteLine($"Account 1 after receiving transfer: Balance = {account1.Balance}");

Console.WriteLine("Applying interest to Account 1...");
account1.ApplyInterest(30 / 365.0);
Console.WriteLine($"Account 1 after applying interest: Balance = {account1.Balance}");

Console.WriteLine("\nDemonstrating extension methods...");
Console.WriteLine(customer1.GreetCustomer());
Console.WriteLine($"Is customer1 ID valid? {customer1.IsValidCustomerId()}");
Console.WriteLine($"Can account2 withdraw 2000? {account2.CanWithdraw(2000)}");
Console.WriteLine($"Is account3 overdrawn? {account3.IsOverdrawn()}");

Console.WriteLine("\nDisplaying customer and account information...");
Console.WriteLine(customer1.DisplayCustomerInfo());
Console.WriteLine(account1.DisplayAccountInfo());
Console.WriteLine("\nDemonstrating new methods...");
double fee = AccountCalculations.CalculateTransactionFee(800, BankAccount.TransactionRate, BankAccount.MaxTransactionFee);
Console.WriteLine($"Transaction fee for 800: {fee}");

bool check = account2.IssueCashiersCheck(500);
Console.WriteLine($"Cashier's check from account 2: {check}, balance = {account2.Balance}");

account3.ApplyRefund(50);
Console.WriteLine($"Account 3 after refund: balance = {account3.Balance}");

Console.WriteLine("\nDemonstrating named and optional parameters...");

// Seulement l'ID du client : balance = 200 et type = Checking par défaut
BankAccount account4 = new BankAccount(customer1.CustomerId);
Console.WriteLine(account4.DisplayAccountInfo());

// ID + solde : le type reste Checking
BankAccount account5 = new BankAccount(customer1.CustomerId, 1500);
Console.WriteLine(account5.DisplayAccountInfo());

// ID + type donné par son nom : le solde reste 200
BankAccount account6 = new BankAccount(customer2.CustomerId, accountType: "Savings");
Console.WriteLine(account6.DisplayAccountInfo());

// Tout en paramètres nommés, dans un ordre différent
BankAccount account7 = new BankAccount(accountType: "Checking", balance: 5000, customerIdNumber: customer2.CustomerId);
Console.WriteLine(account7.DisplayAccountInfo());