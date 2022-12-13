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
    public List<GetDishDto> GetAllDishes()
    {
        return _mapper.Map<List<GetDishDto>>(_repository.GetAllDishes());
    }

    public GetDishDto GetDish(int id)
    {
        return _mapper.Map<GetDishDto>(_repository.GetDish(id));
    }

    public GetDishDto CreateNewDish(PostDishDto dto)
    {
        return _mapper.Map<GetDishDto>(_repository.CreateNewDish(_mapper.Map<Dish>(dto)));
    }

    public GetDishDto UpdateDish(PutDishDto dto)
    {
        return _mapper.Map<GetDishDto>(_repository.UpdateDish(_mapper.Map<Dish>(dto)));
    }

    public GetDishDto DeleteDish(int id)
    {
        return _mapper.Map<GetDishDto>(_repository.DeleteDish(id));
    }
}