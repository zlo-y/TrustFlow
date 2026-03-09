using MediatR;
using Banking.Application.Interfaces;
using Banking.Domain.Aggregates;
using Banking.Domain.ValueObjects;


namespace Banking.Application.Features.Accounts.Commands.CreateAccount;

// 
// Хендлер для обработки команды создания нового банковского счета.
// 
public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
{
    private readonly IBankingDbContext _context;

    public CreateAccountCommandHandler(IBankingDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var money = new Money(request.InitialAmount, request.Currency);
        var account = new Account(Guid.NewGuid(), request.Owner, money);

        _context.Accounts.Add(account);
        await _context.SaveChangesAsync(cancellationToken);

        return account.Id;
    }
}