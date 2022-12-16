using System.Runtime.CompilerServices;
using Domain;
using FakeItEasy;
using FluentAssertions;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace RestaurantProject.Tests.Repository;

public class DishRepositoryTests
{
    private async Task<RestaurantDbContext> GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<RestaurantDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var databaseContext = new RestaurantDbContext(options);
        databaseContext.Database.EnsureCreated();
        if (await databaseContext.Dishes.CountAsync() <= 0)
        {
            for (int i = 0; i < 10; i++)
            {
                databaseContext.Dishes.Add(
                    new Dish()
                    {
                        Description = "This is pizza",
                        Name = "Pizza",
                        Price = 12,
                        WeekDay = "Monday",
                    }
                );
                await databaseContext.SaveChangesAsync();
            }
        }
        return databaseContext;
    }

    [Fact]
    public async void DishesRepository_GetDishes_ReturnDishes()
    {
        // Arrange
        var dbContext = await GetDatabaseContext();
        var dishesRepository = new DishRepository(dbContext);
        
        // Act
        var result = dishesRepository.GetAllDishes();
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<List<Dish>>();
    }
    
    [Fact]
    public async void DishesRepository_GetDish_ReturnDish()
    {
        // Arrange
        var id = 1;
        var dbContext = await GetDatabaseContext();
        var dishesRepository = new DishRepository(dbContext);
        // Act
        var result = dishesRepository.GetDish(id);
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Dish>();
    }

    [Fact]
    public async void DishesRepository_CreateDish_ReturnDish()
    {
        // Arrange
        Dish dish = new Dish()
        {
            Description = "I am dish",
            Name = "New dish",
            Price = 15,
            WeekDay = "Tuesday",
        };
        var context = await GetDatabaseContext();
        var dishesRepository = new DishRepository(context);
        
        // Act
        var result = dishesRepository.CreateNewDish(dish);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Dish>();
        result.Should().BeEquivalentTo(dish);
    }

    [Fact]
    public async void DishesRepository_DeleteDish_ReturnDish()
    {
        // Arrange
        var id = 1;
        var context = await GetDatabaseContext();
        var dishesRepository = new DishRepository(context);
        
        // Act
        var result = dishesRepository.DeleteDish(id);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Dish>();
    }
}