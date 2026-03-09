using Banking.Domain.ValueObjects;

namespace Banking.Domain.Aggregates;

public class Transaction
{
    public Guid Id {get; private set;}
    public Guid FromAccountId {get; private set;}
    public Guid ToAccountId {get; private set;}
    public Money Amount {get; private set;}
    public DateTime Timestamp {get; private set;}

    private Transaction()
    {
    }

    public Transaction(Guid id, Guid fromAccountId, Guid toAccountId, Money amount, DateTime timestamp)
    {
        if(amount.Amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero", nameof(amount));
        }

        Id = id;
        FromAccountId = fromAccountId;
        ToAccountId = toAccountId;
        Amount = amount ?? throw new ArgumentNullException(nameof(amount));
        Timestamp = timestamp;
    }
}