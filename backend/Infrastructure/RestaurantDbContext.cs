using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories;

public class RestaurantDbContext: DbContext
{

    private readonly IConfiguration _configuration;
    
    public RestaurantDbContext(DbContextOptions options, IConfiguration configuration): base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        // "Host=localhost;Database=restaurant;Username=jannahalka;Password=admin"
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("webApi"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<DishIngredient>()
            .HasKey(di => new { di.DishId, di.IngredientId });
        
        modelBuilder.Entity<Dish>()
            .Property(d => d.Id)
            .ValueGeneratedOnAdd();
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<DishIngredient> DishIngredients { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ReservationTable> ReservationTables { get; set; }
}