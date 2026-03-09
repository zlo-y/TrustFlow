using System.Runtime;
using Banking.Domain.ValueObjects;

namespace Banking.Domain.Aggregates;

// 
// Это класс, который представляет банковский счет. Он содержит идентификатор счета, имя владельца и баланс в виде объекта Money. Методы Deposit и Withdraw позволяют изменять баланс счета, при этом проверяя, что при снятии средств на счете достаточно денег.
// 
public class Account
{
    public Guid Id {get; private set;}
    public string Owner {get; private set;}
    public Money Balance {get; private set;}

    private Account()
    {
    }

    public Account(Guid id, string owner, Money balance)
    {
        if(string.IsNullOrWhiteSpace(owner))
        {
            throw new ArgumentException("Owner cannot be empty", nameof(owner));
        }

        Id = id;
        Owner = owner;
        Balance = balance ?? throw new ArgumentNullException(nameof(balance));
    }

    public void Deposit(Money amount)
    {
        Balance += amount;
    }
    
    public void Withdraw(Money amount)
    {
        if(Balance < amount)
        {
            throw new InvalidOperationException("Недостаточно средств на счете");
        }
        Balance -= amount;
    }
}