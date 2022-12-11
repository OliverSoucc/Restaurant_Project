using Application.Interfaces.Repositories;
using Application.DTOs;
using Application.DTOs.Dish;
using Application.Interfaces.Services;
using AutoMapper;
using Domain;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Application;

public class DishService: IDishService
{
    private readonly IDishRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<GetDishDto> _postValidator;
    public DishService(IDishRepository repository, IMapper mapper, IValidator<GetDishDto> postValidator)
    {
        _repository = repository;
        _mapper = mapper;
        _postValidator = postValidator;
    }
    public List<Dish> GetAllDishes()
    {
        return _repository.GetAllDishes();
    }

    public Dish GetDish(int id)
    {
        return _repository.GetDish(id);
    }

    public Dish CreateNewDish(PostDishDto dto)
    {
        return _repository.CreateNewDish(_mapper.Map<Dish>(dto));
    }

    public Dish UpdateDish(PutDishDto dto)
    {
        return _repository.UpdateDish(_mapper.Map<Dish>(dto));
    }

    public Dish DeleteDish(int id)
    {
        return _repository.DeleteDish(id);
    }
}