namespace Banking.Domain.ValueObjects;

// 
// Объект Value Object, который представляет денежную сумму. Он содержит сумму и валюту. Конструктор проверяет, что сумма не может быть отрицательной. Оператор + позволяет складывать две денежные суммы, при этом проверяя, что они имеют одинаковую валюту.
// 
public record Money
{
    public decimal Amount{get; init;}
    public string Currency{get; init;}

    private Money() 
    { 
        Amount = 0;
        Currency = string.Empty;
    }

    public Money(decimal amount, string currency)
    {
        if(amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative", nameof(amount));
        }
        if(string.IsNullOrWhiteSpace(currency))
        {
            throw new ArgumentException("Currency cannot be empty", nameof(currency));
        }
        Amount = amount;
        Currency = currency.ToUpperInvariant();
    }

    public static Money Zero(string currency) => new Money(0, currency);

    public static Money operator +(Money a, Money b)
    {
        CheckCurrency(a, b);

        return new Money(a.Amount + b.Amount, a.Currency);
    }

    public static Money operator -(Money a, Money b)
    {
        CheckCurrency(a, b);

        return new Money(a.Amount - b.Amount, a.Currency);
    }

    public static bool operator > (Money a, Money b)
    {
        CheckCurrency(a, b);

        return a.Amount > b.Amount;
    }

    public static bool operator < (Money a, Money b)
    {
        CheckCurrency(a, b);

        return a.Amount < b.Amount;
    }

    public static bool operator >=(Money a, Money b) => a > b || a.Amount == b.Amount;
    public static bool operator <=(Money a, Money b) => a < b || a.Amount == b.Amount;
  

    private static void CheckCurrency(Money a, Money b)
    {
        if(a.Currency != b.Currency)
        {
            throw new InvalidOperationException("Cannot operate on money with different currencies");
        }
    }


}