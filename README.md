# Gelos Bank System

This project is a simple simulation of a banking system implemented in C#. It includes basic functionalities such as creating customers and accounts, making deposits and withdrawals, and transferring funds between accounts. This was developed as a homework assignment for a programming class to practice the application of simple classes to a specific problem domain.

## Classes and Interactions

### Classes

- **Bank**: Represents the bank itself, containing customers and accounts.
- **Customer**: Represents a customer with a unique ID and a list of accounts.
- **Account**: Represents a bank account with a unique number, balance, transactions, loans, and credit cards.
- **Transaction**: Represents a transaction with an amount.
- **Loan**: Represents a loan with an amount.
- **CreditCard**: Represents a credit card with a unique number.

### Interactions

- **Deposits and Withdrawals**: Adding or removing money from an account.
- **Transferring Funds**: Moving money from one account to another.
- **Linking Accounts to Customers**: Associating bank accounts with customers.

## Usage

To run this project, compile and execute the `Main` method in the `Program` class. The main method demonstrates:

- Creating a bank.
- Creating a customer.
- Creating accounts and linking them to the customer.
- Performing deposits and withdrawals.
- Transferring funds between accounts.

```csharp
static void Main() {
    var bank = new Bank(01, "Gelos");

    // Creating a new customer
    var cust = bank.NewCustomer(01, "George");

    // Creating a new account and linking it to the customer
    var acc = bank.NewAccount(83489230);
    cust.LinkAccount(acc);

    // Depositing money into the account
    acc.Deposit(500);
    Console.WriteLine($"Account Balance after deposit: {acc.Balance}");

    // Withdrawing money from the account
    acc.Withdraw(200);
    Console.WriteLine($"Account Balance after withdrawal: {acc.Balance}");

    // Creating another account and linking it to the customer
    var acc2 = bank.NewAccount(83489231);
    cust.LinkAccount(acc2);

    // Transferring funds between accounts
    acc.Transfer(acc2, 100);
    Console.WriteLine($"Account 1 Balance after transfer: {acc.Balance}");
    Console.WriteLine($"Account 2 Balance after transfer: {acc2.Balance}");
}
