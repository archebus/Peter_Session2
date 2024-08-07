using System.ComponentModel;
using System.Data.SqlTypes;
using System.Security.Principal;

namespace gelos_bank;

class Program {

    /* Banking System:
    Classes: Bank, Account, Customer, Transaction, Loan, CreditCard, Branch
    Interactions: Deposits and withdrawals, transferring funds, applying for loans, processing transactions. */

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
}

class Bank {
    
    public int ID { get; set; }
    public string Name { get; set; } = default!;
    public List<Customer> Customers { get; set; } = new();
    public List<Account> Accounts { get; set; } = new();

    public Bank(int id, string name)
    {
        ID = id;
        Name = name;    
    }

    public Customer NewCustomer(int id, string name) {
        var cust = new Customer(id, name);
        Customers.Add(cust);
        return cust;
    }

    public Account NewAccount(int number) {
        var acc = new Account(number);
        Accounts.Add(acc);
        return acc;
    }   
}

class Customer {
    public int ID { get; set; }
    public string Name { get; set; } = default!;
    public List<Account> Accounts { get; set; } = new();

    public Customer (int id, string name) {
        ID = id;
        Name = name;
    }

    public Account LinkAccount(Account acc) {
        Accounts.Add(acc);
        return acc;
    }

}

class Account {
    public int Number { get; set; }
    public double Balance { get; set; } = 0;
    public List<Transaction> Transactions { get; set; } = new();
    public List<Loan> Loans { get; set; } = new();
    public List<CreditCard> CreditCards { get; set; } =new();

    public Account(int number)
    {
        Number = number;
    }

    public void Deposit(double amount) {
        Balance += amount;
        Transactions.Add(new Transaction(amount));
    }

    public void Withdraw(double amount) {
        if (amount <= Balance) {
            Balance -= amount;
            Transactions.Add(new Transaction(-amount));
        } else {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public void Transfer(Account toAccount, double amount) {
        if (amount <= Balance) {
            Withdraw(amount);
            toAccount.Deposit(amount);
        } else {
            Console.WriteLine("Insufficient funds for transfer.");
        }
    }
}

class Transaction {
    public double Amount { get; set; }
    public Transaction(double amount)
    {
        Amount = amount;
    }
}

class Loan {
    public double Amount { get; set; }
}

class CreditCard {
    public int Number { get; set; }
}