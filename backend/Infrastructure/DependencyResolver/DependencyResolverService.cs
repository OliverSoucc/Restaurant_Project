using Application.Interfaces.Services;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyResolver;

public static class DependencyResolverService
{
    public static void RegisterInfrastructureLayer(IServiceCollection services)
    {
        services.AddScoped<IDishRepository, DishRepository>();
        services.AddScoped<IIngredientRepository, IngredientsRepository>();
        services.AddScoped<IDishIngredientRepository, DishIngredientRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IReservationTableRepository, ReservationTableRepository>();
    }
}