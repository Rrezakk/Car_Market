using Market.DataAccessLayer.Interfaces;
using Market.DataAccessLayer.Repositories;
using Market.Services.Implementations;
using Market.Services.Interfaces;

namespace Market;

public static class Init
{
    public static void InitializeRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IEvCarRepository, EvCarRepository>();
    }
    public static void InitializeServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IEvCarService, EvCarService>();
    }
}
