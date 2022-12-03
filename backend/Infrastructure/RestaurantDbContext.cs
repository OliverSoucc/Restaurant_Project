using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class RestaurantDbContext: DbContext
{
    
    public RestaurantDbContext(DbContextOptions options): base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Database=restaurant;Username=jannahalka;Password=admin");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dish>()
            .Property(d => d.Id)
            .ValueGeneratedOnAdd();
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Dish> DishTable { get; set; }
}