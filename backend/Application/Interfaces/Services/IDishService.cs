using Application.DTOs;
using Application.DTOs.Dish;
using Domain;

namespace Application.Interfaces.Services;

public interface IDishService
{
    public List<Dish> GetAllDishes();
    public Dish GetDish(int id);
    public Dish CreateNewDish(PostDishDto dto);
    public Dish UpdateDish(PutDishDto dto);
    public Dish DeleteDish(int id);
}