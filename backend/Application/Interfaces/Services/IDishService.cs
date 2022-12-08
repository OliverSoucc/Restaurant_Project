using Application.Validators;
using Domain;

namespace Application.Interfaces.Repositories;

public interface IDishService
{
    public List<Dish> GetAllDishes();
    public Dish CreateNewDish(GetDishDto dto);
}