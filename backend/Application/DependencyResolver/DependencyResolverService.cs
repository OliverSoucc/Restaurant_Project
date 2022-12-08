using Application.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyResolver;

public static class DependencyResolverService
{
    public static void RegisterApplicationLayer(IServiceCollection services)
    {
        services.AddScoped<IDishService, DishService>();
        services.AddScoped<IIngredientService, IngredientService>();
        services.AddScoped<IDishIngredientService, DishIngredientService>();
    }
}