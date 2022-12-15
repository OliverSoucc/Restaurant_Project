using Domain;
using FluentAssertions;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace RestaurantProject.Tests.Repository;

public class IngredientsRepositoryTests
{
    private async Task<RestaurantDbContext> GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<RestaurantDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var databaseContext = new RestaurantDbContext(options);
        databaseContext.Database.EnsureCreated();
        if (await databaseContext.Ingredients.CountAsync() <= 0)
        {
            for (int i = 0; i < 10; i++)
            {
                databaseContext.Ingredients.Add(
                    new Ingredient()
                    {
                        Amount = 12,
                        Name = "Bread"
                    }
                );
                await databaseContext.SaveChangesAsync();
            }
        }
        return databaseContext;
    }

    [Fact]
    public async void IngredientsRepository_GetIngredients_ReturnIngredients()
    {
        // Arrange
        var dbContext = await GetDatabaseContext();
        var ingredientsRepository = new IngredientsRepository(dbContext);
        
        // Act
        var result = ingredientsRepository.GetAllIngredients();
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<List<Ingredient>>();
    }
    
    [Fact]
    public async void IngredientsRepository_GetIngredient_ReturnIngredient()
    {
        // Arrange
        var id = 1;
        var dbContext = await GetDatabaseContext();
        var ingredientsRepository = new IngredientsRepository(dbContext);
        
        // Act
        var result = ingredientsRepository.GetIngredient(id);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Ingredient>();
    }

    [Fact]
    public async void IngredientRepository_DeleteIngredient_ReturnIngredient()
    {
        // Arrange
        var id = 1;
        var dbContext = await GetDatabaseContext();
        var ingredientsRepository = new IngredientsRepository(dbContext);
        
        // Act
        var result = ingredientsRepository.DeleteIngredient(id);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Ingredient>();
    }

    [Fact]
    public async void IngredientRepository_CreateIngredient_ReturnIngredient()
    {
        // Arrange
        var ingredient = new Ingredient()
        {
            Amount = 99,
            Name = "Berries"
        };
        var dbContext = await GetDatabaseContext();
        var ingredientsRepository = new IngredientsRepository(dbContext);
        
        // Act
        var result = ingredientsRepository.CreateNewIngredient(ingredient);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Ingredient>();
        result.Should().BeEquivalentTo(ingredient);
    }
}