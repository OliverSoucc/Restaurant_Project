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
        throw new NotImplementedException();
    }

    public Dish CreateNewDish(Dish dish)
    {
        _context.Dishes.Add(dish);
        _context.SaveChanges();
        return dish;
    }

    public Dish DeleteDish(int id)
    {
        throw new NotImplementedException();
    }

    public Dish UpdateDish(Dish dish)
    {
        throw new NotImplementedException();
    }
}