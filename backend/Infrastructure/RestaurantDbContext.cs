using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories;

public class RestaurantDbContext: DbContext
{
    public RestaurantDbContext(DbContextOptions options): base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile("appsettings.Development.json", true, true)
            .Build();
        
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("WebApi"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<DishIngredient>()
            .HasKey(di => new { di.DishId, di.IngredientId });
        
        modelBuilder.Entity<Dish>()
            .Property(d => d.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.ReservationTable)
            .WithOne(rt => rt.Reservation);
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<DishIngredient> DishIngredients { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ReservationTable> ReservationTables { get; set; }
}