using Domain;

namespace Application.Interfaces;

public interface IDishRepository
{
    public List<Dish> GetAllDishes();
    public Dish CreateNewDish(Dish dish);

    public string CreateDb();
}