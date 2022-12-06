using Application.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repositories.DependencyResolver;

public static class DependencyResolverService
{
    public static void RegisterInfrastructureLayer(IServiceCollection services)
    {
        services.AddScoped<IDishRepository, DishRepository>();
        services.AddScoped<IIngredientRepository, IngredientsRepository>();
    }
}