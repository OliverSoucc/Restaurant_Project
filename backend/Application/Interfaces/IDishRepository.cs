using Domain;

namespace Application.Interfaces;

public interface IDishRepository
{
    public List<Dish> GetAllDishes();
}