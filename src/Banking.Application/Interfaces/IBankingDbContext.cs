using Microsoft.EntityFrameworkCore;
using Banking.Domain.Aggregates;

namespace Banking.Application.Interfaces;

// 
// Интерфейс для доступа к базе данных.
// 
public interface IBankingDbContext
{
    DbSet<Account> Accounts { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}