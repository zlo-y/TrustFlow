
using Microsoft.Extensions.DependencyInjection;
using Banking.Application.Interfaces;
using Banking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



namespace Banking.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddDbContext<BankingDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IBankingDbContext>(provider => provider.GetRequiredService<BankingDbContext>());    
        
        return services;
    }
}
