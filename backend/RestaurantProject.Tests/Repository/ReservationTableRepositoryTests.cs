using Domain;
using FluentAssertions;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace RestaurantProject.Tests.Repository;

public class ReservationTableRepositoryTests
{
    private async Task<RestaurantDbContext> GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<RestaurantDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var databaseContext = new RestaurantDbContext(options);
        databaseContext.Database.EnsureCreated();
        if (await databaseContext.ReservationTables.CountAsync() <= 0)
        {
            for (int i = 0; i < 10; i++)
            {
                databaseContext.ReservationTables.Add(
                    new ()
                    {
                        Location = "Window",
                        Number = 5,
                        NumberOfSeats = 22
                    }
                );
                await databaseContext.SaveChangesAsync();
            }
        }
        return databaseContext;
    }

    [Fact]
    public async void ReservationTableRepository_GetReservationTables_ReturnsReservationTables()
    {
        // Arrange
        var context = await GetDatabaseContext();
        var repository = new ReservationTableRepository(context);
        
        // Act
        var result = repository.GetReservationTables();
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<List<ReservationTable>>();
    }
    
    [Fact]
    public async void ReservationTableRepository_GetReservationTable_ReturnsReservationTable()
    {
        // Arrange
        var id = 1;
        var context = await GetDatabaseContext();
        var repository = new ReservationTableRepository(context);
        
        // Act
        var result = repository.GetReservationTable(id);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ReservationTable>();
    }
    
    [Fact]
    public async void ReservationTableRepository_CreateReservationTable_ReturnsReservationTable()
    {
        // Arrange
        ReservationTable reservationTable = new()
        {
            Location = "Near Entrance",
            Number = 22,
            NumberOfSeats = 3
        };
        var context = await GetDatabaseContext();
        var repository = new ReservationTableRepository(context);
        
        // Act
        var result = repository.CreateReservationTable(reservationTable);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ReservationTable>();
        result.Should().BeEquivalentTo(reservationTable);
    }
    
    [Fact]
    public async void ReservationTableRepository_DeleteReservationTable_ReturnsReservationTable()
    {
        // Arrange
        var id = 1;
        var context = await GetDatabaseContext();
        var repository = new ReservationTableRepository(context);
        
        // Act
        var result = repository.DeleteReservationTable(id);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ReservationTable>();
    }
}