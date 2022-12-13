using Application.DTOs;
using Application.DTOs.Dish;
using Domain;

namespace Application.Interfaces.Services;

public interface IDishService
{
    public List<GetDishDto> GetAllDishes();
    public GetDishDto GetDish(int id);
    public GetDishDto CreateNewDish(PostDishDto dto);
    public GetDishDto UpdateDish(PutDishDto dto);
    public GetDishDto DeleteDish(int id);
}