using Application.Interfaces.Repositories;
using Application.DTOs;
using Application.DTOs.Dish;
using Application.Interfaces.Services;
using AutoMapper;
using Domain;

namespace Application;

public class DishService: IDishService
{
    private readonly IDishRepository _repository;
    private readonly IMapper _mapper;
    public DishService(IDishRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
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