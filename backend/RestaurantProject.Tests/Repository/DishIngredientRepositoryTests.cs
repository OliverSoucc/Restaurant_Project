using Application.DTOs;
using AutoMapper;
using Domain;
using FakeItEasy;
using FluentAssertions;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace RestaurantProject.Tests.Repository;

public class DishIngredientRepositoryTests
{
    private async Task<RestaurantDbContext> GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<RestaurantDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var databaseContext = new RestaurantDbContext(options);
        databaseContext.Database.EnsureCreated();
        if (await databaseContext.DishIngredients.CountAsync() <= 0)
        {
            for (int i = 0; i < 10; i++)
            {
                databaseContext.Dishes.Add(
                    new ()
                    {
                        Description = "This is a fantastic piece of meal",
                        Name = "Pizza",
                        WeekDay = "Tuesday",
                        Price = 22
                    }
                );
                databaseContext.Ingredients.Add(
                    new ()
                    {
                        Amount = 2,
                        Name = "Mozzarella"
                    }
                );
                await databaseContext.SaveChangesAsync();
            }
        }
        return databaseContext;
    }

    [Fact]
    public async void DishIngredientRepository_AddDishIngredient_Returns()
    {
        // Arrange
        var context = await GetDatabaseContext();
        var mapper = A.Fake<IMapper>();
        var repository = new DishIngredientRepository(context, mapper);
        
        DishIngredient dishIngredient = new DishIngredient()
        {
            DishId = 1,
            IngredientId = 1
        };
        
        // Act
        var result = repository.AddDishIngredient(dishIngredient);
        
        // Assert
        result.Should().NotBeNull();
    }
}