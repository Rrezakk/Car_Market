using Market.DataAccessLayer.Abstractions;
using Market.DataAccessLayer.Repositories;
using Market.Services.Implementations;
using Market.Services.Interfaces;

namespace Market;

public static class Init
{
    public static void InitializeRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<EfBasketRepository>();
        serviceCollection.AddScoped<EfEvCarRepository>();
        serviceCollection.AddScoped<EfManufacturersRepository>();
        serviceCollection.AddScoped<EfOrderRepository>();
        serviceCollection.AddScoped<EfUserProfilesRepository>();
        serviceCollection.AddScoped<EfUsersRepository>();
    }
    public static void InitializeServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IEvCarService, EvCarService>();
        serviceCollection.AddScoped<IAccountService, AccountService>();
        serviceCollection.AddScoped<IManufacturerService, ManufacturerService>();

    }
}
