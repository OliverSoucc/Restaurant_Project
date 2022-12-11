using Domain;
namespace Application.Interfaces.Repositories;

public interface IDishRepository
{
    public List<Dish> GetAllDishes();
    public Dish GetDish(int id);
    public Dish CreateNewDish(Dish dish);
    public Dish DeleteDish(int id);
    public Dish UpdateDish(Dish dish);
}