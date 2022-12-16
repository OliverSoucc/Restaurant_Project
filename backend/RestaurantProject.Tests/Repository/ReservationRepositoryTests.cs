using Domain;
using FluentAssertions;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace RestaurantProject.Tests.Repository;

public class ReservationRepositoryTests
{
    private async Task<RestaurantDbContext> GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<RestaurantDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var databaseContext = new RestaurantDbContext(options);
        databaseContext.Database.EnsureCreated();
        if (await databaseContext.Reservations.CountAsync() <= 0)
        {
            for (int i = 0; i < 10; i++)
            {
                databaseContext.Reservations.Add(
                    new ()
                    {
                        Date = "Monday",
                        Email = "this@is.email",
                        FirstName = "Joe",
                        LastName = "Mama",
                        ReservationTable = new ()
                        {
                            Location = "Window",
                            Number = 1,
                            NumberOfSeats = 2
                        }
                    }
                );
                await databaseContext.SaveChangesAsync();
            }
        }
        return databaseContext;
    }

    [Fact]
    public async void ReservationRepository_GetReservations_ReturnsReservations()
    {
        // Arrange
        var dbContext = await GetDatabaseContext();
        var repository = new ReservationRepository(dbContext);
        
        // Act
        var result = repository.GetReservations();
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<List<Reservation>>();
    }
    
    [Fact]
    public async void ReservationRepository_GetReservation_ReturnsReservation()
    {
        // Arrange
        var id = 1;
        var dbContext = await GetDatabaseContext();
        var repository = new ReservationRepository(dbContext);
        
        // Act
        var result = repository.GetReservation(id);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Reservation>();
    }
    
    [Fact]
    public async void ReservationRepository_CreateReservation_ReturnsReservation()
    {
        // Arrange
        Reservation reservation = new()
        {
            Date = "20.2.2023",
            Email = "email@email.com",
            FirstName = "Someone",
            LastName = "Fantastic",
            ReservationTableId = 1
        };
        var dbContext = await GetDatabaseContext();
        var repository = new ReservationRepository(dbContext);
        
        // Act
        var result = repository.CreateReservation(reservation);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Reservation>();
        result.Should().BeEquivalentTo(reservation);
    }
    
    [Fact]
    public async void ReservationRepository_DeleteReservation_ReturnsReservation()
    {
        // Arrange
        var id = 1;
        var dbContext = await GetDatabaseContext();
        var repository = new ReservationRepository(dbContext);
        
        // Act
        var result = repository.DeleteReservation(id);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Reservation>();
    }
    
}