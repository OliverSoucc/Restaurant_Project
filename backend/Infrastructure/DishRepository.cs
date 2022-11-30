using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class DishRepository: IDishRepository
{
    public List<Dish> GetAllDishes()
    {
        return new List<Dish>()
            { new() { Id = 1, Price = "Pizza", Description = "This is pizza", WeekDay = DateTime.Now } };
    }
}