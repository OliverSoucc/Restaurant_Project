using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class DishRepository: IDishRepository
{
    private readonly RestaurantDbContext _context;

    public DishRepository(RestaurantDbContext context)
    {
        _context = context;
    }
    
    public List<Dish> GetAllDishes()
    {
        return _context.DishTable.ToList();
    }

    public Dish CreateNewDish(Dish dish)
    {
        _context.DishTable.Add(dish);
        _context.SaveChanges();
        return dish;
    }

    public string CreateDb()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        return "Database created";
    }
}