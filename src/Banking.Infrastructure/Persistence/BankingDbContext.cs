using Microsoft.EntityFrameworkCore;
using Banking.Application.Interfaces;
using Banking.Domain.Aggregates;

namespace Banking.Infrastructure.Persistence;

public class BankingDbContext : DbContext , IBankingDbContext
{
    public BankingDbContext(DbContextOptions<BankingDbContext> options) :base(options){}
    
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(builder =>
        {
            builder.HasKey(a => a.Id);
            builder.OwnsOne(a => a.Balance, b =>
            {
                b.Property(m => m.Amount).HasColumnName("BalanceAmount");
                b.Property(m => m.Currency).HasColumnName("BalanceCurrency");
            });
        });

        modelBuilder.Entity<Transaction>(builder =>
       {
           builder.HasKey(t => t.Id);
           builder.OwnsOne(t => t.Amount, b =>{
               b.Property(m => m.Amount).HasColumnName("TransactionAmount");
               b.Property(m => m.Currency).HasColumnName("TransactionCurrency");
            });
        });
         
        base.OnModelCreating(modelBuilder);
    }
}