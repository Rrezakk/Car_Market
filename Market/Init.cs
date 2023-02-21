using Market.DataAccessLayer.Abstractions;
using Market.DataAccessLayer.Repositories;
using Market.Services.Implementations;
using Market.Services.Interfaces;

namespace Market;

public static class Init
{
    public static void InitializeRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<EfEvCarRepository>();
        serviceCollection.AddScoped<EfUsersRepository>();
    }
    public static void InitializeServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IEvCarService, EvCarService>();
        serviceCollection.AddScoped<IAccountService, AccountService>();
    }
}
