using Application.Interfaces;
using Domain;
using Domain.Interfaces;

namespace Application;

public class DishService: IDishService
{
    private IDishRepository _repository;

    public DishService(IDishRepository repository)
    {
        _repository = repository;
    }
    public List<Dish> GetAllDishes()
    {
        return _repository.GetAllDishes();
    }
}