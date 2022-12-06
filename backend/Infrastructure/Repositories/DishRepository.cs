using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class DishRepository: IDishRepository
{
    private readonly RestaurantDbContext _context;

    public DishRepository(RestaurantDbContext context)
    {
        _context = context;
    }
    
    public List<Dish> GetAllDishes()
    {
        return _context.Dishes.ToList();
    }

    public Dish GetDish(int id)
    {
        return _context.Dishes.Find(id);
    }

    public Dish CreateNewDish(Dish dish)
    {
        _context.Dishes.Add(dish);
        _context.SaveChanges();
        return dish;
    }

    public Dish DeleteDish(int id)
    {
        var dish = _context.Dishes.Find(id);
        _context.Dishes.Remove(dish);
        _context.SaveChanges();
        return dish;
    }

    public Dish UpdateDish(Dish dish)
    {
        _context.Dishes.Update(dish);
        _context.SaveChanges();
        return dish;
    }
}