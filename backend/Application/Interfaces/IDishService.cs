using Application.Validators;

namespace Domain.Interfaces;

public interface IDishService
{
    public List<Dish> GetAllDishes();
    public Dish CreateNewDish(PostDishDTO dto);
}