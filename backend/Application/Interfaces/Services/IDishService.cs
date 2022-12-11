using Application.DTOs;
using Domain;

namespace Application.Interfaces.Services;

public interface IDishService
{
    public List<Dish> GetAllDishes();
    public Dish CreateNewDish(GetDishDto dto);
}